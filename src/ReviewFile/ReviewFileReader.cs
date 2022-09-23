using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using DensoCreate.LightningReview.ReviewFile.Models;
using System.Xml.Serialization;
using System.Xml;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using DensoCreate.LightningReview.ReviewFile.Exceptions;

namespace DensoCreate.LightningReview.ReviewFile
{
    /// <summary>
    /// レビューファイルのリーダー
    /// </summary>
    public class ReviewFileReader : IReviewFileReader
    {
        /// <inheritdoc />
        public IReview Read(string filePath)
        {
            using (var archive = ZipFile.OpenRead(filePath))
            {
                // revxから"Review.xml"を抜き出す
                var reviewXmlEntry = archive.GetEntry("Review.xml");
                using (var zipEntryStream = reviewXmlEntry.Open())
                {
                    var review = Read(zipEntryStream);

                    // Streamを引数にしたReadメソッドではファイルパスが設定されていないため、ここで設定する
                    switch (review)
                    {
                        case Models.V18.Review realReview:
                            realReview.FilePath = filePath;
                            break;
                        case Models.V10.Review realReview:
                            realReview.FilePath = filePath;
                            break;
                    }

                    return review;
                }
            }
        }

        /// <inheritdoc />
        public IReview Read(Stream reviewFileStream)
        {
            try
            {
                // スキーマバージョン値を取得
                var xDoc = XDocument.Load(reviewFileStream);
                var xElement = xDoc.Element("ReviewFile");
                if (xElement == null) throw new ReviewFileFormatException("ReviewFile Element Missing");
                var schemeVersion = double.Parse(xElement.Element("SchemaVersion").Value);

                // デシリアライズする
                // スキーマが1.7以降はV1.8のモデルになる
                var serializer = schemeVersion >= 1.7
                    ? new XmlSerializer(typeof(Models.V18.ReviewFile))
                    : new XmlSerializer(typeof(Models.V10.ReviewFile));
                var reviewFile = (IReviewFile)serializer.Deserialize(xDoc.CreateReader());

                // Streamを指定しており、この時点ではファイルパスが特定できないためファイルパスを空文字とする必要がある
                // 以降の処理で、具象のReviewクラスごとにFilePathにstring.Emptyをいれる

                if (schemeVersion >= 1.7)
                {
                    var realReview = (Models.V18.Review)reviewFile.Review;
                    realReview.FilePath = string.Empty;

                    // すべての指摘に、その指摘が紐づいているIDocumentとIOutlineNodeの参照をセットする
                    foreach (var realDocument in realReview.Documents.List)
                    {
                        // ドキュメント直下の指摘に対して、ドキュメントへの参照をセットする
                        // このとき、アウトラインノードへの参照はnullとなる
                        var realRootNode = realDocument.OutlineTree.VirtualRoot;
                        foreach (var realIssue in realRootNode.Issues.List)
                        {
                            realIssue.Document = realDocument;
                        }

                        // 仮想的なルートノードを除き、ドキュメント直下のアウトラインノードごとに処理する
                        foreach (var childNode in realRootNode.ChildNodes)
                        {
                            LinkIssueToDocumentAndOutlineNode(childNode);
                        }

                        // アウトラインノードを再帰的に探索して、
                        // アウトラインノードが持つ指摘にドキュメントとそのアウトラインノードの参照をセットする
                        void LinkIssueToDocumentAndOutlineNode(Models.V18.OutlineNode realOutlineNode)
                        {
                            // IDocumentとIOutlineNodeを指摘に紐づける
                            foreach (var realIssue in realOutlineNode.Issues.List)
                            {
                                realIssue.Document = realDocument;
                                realIssue.OutlineNode = realOutlineNode;
                            }

                            // すべての子ノードに対して再帰呼び出しする
                            foreach (var realChildNode in realOutlineNode.ChildNodes)
                            {
                                LinkIssueToDocumentAndOutlineNode(realChildNode);
                            }
                        }
                    }
                }
                else
                {
                    var realReview = (Models.V10.Review)reviewFile.Review;
                    realReview.FilePath = string.Empty;

                    // V10のモデルでは、各Issueの持つOutlinePathの情報からしか紐づいているドキュメントを特定できない。
                    // そのため、OutlinePath中のドキュメントの名前と一致する最初のドキュメントを紐づける方針とする

                    // あらかじめDocumentとOutlineNodeのハッシュテーブルを作成し、O(1)でアクセスできるようにする。
                    // 指摘が持つOutlinePath中の名前と一致する"最初の"DocumentおよびOutlineNodeを紐づける制約のため、
                    // すでにハッシュテーブルに存在するキーのDocumentおよびOutlineNodeは追加しない。
                    var documentTable = new Dictionary<string, Models.V10.Document>();
                    var outlineNodeTable = new Dictionary<string, Models.V10.OutlineNode>();
                    foreach (var realDocument in realReview.DocumentEntities)
                    {
                        // ハッシュテーブルに同名のドキュメントが存在しなければ、追加する
                        if (!documentTable.ContainsKey(realDocument.Name)) documentTable[realDocument.Name] = realDocument;

                        // ドキュメント直下のアウトラインノードごとに処理する
                        foreach (var realOutlineNode in realDocument.OutlineNodes)
                        {
                            AddOutlineNodeToTable(realOutlineNode, $"/{realDocument.Name}");
                        }

                        // ドキュメントの持つアウトラインノードを再帰的に探索し、ハッシュテーブルに追加する。
                        void AddOutlineNodeToTable(Models.V10.OutlineNode realOutlineNode, string parentPath)
                        {
                            // ハッシュテーブルに同じアウトラインパスを持つアウトラインノードが存在しなければ、追加する
                            var outlineNodeKey = $"{parentPath}/{realOutlineNode.Name}";
                            if (!documentTable.ContainsKey(outlineNodeKey)) outlineNodeTable[outlineNodeKey] = realOutlineNode;

                            // 子ノードに対して再帰呼び出しする。
                            foreach (var realChildNode in realOutlineNode.ChildNodes)
                            {
                                AddOutlineNodeToTable(realChildNode, outlineNodeKey);
                            }
                        }
                    }

                    // すべての指摘について、指摘が所属するドキュメントの名前とアウトラインパスに対応する
                    // ドキュメントとアウトラインノードへの参照をセットする
                    foreach (var issue in realReview.Issues)
                    {
                        var realIssue = (Models.V10.Issue)issue;
                        realIssue.Document = documentTable[realIssue.RootOutlineName];
                        // ドキュメント直下にある指摘の場合はnullとなる
                        realIssue.OutlineNode = outlineNodeTable.TryGetValue(realIssue.OutlinePath, out var outlineNode) ? outlineNode : null;
                    }
                }

                return reviewFile.Review;
            }
            catch (Exception ex)
            {
                throw new ReviewFileFormatException(ex.Message, ex);
            }
        }

