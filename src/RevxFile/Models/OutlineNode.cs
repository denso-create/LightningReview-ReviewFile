using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class OutlineNode : EntityBase
    {
        public Issues Issues { get; set; } = new Issues();

        public List<OutlineNode> Children { get; set; } = new List<OutlineNode>();
    }
}
