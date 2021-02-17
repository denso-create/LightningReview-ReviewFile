using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
    [XmlRoot]
    public class ReviewFile : IReviewFile
    {
	    #region プロパティ
        
        [XmlElement]
        public string SchemaVersion { get; set; }

        [XmlElement]
        public Review Review { get; set; }

        IReview IReviewFile.Review => Review;

        #endregion
    }
}
