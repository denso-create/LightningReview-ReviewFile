using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
{
    /// <summary>
    /// レビューファイル
    /// </summary>
    [XmlRoot]
    public class ReviewFile : IReviewFile
    {
        #region プロパティ
        
        /// <summary>
        /// スキーマバージョン値
        /// </summary>
        [XmlElement]
        public string SchemaVersion { get; set; }
        
        /// <summary>
        /// レビュー
        /// </summary>
        [XmlElement]
        public Review Review { get; set; }

        /// <summary>
        /// レビュー
        /// </summary>
        IReview IReviewFile.Review
        {
            get
            {
                Review.Definition = Definition;
                return Review;
            }
        }

        /// <summary>
        /// 定義
        /// </summary>
        [XmlElement]
        public Definition Definition { get; set; }

        #endregion
    }
}
