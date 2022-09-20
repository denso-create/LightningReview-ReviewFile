using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
{
    /// <summary>
    /// レビュー
    /// </summary>
    [XmlRoot]
    public class Review : IReview
    {
        #region プロパティ

        /// <summary>
        /// グローバルID（V10定義）
        /// </summary>
        [XmlAttribute]
        public string GlobalID { get; set; }

        /// <summary>
        /// グローバルID
        /// </summary>
        public string GID { get => GlobalID; set => GlobalID = value; }

        /// <summary>
        /// 作成者
        /// </summary>
        [XmlElement]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 最終更新者
        /// </summary>
        [XmlElement]
        public string LastUpdatedBy { get; set; }

        /// <summary>
        /// 作成日時の文字列
        /// </summary>
        [XmlElement("CreatedDateTime")]
        public string CreatedDateTimeString { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime? CreatedDateTime => string.IsNullOrEmpty(CreatedDateTimeString) ? (DateTime?) null : DateTime.Parse(CreatedDateTimeString);

        /// <summary>
        /// 最終更新日時
        /// </summary>
        [XmlElement("LastUpdatedDateTime")]
        public string LastUpdatedDateTimeString { get; set; }

        /// <summary>
        /// 最終更新日時の文字列
        /// </summary>
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
        public IEnumerable<IDocument> Documents => DocumentEntities;

        /// <inheritdoc />
        public IEnumerable<IReviewMember> Members => Definition.ReviewDefinition.Members;

        #region 基本設定
        
        /// <summary>
        /// レビュー名
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        [XmlElement]
        public string Goal { get; set; }

        /// <summary>
        /// 終了条件
        /// </summary>
        [XmlElement]
        public string EndCondition { get; set; }

        /// <summary>
        /// 場所
        /// </summary>
        [XmlElement]
        public string Place { get; set; }

        /// <summary>
        /// プロジェクト
        /// </summary>
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
        
        /// <summary>
        /// 定義
        /// </summary>
        public Definition Definition { get; set; }
        
        /// <summary>
        /// レビュー種別
        /// </summary>
        public string ReviewType => Definition.ReviewDefinition.ReviewType;

        /// <inheritdoc />
        public IEnumerable<string> ReviewTypeAllowedValues => Definition.ReviewDefinition.ReviewTypeAllowedValues;

        /// <summary>
        /// ドメイン
        /// </summary>
        public string Domain => Definition.ReviewDefinition.Domain;

        /// <inheritdoc />
        public IEnumerable<string> DomainAllowedValues => Definition.ReviewDefinition.DomainAllowedValues;

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string ReviewStatus => Definition.ReviewDefinition.Status;

        /// <inheritdoc />
        public IEnumerable<string> ReviewStatusAllowedValues => Definition.ReviewDefinition.StatusAllowedValues;

        /// <inheritdoc />
        public IStatusItem ReviewStatusItem => Definition.ReviewDefinition.StatusItem;

        /// <inheritdoc />
        public IEnumerable<IStatusItem> ReviewStatusItems => Definition.ReviewDefinition.StatusItems;

        /// <summary>
        /// レビュー形式
        /// </summary>
        public string ReviewStyle => Definition.ReviewDefinition.ReviewStyle;

        /// <inheritdoc />
        public IEnumerable<string> ReviewStyleAllowedValues => Definition.ReviewDefinition.ReviewStyleAllowedValues;

        #endregion

        #region 予実

        /// <summary>
        /// 計画実施日の文字列
        /// </summary>
        [XmlElement("PlannedDate")]
        public string PlannedDateString { get; set; }

        /// <summary>
        /// 計画実施日
        /// </summary>
        public DateTime? PlannedDate => string.IsNullOrEmpty(PlannedDateString) ? (DateTime?) null : DateTime.Parse(PlannedDateString);

        /// <summary>
        /// 実績実施日の文字列
        /// </summary>
        [XmlElement("ActualDate")]
        public string ActualDateString { get; set; }

        /// <summary>
        /// 実績実施日
        /// </summary>
        public DateTime? ActualDate => string.IsNullOrEmpty(ActualDateString) ? (DateTime?) null : DateTime.Parse(ActualDateString);

        /// <summary>
        /// 計画時間（分単位）
        /// </summary>
        [XmlElement]
        public string PlannedTime { get; set; }

        /// <summary>
        /// 実績時間(分単位)
        /// </summary>
        [XmlElement]
        public string ActualTime { get; set; }

        /// <summary>
        /// 成果物単位
        /// </summary>
        [XmlElement]
        public string Unit { get; set; }

        /// <summary>
        /// 予定規模
        /// </summary>
        [XmlElement]
        public string PlannedScale { get; set; }

        /// <summary>
        /// 実績規模
        /// </summary>
        [XmlElement]
        public string ActualScale { get; set; }

        /// <summary>
        /// 目標件数
        /// </summary>
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

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
        [XmlArray("Documents")]
        [XmlArrayItem("Document")]
        public List<Document> DocumentEntities { get; set; }

        /// <summary>
        /// このレビューファイルに関連づく指摘の一覧
        /// </summary>
        [XmlArray("Issues")]
        [XmlArrayItem("Issue")]
        public List<Issue> IssueEntities { get; set; }

        #endregion

        #region カスタムフィールド

        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        /// <remarks>
        /// カスタムテキスト1以降の定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// カスタムテキストの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        public string CustomText1 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        public string CustomText2 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        public string CustomText3 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        public string CustomText4 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        public string CustomText5 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト6
        /// </summary>
        public string CustomText6 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト7
        /// </summary>
        public string CustomText7 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト8
        /// </summary>
        public string CustomText8 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト9
        /// </summary>
        public string CustomText9 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト10
        /// </summary>
        public string CustomText10 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト11
        /// </summary>
        public string CustomText11 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト12
        /// </summary>
        public string CustomText12 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト13
        /// </summary>
        public string CustomText13 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト14
        /// </summary>
        public string CustomText14 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト15
        /// </summary>
        public string CustomText15 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト16
        /// </summary>
        public string CustomText16 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト17
        /// </summary>
        public string CustomText17 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト18
        /// </summary>
        public string CustomText18 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト19
        /// </summary>
        public string CustomText19 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト20
        /// </summary>
        public string CustomText20 { get; set; } = string.Empty;

        #endregion

        #region 指摘のプロパティの定義

        /// <summary>
        /// 修正方針ステータスを使用するか
        /// </summary>
        [XmlElement("UseCorrectionPolicyStatus")]
        public string UseCorrectionPolicyStatusString { get; set; }

        /// <inheritdoc />
        public bool UseCorrectionPolicyStatus => bool.TryParse(UseCorrectionPolicyStatusString, out var result) ? result : false;

        /// <summary>
        /// 指摘理由を記録するか
        /// </summary>
        [XmlElement("UseReason")]
        public string UseReasonString { get; set; }

        /// <inheritdoc />
        public bool UseReason => bool.TryParse(UseReasonString, out var result) ? result : false;

        /// <inheritdoc />
        public string CategoryDefaultValue => Definition.IssueDefinition.CategoryDefaultValue;

        /// <inheritdoc />
        public IEnumerable<string> CategoryAllowedValues => Definition.IssueDefinition.CategoryAllowedValues;

        /// <inheritdoc />
        public string DetectionActivityDefaultValue => Definition.IssueDefinition.DetectionActivityDefaultValue;

        /// <inheritdoc />
        public IEnumerable<string> DetectionActivityAllowedValues => Definition.IssueDefinition.DetectionActivityAllowedValues;

        /// <inheritdoc />
        public string InjectionActivityDefaultValue => Definition.IssueDefinition.InjectionActivityDefaultValue;

        /// <inheritdoc />
        public IEnumerable<string> InjectionActivityAllowedValues => Definition.IssueDefinition.InjectionActivityAllowedValues;

        #endregion

        #region カスタムフィールドの定義

        /// <inheritdoc />
        public IEnumerable<IReviewCustomFieldDefinition> ReviewCustomFieldDefinitions => new List<IReviewCustomFieldDefinition>();

        /// <inheritdoc />
        public IEnumerable<IMemberCustomRoleDefinition> MemberCustomRoleDefinitions => new List<IMemberCustomRoleDefinition>();

        /// <inheritdoc />
        public IEnumerable<IMemberCustomFieldDefinition> MemberCustomFieldDefinitions => new List<IMemberCustomFieldDefinition>();

        /// <inheritdoc />
        public IEnumerable<IIssueCustomFieldDefinition> IssueCustomFieldDefinitions => Definition.IssueDefinition.CustomFieldDefinitions;

        #endregion

        #endregion
    }
}
