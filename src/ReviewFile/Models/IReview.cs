using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// レビューのインタフェース
    /// </summary>
    public interface IReview
    {
        #region 公開プロパティ

        /// <summary>
        /// グローバルID
        /// </summary>
        string GID { get; }

        /// <summary>
        /// レビューファイルの絶対パス
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// このレビューファイルに関連づく指摘の一覧
        /// </summary>
        IEnumerable<IIssue> Issues { get; }

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
        IEnumerable<IDocument> Documents { get; }

        /// <summary>
        /// メンバ情報の一覧
        /// </summary>
        IEnumerable<IReviewMember> Members { get; }

        /// <summary>
        /// 作成者
        /// </summary>
        string CreatedBy { get; }
        
        /// <summary>
        /// 作成日時
        /// </summary>
        DateTime? CreatedDateTime { get; }

        /// <summary>
        /// 最終更新者
        /// </summary>
        string LastUpdatedBy { get; }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        DateTime? LastUpdatedDateTime { get; }

        #region 基本設定

        /// <summary>
        /// レビュー名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 目的
        /// </summary>
        string Goal { get; }

        /// <summary>
        /// 終了条件
        /// </summary>
        string EndCondition { get; }

        /// <summary>
        /// 場所
        /// </summary>
        string Place { get; }

        /// <summary>
        /// プロジェクトコード
        /// </summary>
        string ProjectCode { get; }

        /// <summary>
        /// プロジェクト名
        /// </summary>
        string ProjectName { get; }
        
        /// <summary>
        /// レビュー種別
        /// </summary>
        string ReviewType { get; }

        /// <summary>
        /// レビュー種別の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> ReviewTypeAllowedValues { get; }

        /// <summary>
        /// ドメイン
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// ドメインの選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> DomainAllowedValues { get; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        string ReviewStatus { get; }

        /// <summary>
        /// ステータスの選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> ReviewStatusAllowedValues { get; }

        /// <summary>
        /// 現在設定されているレビューのステータス
        /// </summary>
        IStatusItem ReviewStatusItem { get; } 

        /// <summary>
        /// ステータスの定義の一覧
        /// </summary>
        IEnumerable<IStatusItem> StatusItems { get; }

        /// <summary>
        /// レビュー形式
        /// </summary>
        string ReviewStyle { get; }

        /// <summary>
        /// レビュー形式の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> ReviewStyleAllowedValues { get; }

        #endregion

        #region 予実

        /// <summary>
        /// 計画実施日
        /// </summary>
        DateTime? PlannedDate { get; }

        /// <summary>
        /// 実績実施日
        /// </summary>
        DateTime? ActualDate { get; }

        /// <summary>
        /// 計画時間（分単位）
        /// </summary>
        string PlannedTime { get; }

        /// <summary>
        /// 実績時間(分単位)
        /// </summary>
        string ActualTime { get; }

        /// <summary>
        /// 成果物単位
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// 予定規模
        /// </summary>
        string PlannedScale { get; }

        /// <summary>
        /// 実績規模
        /// </summary>
        string ActualScale { get; }

        /// <summary>
        /// 目標件数
        /// </summary>
        string IssueCountOfGoal { get; }

        /// <summary>
        /// 実績件数
        /// </summary>
        string IssueCountOfActual { get; }

        #endregion

        #region カスタムフィールド
        
        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        string CustomText1 { get; }

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        string CustomText2 { get; }

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        string CustomText3 { get; }

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        string CustomText4 { get; }

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        string CustomText5 { get; }

        /// <summary>
        /// カスタムテキスト6
        /// </summary>
        string CustomText6 { get; }

        /// <summary>
        /// カスタムテキスト7
        /// </summary>
        string CustomText7 { get; }

        /// <summary>
        /// カスタムテキスト8
        /// </summary>
        string CustomText8 { get; }

        /// <summary>
        /// カスタムテキスト9
        /// </summary>
        string CustomText9 { get; }

        /// <summary>
        /// カスタムテキスト10
        /// </summary>
        string CustomText10 { get; }

		/// <summary>
        /// カスタムテキスト11
        /// </summary>
        string CustomText11 { get; }

        /// <summary>
        /// カスタムテキスト12
        /// </summary>
        string CustomText12 { get; }

        /// <summary>
        /// カスタムテキスト13
        /// </summary>
        string CustomText13 { get; }

        /// <summary>
        /// カスタムテキスト14
        /// </summary>
        string CustomText14 { get; } 

        /// <summary>
        /// カスタムテキスト15
        /// </summary>
        string CustomText15 { get; } 

        /// <summary>
        /// カスタムテキスト16
        /// </summary>
        string CustomText16 { get; } 

        /// <summary>
        /// カスタムテキスト17
        /// </summary>
        string CustomText17 { get; } 

        /// <summary>
        /// カスタムテキスト18
        /// </summary>
        string CustomText18 { get; } 

        /// <summary>
        /// カスタムテキスト19
        /// </summary>
        string CustomText19 { get; }

        /// <summary>
        /// カスタムテキスト20
        /// </summary>
        string CustomText20 { get; }

        #endregion

        #region 指摘のプロパティの定義

        /// <summary>
        /// 修正方針ステータスを使用するか
        /// </summary>
        string UseCorrectionPolicyStatus { get; }

        /// <summary>
        /// 指摘理由を記録するか
        /// </summary>
        string UseReason { get; }

        /// <summary>
        /// 分類のデフォルト値
        /// </summary>
        string CategoryDefaultValue { get; }

        /// <summary>
        /// 分類の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> CategoryAllowedValues { get; }

        /// <summary>
        /// 検出工程のデフォルト値
        /// </summary>
        string DetectionActivityDefaultValue { get; }

        /// <summary>
        /// 検出工程の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> DetectionActivityAllowedValues { get; }

        /// <summary>
        /// 原因工程のデフォルト値
        /// </summary>
        string InjectionActivityDefaultValue { get; }

        /// <summary>
        /// 原因工程の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> InjectionActivityAllowedValues { get; }

        #endregion

        #region カスタムフィールドの定義

        /// <summary>
        /// レビューのカスタムフィールドの定義
        /// </summary>
        IEnumerable<IReviewCustomFieldDefinition> ReviewCustomFieldDefinitions { get; }

        /// <summary>
        /// メンバのカスタムロールの定義
        /// </summary>
        IEnumerable<IMemberCustomRoleDefinition> MemberCustomRoleDefinitions { get; }

        /// <summary>
        /// メンバのカスタムフィールドの定義
        /// </summary>
        IEnumerable<IMemberCustomFieldDefinition> MemberCustomFieldDefinitions { get; }

        /// <summary>
        /// 指摘のカスタムフィールドの定義
        /// </summary>
        IEnumerable<IIssueCustomFieldDefinition> IssueCustomFieldDefinitions { get; }

        #endregion

        #endregion
    }
}
