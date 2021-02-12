using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{

    [XmlRoot]
    public class Project : EntityBase
    {
        [XmlElement]
        public string Code { get; set; }

        [XmlElement]
        public string Name { get; set; }
    }
}
