using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
    [XmlRoot]
    public class Review : IReview
    {
        [XmlAttribute]
        public string GlobalId { get; set; }
        public string GID { get => GlobalId; set => GlobalId = value; }

        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// ステータス
        /// TODO xmlの階層が深く取得が複雑となり、実装に時間がかかるため今後の課題とする
        /// 現時点ではデータ収集の対象になり得ないと考えられるため保留
        /// </summary>
        public string Status { get; set; }

        [XmlElement]
        public string Goal { get; set; }

        [XmlElement]
        public string EndCondition { get; set; }

        /// <summary>
        /// ドメイン
        /// TODO xmlの階層が深く取得が複雑となり、実装に時間がかかるため今後の課題とする
        /// 現時点ではデータ収集の対象になり得ないと考えられるため保留
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// レビュー種別
        /// TODO xmlの階層が深く取得が複雑となり、実装に時間がかかるため今後の課題とする
        /// 現時点ではデータ収集の対象になり得ないと考えられるため保留
        /// </summary>
        public string ReviewType { get; set; }

        /// <summary>
        /// レビュー形式
        /// TODO xmlの階層が深く取得が複雑となり、実装に時間がかかるため今後の課題とする
        /// 現時点ではデータ収集の対象になり得ないと考えられるため保留
        /// </summary>
        public string ReviewStyle { get; set; }

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

        [XmlElement]
        public string LastUpdatedBy { get; set; }

        [XmlElement("CreatedDateTime")]
        public string CreatedDateTimeString { get; set; }


        [XmlElement("LastUpdatedDateTime")]
        public string LastUpdatedDateTimeString { get; set; }

        [XmlElement]
        public string CreatedBy { get; set; }

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; }

        public DateTime CreatedDateTime => DateTime.Parse(CreatedDateTimeString);

        public DateTime LastUpdatedDateTime => DateTime.Parse(LastUpdatedDateTimeString);

        public IEnumerable<IIssue> Issues => IssueEntities;

        public IEnumerable<IDocument> Documents => DocumentEneities;
    }

}
