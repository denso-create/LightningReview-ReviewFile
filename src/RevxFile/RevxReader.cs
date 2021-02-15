using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using LightningReview.RevxFile.Models;
using System.Xml.Serialization;
using System.Xml;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using LightningReview.RevxFile.Exceptions;

namespace LightningReview.RevxFile
{
    /// <summary>
    /// レビューファイルのリーダー
    /// </summary>
    public class RevxReader : IRevxReader
    {
        /// <summary>
        /// ファイルからロードします。
        /// </summary>
        /// <param name="filePath">レビューファイルのパス</param>
        /// <returns>ロードしたレビューモデル</returns>
        public IReview Read(string filePath)
        {
            using ( var archive = ZipFile.OpenRead(filePath))
            {
                // revxから"Review.xml"を抜き出す
                var reviewXmlEntry = archive.GetEntry("Review.xml");
                using (var zipEntryStream = reviewXmlEntry.Open())
                {
                    try {

                        // スキーマバージョン値を取得
                        var xDoc = XDocument.Load(zipEntryStream);
                        var xElement = xDoc.Element("ReviewFile");
                        if (xElement == null) throw new RevxFormatException("ReviewFile Element Missing");
                        var schemeVersion = double.Parse(xElement.Element("SchemaVersion").Value);

                        // デシリアライズする
                        // スキーマが1.7以降はV1.8のモデルになる
                        var serializer = schemeVersion >= 1.7 ? new XmlSerializer(typeof(Models.V18.ReviewFile)) : new XmlSerializer(typeof(Models.V10.ReviewFile));
                        var reviewFile = (IReviewFile)serializer.Deserialize(xDoc.CreateReader());

                        // フィールドを追加設定する
                        reviewFile.Review.FilePath = filePath;

                        return reviewFile.Review;

                    }
                    catch (Exception ex)
                    {
                        throw new RevxFormatException(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// フォルダからロードします
        /// </summary>
        /// <param name="folderPath">対象フォルダ</param>
        /// <param name="includeSubFodler">サブフォルダも対象にする</param>
        /// <returns></returns>
        public IEnumerable<IReview> ReadFolder(string folderPath, bool includeSubFodler = false)
        {
            // 指定したフォルダ以下（サブフォルダ以下も含めて）に存在するすべてのレビューファイルを取得する
            if (Directory.Exists(folderPath) == false)
            {
                throw new Exception($"{folderPath}が存在しません。");
            }

            // 指定されたフォルダ以下のレビューファイルに対して、レビューのデータを取得する
            var searchOption = includeSubFodler ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            var revxFilePaths = Directory.GetFiles(folderPath, "*.revx", searchOption);
            var reviews = new List<IReview>();
            foreach (var revxFilePath in revxFilePaths)
            {
                var review = Read(revxFilePath);
                reviews.Add(review);
            }

            return reviews;
        }
    }
}
