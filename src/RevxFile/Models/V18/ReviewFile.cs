using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models.V18
{
    [XmlRoot]
    public class ReviewFile : IReviewFile
    {
        [XmlElement]
        public string SchemaVersion { get; set; }

        [XmlElement]
        public Review Review { get; set; }

        IReview IReviewFile.Review => Review;
    }
}
