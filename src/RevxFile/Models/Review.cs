using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class Review : EntityBase
    {
        #region プロパティ
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Goal { get; set; }

        [XmlElement]
        public string Domain { get; set; }

        [XmlElement]
        public string Place { get; set; }

        [XmlElement]
        public string PlannedDate { get; set; }

        [XmlElement]
        public string ActualDate { get; set; }

        [XmlElement]
        public Documents Documents { get; set; }

        #endregion

        /// <summary>
        /// すべての指摘
        /// </summary>
        public IEnumerable<Issue> AllIssues
        {
            get
            {
                var issues = new List<Issue>();

                // 各ドキュメントの指摘
                foreach (var doc in Documents.List)
                {
                    issues.AddRange(doc.AllIssues);
                }

                return issues;
            }
        }
    }
}
