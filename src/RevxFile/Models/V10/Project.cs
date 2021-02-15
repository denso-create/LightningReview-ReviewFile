using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models.V10
{
    [XmlRoot]
    public class Project
    {
        [XmlElement]
        public string Code { get; set; }

        [XmlElement]
        public string Name { get; set; }
    }
}
