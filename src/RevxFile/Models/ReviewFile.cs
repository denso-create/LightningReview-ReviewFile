using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class ReviewFile
    {
        [XmlElement]
        public Review Review { get; set; }
    }
}
