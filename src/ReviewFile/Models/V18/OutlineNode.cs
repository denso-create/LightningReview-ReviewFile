using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class OutlineNode : EntityBase,IOutlineNode
    {
	    #region プロパティ

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public Issues Issues { get; set; } = new Issues();

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

        public IEnumerable<IOutlineNode> Children => ChildNodes.OfType<IOutlineNode>();

        #endregion
    }
}
