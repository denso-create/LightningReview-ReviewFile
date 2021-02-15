﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using LightningReview.ReviewFile.Models;
using System.Xml.Serialization;
using System.Xml;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using LightningReview.ReviewFile.Exceptions;

namespace LightningReview.ReviewFile
{
    /// <summary>
    /// レビューファイルのリーダー
    /// </summary>
    public class ReviewFileReader : IReviewFileReader
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
                        if (xElement == null) throw new ReviewFileFormatException("ReviewFile Element Missing");
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
                        throw new ReviewFileFormatException(ex.Message, ex);
                    }
                }
            }
        }

        public async Task<IReview> ReadAsync(string filepath)
        {
            return await Task.Run(() => Read(filepath));
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

            var ReviewFilePaths = Directory.GetFiles(folderPath, "*.revx", searchOption);
            var reviews = new List<IReview>();
            foreach (var ReviewFilePath in ReviewFilePaths)
            {
                var review = Read(ReviewFilePath);
                reviews.Add(review);
            }

            return reviews;
        }

        public async Task<IEnumerable<IReview>> ReadFolderAsync(string folderPath, bool readSubFodler = false)
        {
            return await Task.Run(() => ReadFolderAsync(folderPath, readSubFodler));
        }
    }
}