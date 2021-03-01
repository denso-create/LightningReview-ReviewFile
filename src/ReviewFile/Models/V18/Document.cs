using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// ドキュメント
    /// </summary>
    [XmlRoot]
    public class Document : EntityBase,IDocument
    {
        #region プロパティ
        
        /// <summary>
        /// ローカルID
        /// </summary>
        [XmlElement]
        public string LID { get; set; }

        /// <summary>
        /// ドキュメント名
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// ドキュメントの絶対パス
        /// </summary>
        [XmlElement]
        public string AbsolutePath { get; set; }

        /// <summary>
        /// 関連づいているアプリケーション
        /// </summary>
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

        /// <summary>
        /// このドキュメントに関連づくアウトラインの一覧
        /// </summary>
        public IEnumerable<IOutlineNode> OutlineNodes => OutlineTree.VirtualRoot.Children.OfType<IOutlineNode>();

        #endregion
    }
}
