using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxReader.Models
{
    [XmlRoot]
    public class Review
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Goal { get; set; }

        //[XmlArray]
        //public List<Issue> Issues { get; set; } = new List<Issue>();

    }


}
