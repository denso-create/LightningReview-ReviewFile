using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class Review : EntityBase, IReview
    {
        #region 永続化プロパティ

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
        public string PlannedTime { get; set; }

        [XmlElement]
        public string ActualTime { get; set; }

        [XmlElement]
        public string Unit { get; set; }

        [XmlElement]
        public string PlannedScale { get; set; }

        [XmlElement]
        public Documents Documents { get; set; }

        #endregion

        #region 非永続化プロパティ

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// すべての指摘
        /// </summary>
        public IEnumerable<IIssue> Issues
        {
            get
            {
                var issues = new List<IIssue>();

                // 各ドキュメントの指摘
                foreach (var doc in Documents.List)
                {
                    issues.AddRange(doc.AllIssues);
                }

                return issues.ToList();
            }
        }

        IEnumerable<IDocument> IReview.Documents => Documents.List.OfType<IDocument>();

        #endregion
    }
}
