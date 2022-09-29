using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
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
        IReview IReviewFile.Review => Review;

        #endregion
    }
}
