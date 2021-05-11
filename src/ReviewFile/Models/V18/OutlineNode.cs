using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// アウトラインノード
    /// </summary>
    [XmlRoot]
    public class OutlineNode : EntityBase,IOutlineNode
    {
        #region プロパティ

        /// <summary>
        /// ノード名
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// このアウトラインに関連づく指摘の一覧
        /// </summary>
        [XmlElement]
        public Issues Issues { get; set; } = new Issues();

        /// <summary>
        /// 子ノードの一覧
        /// </summary>
        [XmlArray("Children")]
        [XmlArrayItem("OutlineNode")]
        public List<OutlineNode> ChildNodes{ get; set; } = new List<OutlineNode>();

        /// <summary>
        /// 子ノードまでのすべての指摘
        /// </summary>
        public IEnumerable<IIssue> AllIssues
        {
            get
            {
                var issues = new List<IIssue>();
                issues.AddRange(Issues.List.OfType<IIssue>());

                // 子ノードの指摘
                foreach (var node in ChildNodes)
                {
                    issues.AddRange(node.AllIssues);
                }

                return issues;
            }
        }

        /// <summary>
        /// 子ノードの一覧
        /// </summary>
        public IEnumerable<IOutlineNode> Children => ChildNodes.OfType<IOutlineNode>();

        #endregion
    }
}
