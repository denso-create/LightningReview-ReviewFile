using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions;
using DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.MemberDefinitions;
using DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// レビュー
    /// </summary>
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

                return issues;
            }
        }

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
        IEnumerable<IDocument> IReview.Documents => Documents.List.OfType<IDocument>();

        /// <inheritdoc />
        public IEnumerable<IReviewMember> Members => Definition.ReviewDefinition.Members.ListItems;

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
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
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

        /// <summary>
        /// 定義
        /// </summary>
        [XmlElement]
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
        public DateTime? PlannedDate => string.IsNullOrEmpty(PlannedDateString) ? (DateTime?)null : DateTime.Parse(PlannedDateString);

        /// <summary>
        /// 実績実施日の文字列
        /// </summary>
        [XmlElement("ActualDate")]
        public string ActualDateString { get; set; }

        /// <summary>
        /// 実績実施日
        /// </summary>
        public DateTime? ActualDate => string.IsNullOrEmpty(ActualDateString) ? (DateTime?)null : DateTime.Parse(ActualDateString);

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

        #endregion

        #region カスタムフィールド

        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        /// <remarks>
        /// カスタムテキスト1以降の定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// カスタムテキストの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        [XmlElement]
        public string CustomText1 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        [XmlElement]
        public string CustomText2 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        [XmlElement]
        public string CustomText3 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        [XmlElement]
        public string CustomText4 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        [XmlElement]
        public string CustomText5 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト6
        /// </summary>
        [XmlElement]
        public string CustomText6 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト7
        /// </summary>
        [XmlElement]
        public string CustomText7 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト8
        /// </summary>
        [XmlElement]
        public string CustomText8 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト9
        /// </summary>
        [XmlElement]
        public string CustomText9 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト10
        /// </summary>
        [XmlElement]
        public string CustomText10 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト11
        /// </summary>
        [XmlElement]
        public string CustomText11 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト12
        /// </summary>
        [XmlElement]
        public string CustomText12 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト13
        /// </summary>
        [XmlElement]
        public string CustomText13 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト14
        /// </summary>
        [XmlElement]
        public string CustomText14 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト15
        /// </summary>
        [XmlElement]
        public string CustomText15 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト16
        /// </summary>
        [XmlElement]
        public string CustomText16 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト17
        /// </summary>
        [XmlElement]
        public string CustomText17 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト18
        /// </summary>
        [XmlElement]
        public string CustomText18 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト19
        /// </summary>
        [XmlElement]
        public string CustomText19 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト20
        /// </summary>
        [XmlElement]
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
        public IEnumerable<string> InjectionActivityAllowedValues =>
            Definition.IssueDefinition.InjectionActivityAllowedValues;

        #endregion

        #region カスタムフィールドの定義

        /// <summary>
        /// レビューのカスタムフィールドの定義
        /// </summary>
        /// <remarks>
        /// LR2.0より前のバージョンでは、レビューのカスタムフィールドが存在しないため、ReviewDefinition.CustomFields.ReviewCustomFieldDefinitionsはnullとなる。
        /// そのため、空のリストを生成して返すように実装している。
        /// </remarks>
        public IEnumerable<IReviewCustomFieldDefinition> ReviewCustomFieldDefinitions => 
	        Definition.ReviewDefinition.CustomFields?.ReviewCustomFieldDefinitions ?? (new List<ReviewCustomFieldDefinition>());

        /// <summary>
        /// メンバのカスタムロールの定義
        /// </summary>
        /// <remarks>
        /// LR2.0より前のバージョンでは、メンバーの定義が存在しないため、MemberDefinitionはnullとなる。
        /// そのため、空のリストを生成して返すように実装している。
        /// </remarks>
        public IEnumerable<IMemberCustomRoleDefinition> MemberCustomRoleDefinitions =>
            Definition.MemberDefinition?.CustomRoles.MemberCustomRoleDefinitions ?? (new List<MemberCustomRoleDefinition>());

        /// <summary>
        /// メンバのカスタムフィールドの定義
        /// </summary>
        /// <remarks>
        /// LR2.0より前のバージョンでは、メンバーの定義が存在しないため、MemberDefinitionはnullとなる。
        /// そのため、空のリストを生成して返すように実装している。
        /// </remarks>
        public IEnumerable<IMemberCustomFieldDefinition> MemberCustomFieldDefinitions => 
	        Definition.MemberDefinition?.CustomFields.MemberCustomFieldDefinitions ?? (new List<MemberCustomFieldDefinition>());

        /// <summary>
        /// 指摘のカスタムフィールドの定義
        /// </summary>
        public IEnumerable<IIssueCustomFieldDefinition> IssueCustomFieldDefinitions => Definition.IssueDefinition.CustomFieldDefinitions;

        #endregion

        #endregion
    }
}
