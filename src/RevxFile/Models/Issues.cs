using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class Issues : EntityBase
    {
        [XmlArray("List")]
        [XmlArrayItem("Issue")]
        public List<Issue> List { get; set; }  = new List<Issue>();
    }
}
