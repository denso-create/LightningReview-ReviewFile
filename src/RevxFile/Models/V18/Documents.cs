using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models.V18
{
    [XmlRoot]
    public class Documents : EntityBase
    {
        [XmlArray("List")]
        [XmlArrayItem("Document")]
        public List<Document> List { get; set; } = new List<Document>();
    }
}
