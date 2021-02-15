using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
    [XmlRoot]
    public class Document : IDocument
    {
        [XmlAttribute]
        public string GlobalId { get; set; }
        public string GID { get => GlobalId; set => GlobalId = value; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string ID { get; set; }

        public string LID { get => ID; set => ID = value; }

        //[XmlArray]
        //[XmlArrayItem("OutlineTree")]
        //public List<OutlineNode> OutlineTree { get; set; }

        public IEnumerable<IOutlineNode> OutlineNodes => throw new NotImplementedException();
    }
}
