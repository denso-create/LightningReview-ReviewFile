using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using LightningReview.RevxFile.Models;
using System.Xml.Serialization;
using System.Threading.Tasks;

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
                var reviewXmlEntry = archive.GetEntry("Review.xml");
                using ( var zipEntryStream = reviewXmlEntry.Open() )
                {
                    var serializer = new XmlSerializer(typeof(ReviewFile));
                    var reviewFile = (ReviewFile)serializer.Deserialize(zipEntryStream);

                    return reviewFile.Review;
                }
            }
        }

    }
}
