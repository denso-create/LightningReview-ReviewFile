using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using LightningReview.ReviewFile.Models.V18.Defenitions;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class Review : EntityBase, IReview
    {
        #region プロパティ

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// このレビューファイルに関連づく指摘の一覧
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

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
        IEnumerable<IDocument> IReview.Documents => Documents.List.OfType<IDocument>();

        #region 基本設定タブ
        
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Goal { get; set; }

        [XmlElement]
        public string EndCondition { get; set; }
        
        [XmlElement]
        public string Place { get; set; }

        
        [XmlElement]
        public Documents Documents { get; set; }

        /// <summary>
        /// プロジェクト
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// プロジェクトコード
        /// </summary>
        public string ProjectCode
        {
            get => Project.Code;
            set => Project.Code = value;
        }

        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string ProjectName
        {
            get => Project.Name;
            set => Project.Name = value;
        }

        #endregion

        #region 予実タブ

        [XmlElement("PlannedDate")]
        public string PlannedDateString { get; set; }
        public DateTime? PlannedDate => string.IsNullOrEmpty(PlannedDateString) ? (DateTime?) null : DateTime.Parse(PlannedDateString);

        [XmlElement("ActualDate")]
        public string ActualDateString { get; set; }
        public DateTime? ActualDate => string.IsNullOrEmpty(ActualDateString) ? (DateTime?) null : DateTime.Parse(ActualDateString);

        [XmlElement]
        public string PlannedTime { get; set; }

        [XmlElement]
        public string ActualTime { get; set; }

        [XmlElement]
        public string Unit { get; set; }

        [XmlElement]
        public string PlannedScale { get; set; }

        [XmlElement]
        public string ActualScale { get; set; }

        [XmlElement]
        public string IssueCountOfGoal { get; set; }

        /// <summary>
        /// 実績件数
        /// </summary>
        public string IssueCountOfActual
        {
            get
            {
                var issueCountOfActualCount = 0;
                foreach (var issue in Issues)
                {
                    // 指摘タイプがグッドポイントあるいは対策要否が否でない指摘の件数が実績件数
                    if ((issue.Type == "グッドポイント") || (issue.NeedToFix == "いいえ"))
                    {
                        continue;
                    }

                    issueCountOfActualCount++;
                }

                return issueCountOfActualCount.ToString();
            }
        }

        #endregion

        #endregion
    }
}
