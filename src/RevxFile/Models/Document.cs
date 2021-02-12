using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class Document : EntityBase
    {
        [XmlElement]
        public string LID { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string AbsolutePath { get; set; }

        [XmlElement]
        public string RelativePath { get; set; }

        [XmlElement]
        public string ApplicationType { get; set; }

        [XmlElement]
        public OutlineTree OutlineTree { get; set; } = new OutlineTree();

        /// <summary>
        /// アウトラインノード
        /// </summary>
        public IList<OutlineNode> OutlineNodes => OutlineTree.VirtualRoot.Children;

        /// <summary>
        /// 全ての指摘
        /// </summary>
        public IEnumerable<Issue> AllIssues => OutlineTree.VirtualRoot.AllIssues;

    }
}
