using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class Document : EntityBase,IDocument
    {
        #region プロパティ
        
        [XmlElement]
        public string LID { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string AbsolutePath { get; set; }

        [XmlElement]
        public string ApplicationType { get; set; }

        [XmlElement]
        public OutlineTree OutlineTree { get; set; } = new OutlineTree();

        /// <summary>
        /// このドキュメントに関連づく指摘の一覧
        /// </summary>
        public IEnumerable<IIssue> AllIssues => OutlineTree.VirtualRoot.AllIssues;

        /// <summary>
        /// このドキュメントに関連づくアウトラインの一覧
        /// </summary>
        public IEnumerable<IOutlineNode> OutlineNodes => OutlineTree.VirtualRoot.Children.OfType<IOutlineNode>();

        #endregion
    }
}
