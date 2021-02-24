using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class ReviewFile : IReviewFile
    {
        #region プロパティ

        [XmlElement]
        public string SchemaVersion { get; set; }

        [XmlElement]
        public Review Review { get; set; }

        /// <summary>
        /// レビュー
        /// </summary>
        IReview IReviewFile.Review => Review;

        #endregion
    }
}
