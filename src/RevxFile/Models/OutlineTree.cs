using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class OutlineTree : EntityBase
    {
        [XmlElement]
        public OutlineNode VirtualRoot { get; set; } = new OutlineNode();
    }
}
