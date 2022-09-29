using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// ドキュメント
    /// </summary>
    [XmlRoot]
    public class Document : EntityBase, IDocument
    {
        #region プロパティ

        /// <inheritdoc />
        [XmlElement]
        public string LID { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Name { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string AbsolutePath { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string ApplicationType { get; set; }

        /// <summary>
        /// アウトラインツリー
        /// </summary>
        [XmlElement]
        public OutlineTree OutlineTree { get; set; } = new OutlineTree();

        /// <summary>
        /// このドキュメントに関連づく指摘の一覧
        /// </summary>
        public IEnumerable<IIssue> AllIssues => OutlineTree.VirtualRoot.AllIssues;

        /// <inheritdoc />
        public IEnumerable<IOutlineNode> OutlineNodes => OutlineTree.VirtualRoot.Children.OfType<IOutlineNode>();

        #endregion
    }
}
