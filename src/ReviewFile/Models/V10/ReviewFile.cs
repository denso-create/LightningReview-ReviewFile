using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
{
    /// <summary>
    /// レビューファイル
    /// </summary>
    [XmlRoot]
    public class ReviewFile : IReviewFile
    {
        #region プロパティ

        /// <inheritdoc />
        [XmlElement]
        public string SchemaVersion { get; set; }

        /// <inheritdoc cref="IReviewFile.Review" />
        [XmlElement]
        public Review Review { get; set; }

        /// <inheritdoc />
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
