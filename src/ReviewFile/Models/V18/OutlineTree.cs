using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class OutlineTree : EntityBase
    {
        [XmlElement]
        public OutlineNode VirtualRoot { get; set; } = new OutlineNode();
    }
}
