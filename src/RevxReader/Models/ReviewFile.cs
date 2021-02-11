using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxReader.Models
{
    [XmlRoot]
    public class ReviewFile
    {
        [XmlElement]
        public Review Review { get; set; }
    }
}
