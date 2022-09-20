using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// レビューのインタフェースです。
    /// </summary>
    public interface IReview
    {
        #region 公開プロパティ

        /// <summary>
        /// グローバルIDを取得します。
        /// </summary>
        string GID { get; }

        /// <summary>
        /// レビューファイルの絶対パスを取得します。
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// このレビューファイルに関連づく指摘の一覧を取得します。
        /// </summary>
        IEnumerable<IIssue> Issues { get; }

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧を取得します。
        /// </summary>
        IEnumerable<IDocument> Documents { get; }

        /// <summary>
        /// メンバ情報の一覧を取得します。
        /// </summary>
        IEnumerable<IReviewMember> Members { get; }

        /// <summary>
        /// 作成者を取得します。
        /// </summary>
        string CreatedBy { get; }
        
        /// <summary>
        /// 作成日時を取得します。
        /// </summary>
        DateTime? CreatedDateTime { get; }

        /// <summary>
        /// 最終更新者を取得します。
        /// </summary>
        string LastUpdatedBy { get; }

        /// <summary>
        /// 最終更新日時を取得します。
        /// </summary>
        DateTime? LastUpdatedDateTime { get; }

        #region 基本設定

        /// <summary>
        /// レビュー名を取得します。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 目的を取得します。
        /// </summary>
        string Goal { get; }

        /// <summary>
        /// 終了条件を取得します。
        /// </summary>
        string EndCondition { get; }

        /// <summary>
        /// 場所を取得します。
        /// </summary>
        string Place { get; }

        /// <summary>
        /// プロジェクトコードを取得します。
        /// </summary>
        string ProjectCode { get; }

        /// <summary>
        /// プロジェクト名を取得します。
        /// </summary>
        string ProjectName { get; }
        
        /// <summary>
        /// レビュー種別を取得します。
        /// </summary>
        string ReviewType { get; }

        /// <summary>
        /// レビュー種別の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<string> ReviewTypeAllowedValues { get; }

        /// <summary>
        /// ドメインを取得します。
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// ドメインの選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<string> DomainAllowedValues { get; }

        /// <summary>
        /// 現在設定されているレビューのステータスの表示名を取得します。
        /// </summary>
        string ReviewStatus { get; }

        /// <summary>
        /// レビューのステータスの表示名の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<string> ReviewStatusAllowedValues { get; }

        /// <summary>
        /// 現在設定されているレビューのステータスを取得します。
        /// </summary>
        IStatusItem ReviewStatusItem { get; } 

        /// <summary>
        /// レビューのステータスの選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<IStatusItem> ReviewStatusItems { get; }

        /// <summary>
        /// レビュー形式を取得します。
        /// </summary>
        string ReviewStyle { get; }

        /// <summary>
        /// レビュー形式の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<string> ReviewStyleAllowedValues { get; }

        #endregion

        #region 予実

        /// <summary>
        /// 計画実施日を取得します。
        /// </summary>
        DateTime? PlannedDate { get; }

        /// <summary>
        /// 実績実施日を取得します。
        /// </summary>
        DateTime? ActualDate { get; }

        /// <summary>
        /// 計画時間（分単位）を取得します。
        /// </summary>
        string PlannedTime { get; }

        /// <summary>
        /// 実績時間(分単位)を取得します。
        /// </summary>
        string ActualTime { get; }

        /// <summary>
        /// 成果物単位を取得します。
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// 予定規模を取得します。
        /// </summary>
        string PlannedScale { get; }

        /// <summary>
        /// 実績規模を取得します。
        /// </summary>
        string ActualScale { get; }

        /// <summary>
        /// 目標件数を取得します。
        /// </summary>
        string IssueCountOfGoal { get; }

        /// <summary>
        /// 実績件数を取得します。
        /// </summary>
        string IssueCountOfActual { get; }

        #endregion

        #region カスタムフィールド
        
        /// <summary>
        /// カスタムテキスト1の値を取得します。
        /// </summary>
        string CustomText1 { get; }

        /// <summary>
        /// カスタムテキスト2の値を取得します。
        /// </summary>
        string CustomText2 { get; }

        /// <summary>
        /// カスタムテキスト3の値を取得します。
        /// </summary>
        string CustomText3 { get; }

        /// <summary>
        /// カスタムテキスト4の値を取得します。
        /// </summary>
        string CustomText4 { get; }

        /// <summary>
        /// カスタムテキスト5の値を取得します。
        /// </summary>
        string CustomText5 { get; }

        /// <summary>
        /// カスタムテキスト6の値を取得します。
        /// </summary>
        string CustomText6 { get; }

        /// <summary>
        /// カスタムテキスト7の値を取得します。
        /// </summary>
        string CustomText7 { get; }

        /// <summary>
        /// カスタムテキスト8の値を取得します。
        /// </summary>
        string CustomText8 { get; }

        /// <summary>
        /// カスタムテキスト9の値を取得します。
        /// </summary>
        string CustomText9 { get; }

        /// <summary>
        /// カスタムテキスト10の値を取得します。
        /// </summary>
        string CustomText10 { get; }

		/// <summary>
        /// カスタムテキスト11の値を取得します。
        /// </summary>
        string CustomText11 { get; }

        /// <summary>
        /// カスタムテキスト12の値を取得します。
        /// </summary>
        string CustomText12 { get; }

        /// <summary>
        /// カスタムテキスト13の値を取得します。
        /// </summary>
        string CustomText13 { get; }

        /// <summary>
        /// カスタムテキスト14の値を取得します。
        /// </summary>
        string CustomText14 { get; } 

        /// <summary>
        /// カスタムテキスト15の値を取得します。
        /// </summary>
        string CustomText15 { get; } 

        /// <summary>
        /// カスタムテキスト16の値を取得します。
        /// </summary>
        string CustomText16 { get; } 

        /// <summary>
        /// カスタムテキスト17の値を取得します。
        /// </summary>
        string CustomText17 { get; } 

        /// <summary>
        /// カスタムテキスト18の値を取得します。
        /// </summary>
        string CustomText18 { get; } 

        /// <summary>
        /// カスタムテキスト19の値を取得します。
        /// </summary>
        string CustomText19 { get; }

        /// <summary>
        /// カスタムテキスト20の値を取得します。
        /// </summary>
        string CustomText20 { get; }

        #endregion

        #region 指摘のプロパティの定義

        /// <summary>
        /// 修正方針ステータスを使用するかを取得します。
        /// </summary>
        bool UseCorrectionPolicyStatus { get; }

        /// <summary>
        /// 指摘理由を記録するかを取得します。
        /// </summary>
        bool UseReason { get; }

        /// <summary>
        /// 分類のデフォルト値を取得します。
        /// </summary>
        string CategoryDefaultValue { get; }

        /// <summary>
        /// 分類の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<string> CategoryAllowedValues { get; }

        /// <summary>
        /// 検出工程のデフォルト値を取得します。
        /// </summary>
        string DetectionActivityDefaultValue { get; }

        /// <summary>
        /// 検出工程の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<string> DetectionActivityAllowedValues { get; }

        /// <summary>
        /// 原因工程のデフォルト値を取得します。
        /// </summary>
        string InjectionActivityDefaultValue { get; }

        /// <summary>
        /// 原因工程の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<string> InjectionActivityAllowedValues { get; }

        #endregion

        #region カスタムフィールドの定義

        /// <summary>
        /// レビューのカスタムフィールドの定義を取得します。
        /// </summary>
        IEnumerable<IReviewCustomFieldDefinition> ReviewCustomFieldDefinitions { get; }

        /// <summary>
        /// メンバのカスタムロールの定義を取得します。
        /// </summary>
        IEnumerable<IMemberCustomRoleDefinition> MemberCustomRoleDefinitions { get; }

        /// <summary>
        /// メンバのカスタムフィールドの定義を取得します。
        /// </summary>
        IEnumerable<IMemberCustomFieldDefinition> MemberCustomFieldDefinitions { get; }

        /// <summary>
        /// 指摘のカスタムフィールドの定義を取得します。
        /// </summary>
        IEnumerable<IIssueCustomFieldDefinition> IssueCustomFieldDefinitions { get; }

        #endregion

        #endregion
    }
}
