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

        /// <inheritdoc />
        public string GID { get => GlobalID; set => GlobalID = value; }

        /// <inheritdoc />
        [XmlElement]
        public string CreatedBy { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string LastUpdatedBy { get; set; }

        /// <summary>
        /// 作成日時の文字列
        /// </summary>
        [XmlElement("CreatedDateTime")]
        public string CreatedDateTimeString { get; set; }

        /// <inheritdoc />
        public DateTime? CreatedDateTime => string.IsNullOrEmpty(CreatedDateTimeString) ? (DateTime?)null : DateTime.Parse(CreatedDateTimeString);

        /// <summary>
        /// 最終更新日時の文字列
        /// </summary>
        [XmlElement("LastUpdatedDateTime")]
        public string LastUpdatedDateTimeString { get; set; }

        /// <inheritdoc />
        public DateTime? LastUpdatedDateTime => string.IsNullOrEmpty(LastUpdatedDateTimeString) ? (DateTime?)null : DateTime.Parse(LastUpdatedDateTimeString);

        /// <inheritdoc />
        public string FilePath { get; set; }

        /// <inheritdoc />
        public IEnumerable<IIssue> Issues => IssueEntities;

        /// <inheritdoc />
        public IEnumerable<IDocument> Documents => DocumentEntities;

        /// <inheritdoc />
        public IEnumerable<IReviewMember> Members => Definition.ReviewDefinition.Members;

        #region 基本設定

        /// <inheritdoc />
        [XmlElement]
        public string Name { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Goal { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string EndCondition { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Place { get; set; }

        /// <summary>
        /// プロジェクト
        /// </summary>
        [XmlElement]
        public Project Project { get; set; }

        /// <inheritdoc />
        public string ProjectCode => Project.Code;

        /// <inheritdoc />
        public string ProjectName => Project.Name;

        /// <summary>
        /// 定義
        /// </summary>
        public Definition Definition { get; set; }

        /// <inheritdoc />
        public string ReviewType => Definition.ReviewDefinition.ReviewType;

        /// <inheritdoc />
        public IEnumerable<string> ReviewTypeAllowedValues => Definition.ReviewDefinition.ReviewTypeAllowedValues;

        /// <inheritdoc />
        public string Domain => Definition.ReviewDefinition.Domain;

        /// <inheritdoc />
        public IEnumerable<string> DomainAllowedValues => Definition.ReviewDefinition.DomainAllowedValues;

        /// <inheritdoc />
        public string ReviewStatus => Definition.ReviewDefinition.Status;

        /// <inheritdoc />
        public IEnumerable<string> ReviewStatusAllowedValues => Definition.ReviewDefinition.StatusAllowedValues;

        /// <inheritdoc />
        public IStatusItem ReviewStatusItem => Definition.ReviewDefinition.StatusItem;

        /// <inheritdoc />
        public IEnumerable<IStatusItem> ReviewStatusItems => Definition.ReviewDefinition.StatusItems;

        /// <inheritdoc />
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

        /// <inheritdoc />
        public DateTime? PlannedDate => string.IsNullOrEmpty(PlannedDateString) ? (DateTime?)null : DateTime.Parse(PlannedDateString);

        /// <summary>
        /// 実績実施日の文字列
        /// </summary>
        [XmlElement("ActualDate")]
        public string ActualDateString { get; set; }

        /// <inheritdoc />
        public DateTime? ActualDate => string.IsNullOrEmpty(ActualDateString) ? (DateTime?)null : DateTime.Parse(ActualDateString);

        /// <inheritdoc />
        [XmlElement]
        public string PlannedTime { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string ActualTime { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Unit { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string PlannedScale { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string ActualScale { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string IssueCountOfGoal { get; set; }

        /// <inheritdoc />
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

        /// <inheritdoc cref="Documents" />
        [XmlArray("Documents")]
        [XmlArrayItem("Document")]
        public List<Document> DocumentEntities { get; set; }

        /// <inheritdoc cref="Issues" />
        [XmlArray("Issues")]
        [XmlArrayItem("Issue")]
        public List<Issue> IssueEntities { get; set; }

        #endregion

        #region カスタムフィールド

        /// <inheritdoc />
        /// <remarks>
        /// V10ではカスタムテキスト1以降の定義が存在せず、nullとなる。
        /// カスタムテキストの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        public string CustomText1 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText2 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText3 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText4 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText5 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText6 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText7 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText8 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText9 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText10 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText11 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText12 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText13 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText14 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText15 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText16 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText17 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText18 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText19 { get; set; } = string.Empty;

        /// <inheritdoc />
        public string CustomText20 { get; set; } = string.Empty;

        #endregion

        #region 指摘のプロパティの定義

        /// <inheritdoc cref="UseCorrectionPolicyStatus" />
        [XmlElement("UseCorrectionPolicyStatus")]
        public string UseCorrectionPolicyStatusString { get; set; }

        /// <inheritdoc />
        public bool UseCorrectionPolicyStatus => bool.TryParse(UseCorrectionPolicyStatusString, out var result) ? result : false;

        /// <inheritdoc cref="UseReason" />
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
