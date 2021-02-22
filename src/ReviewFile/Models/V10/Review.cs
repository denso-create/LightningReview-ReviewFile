using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
    [XmlRoot]
    public class Review : IReview
    {
	    #region プロパティ

        [XmlAttribute]
        public string GlobalID { get; set; }
        public string GID { get => GlobalID; set => GlobalID = value; }

        [XmlElement]
        public string CreatedBy { get; set; }

        [XmlElement]
        public string LastUpdatedBy { get; set; }

        [XmlElement("CreatedDateTime")]
        public string CreatedDateTimeString { get; set; }
        public DateTime? CreatedDateTime => string.IsNullOrEmpty(CreatedDateTimeString) ? (DateTime?) null : DateTime.Parse(CreatedDateTimeString);

        [XmlElement("LastUpdatedDateTime")]
        public string LastUpdatedDateTimeString { get; set; }
        public DateTime? LastUpdatedDateTime => string.IsNullOrEmpty(LastUpdatedDateTimeString) ? (DateTime?) null : DateTime.Parse(LastUpdatedDateTimeString);

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// このレビューファイルに関連づく指摘の一覧
        /// </summary>
        public IEnumerable<IIssue> Issues => IssueEntities;

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
        public IEnumerable<IDocument> Documents => DocumentEneities;

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

        [XmlArray("Documents")]
        [XmlArrayItem("Document")]
        public List<Document> DocumentEneities { get; set; }

        [XmlArray("Issues")]
        [XmlArrayItem("Issue")]
        public List<Issue> IssueEntities { get; set; }

        #endregion

        #endregion
    }
}
