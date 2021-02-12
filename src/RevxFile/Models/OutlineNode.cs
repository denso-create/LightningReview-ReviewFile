using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class OutlineNode : EntityBase
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public Issues Issues { get; set; } = new Issues();

        [XmlArray]
        [XmlArrayItem("OutlineNode")]
        public List<OutlineNode> Children { get; set; } = new List<OutlineNode>();

        /// <summary>
        /// 子ノードまでのすべての指摘
        /// </summary>
        public IEnumerable<Issue> AllIssues
        {
            get
            {
                var issues = new List<Issue>();

                // 自身の指摘
                issues.AddRange(Issues.List);

                // 子ノードの指摘
                foreach (var node in Children)
                {
                    issues.AddRange(node.AllIssues);
                }

                return issues;
            }
        }
    }
}