        /// <inheritdoc />
        public async Task<IReview> ReadAsync(string filePath)
        {
            return await Task.Run(() => Read(filePath));
        }

        /// <inheritdoc />
        public async Task<IReview> ReadAsync(Stream reviewFileStream)
        {
            return await Task.Run(() => Read(reviewFileStream));
        }

        /// <inheritdoc />
        public IEnumerable<IReview> ReadFolder(string folderPath, bool includeSubFolder = false)
        {
            // 指定したフォルダ以下（サブフォルダ以下も含めて）に存在するすべてのレビューファイルを取得する
            if (Directory.Exists(folderPath) == false)
            {
                throw new ReviewFileFormatException($"{folderPath} is not a valid directory.");
            }

            // 指定されたフォルダ以下のレビューファイルに対して、レビューのデータを取得する
            var searchOption = includeSubFolder ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            var ReviewFilePaths = Directory.GetFiles(folderPath, "*.revx", searchOption);
            var reviews = new List<IReview>();
            foreach (var ReviewFilePath in ReviewFilePaths)
            {
                var review = Read(ReviewFilePath);
                reviews.Add(review);
            }

            return reviews;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<IReview>> ReadFolderAsync(string folderPath, bool includeSubFolder = false)
        {
            return await Task.Run(() => ReadFolder(folderPath, includeSubFolder));
        }
    }
}
