using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models.V10
{
    [XmlRoot]
    public class Document : IDocument
    {
        public string GID { get => GlobalId; set => GlobalId = value; }

        [XmlAttribute]
        public string GlobalId { get; set; }

        public string LID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IIssue> AllIssues => throw new NotImplementedException();

        public IEnumerable<IOutlineNode> OutlineNodes => throw new NotImplementedException();
    }
}
