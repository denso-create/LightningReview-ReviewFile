using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using LightningReview.RevxFile.Models;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;

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
        public Review Read(string filePath)
        {
            using ( var archive = ZipFile.OpenRead(filePath))
            {
                // revxから"Review.xml"を抜き出す
                var reviewXmlEntry = archive.GetEntry("Review.xml");
                using ( var zipEntryStream = reviewXmlEntry.Open() )
                {
                    // デシリアライズする
                    var serializer = new XmlSerializer(typeof(ReviewFile));
                    var reviewFile = (ReviewFile)serializer.Deserialize(zipEntryStream);

                    // フィールドを追加設定する
                    reviewFile.Review.FilePath = filePath;

                    return reviewFile.Review;
                }
            }
        }

        /// <summary>
        /// フォルダからロードします
        /// </summary>
        /// <param name="folderPath">対象フォルダ</param>
        /// <param name="includeSubFodler">サブフォルダも対象にする</param>
        /// <returns></returns>
        public IEnumerable<Review> ReadFolder(string folderPath, bool includeSubFodler = false)
        {
            // 指定したフォルダ以下（サブフォルダ以下も含めて）に存在するすべてのレビューファイルを取得する
            if (Directory.Exists(folderPath) == false)
            {
                throw new Exception($"{folderPath}が存在しません。");
            }

            // 指定されたフォルダ以下のレビューファイルに対して、レビューのデータを取得する
            var searchOption = includeSubFodler ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            var revxFilePaths = Directory.GetFiles(folderPath, "*.revx", searchOption);
            var reviews = new List<Review>();
            foreach (var revxFilePath in revxFilePaths)
            {
                var review = Read(revxFilePath);
                reviews.Add(review);
            }

            return reviews;
        }
    }
}
