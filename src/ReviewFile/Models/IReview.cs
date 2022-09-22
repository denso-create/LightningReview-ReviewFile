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
        /// <value>グローバルID。</value>
        string GID { get; }

        /// <summary>
        /// レビューファイルの絶対パスを取得します。
        /// </summary>
        /// <value>レビューファイルの絶対パス。</value>
        string FilePath { get; }

        /// <summary>
        /// このレビューファイルに関連づく指摘の一覧を取得します。
        /// </summary>
        /// <value>指摘の一覧。関連づく指摘がない時は、要素数0のコレクションです。</value>
        IEnumerable<IIssue> Issues { get; }

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧を取得します。
        /// </summary>
        /// <value>ドキュメントの一覧。関連づくドキュメントがない時は、要素数0のコレクションです。</value>
        IEnumerable<IDocument> Documents { get; }

        /// <summary>
        /// メンバ情報の一覧を取得します。
        /// </summary>
        /// <value>メンバ情報の一覧。</value>
        IEnumerable<IReviewMember> Members { get; }

        /// <summary>
        /// 作成者を取得します。
        /// </summary>
        /// <value>作成者。</value>
        string CreatedBy { get; }

        /// <summary>
        /// 作成日時を取得します。
        /// </summary>
        /// <value>作成日時。</value>
        DateTime? CreatedDateTime { get; }

        /// <summary>
        /// 最終更新者を取得します。
        /// </summary>
        /// <value>最終更新者。</value>
        string LastUpdatedBy { get; }

        /// <summary>
        /// 最終更新日時を取得します。
        /// </summary>
        /// <value>最終更新日時。</value>
        DateTime? LastUpdatedDateTime { get; }

        #region 基本設定

        /// <summary>
        /// レビュー名を取得します。
        /// </summary>
        /// <value>レビュー名。</value>
        string Name { get; }

        /// <summary>
        /// 目的を取得します。
        /// </summary>
        /// <value>目的。</value>
        string Goal { get; }

        /// <summary>
        /// 終了条件を取得します。
        /// </summary>
        /// <value>終了条件。</value>
        string EndCondition { get; }

        /// <summary>
        /// 場所を取得します。
        /// </summary>
        /// <value>場所。</value>
        string Place { get; }

        /// <summary>
        /// プロジェクトコードを取得します。
        /// </summary>
        /// <value>プロジェクトコード。</value>
        string ProjectCode { get; }

        /// <summary>
        /// プロジェクト名を取得します。
        /// </summary>
        /// <value>プロジェクト名。</value>
        string ProjectName { get; }

        /// <summary>
        /// レビュー種別を取得します。
        /// </summary>
        /// <value>レビュー種別。</value>
        string ReviewType { get; }

        /// <summary>
        /// レビュー種別の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>レビュー種別の選択肢一覧。選択肢が定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<string> ReviewTypeAllowedValues { get; }

        /// <summary>
        /// ドメインを取得します。
        /// </summary>
        /// <value>ドメイン。</value>
        string Domain { get; }

        /// <summary>
        /// ドメインの選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>ドメインの選択肢一覧。選択肢が定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<string> DomainAllowedValues { get; }

        /// <summary>
        /// 現在設定されているレビューのステータスの名前を取得します。
        /// </summary>
        /// <value>現在設定されているレビューのステータスの名前。現在のステータスが設定されていない時は空文字列です。</value>
        string ReviewStatus { get; }

        /// <summary>
        /// レビューのステータスの選択肢の名前一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の名前の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>レビューのステータスの選択肢の名前一覧。ステータスが定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<string> ReviewStatusAllowedValues { get; }

        /// <summary>
        /// 現在設定されているレビューのステータスを取得します。
        /// </summary>
        /// <value>現在設定されているレビューのステータス。現在のステータスが設定されていない時はnullです。</value>
        IStatusItem ReviewStatusItem { get; }

        /// <summary>
        /// レビューのステータスの選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>レビューのステータスの選択肢一覧。ステータスが定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<IStatusItem> ReviewStatusItems { get; }

        /// <summary>
        /// レビュー形式を取得します。
        /// </summary>
        /// <value>レビュー形式。</value>
        string ReviewStyle { get; }

        /// <summary>
        /// レビュー形式の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>レビュー形式の選択肢一覧。選択肢が定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<string> ReviewStyleAllowedValues { get; }

        #endregion

        #region 予実

        /// <summary>
        /// 計画実施日を取得します。
        /// </summary>
        /// <value>計画実施日。計画実施日が設定されていない時はnullです。</value>
        DateTime? PlannedDate { get; }

        /// <summary>
        /// 実績実施日を取得します。
        /// </summary>
        /// <value>実績実施日。実績実施日が設定されていない時はnullです。</value>
        DateTime? ActualDate { get; }

        /// <summary>
        /// 計画時間(分単位)を取得します。
        /// </summary>
        /// <value>計画時間(分単位)。</value>
        string PlannedTime { get; }

        /// <summary>
        /// 実績時間(分単位)を取得します。
        /// </summary>
        /// <value>実績時間(分単位)。</value>
        string ActualTime { get; }

        /// <summary>
        /// 成果物単位を取得します。
        /// </summary>
        /// <value>成果物単位。</value>
        string Unit { get; }

        /// <summary>
        /// 予定規模を取得します。
        /// </summary>
        /// <value>予定規模。</value>
        string PlannedScale { get; }

        /// <summary>
        /// 実績規模を取得します。
        /// </summary>
        /// <value>実績規模。</value>
        string ActualScale { get; }

        /// <summary>
        /// 目標件数を取得します。
        /// </summary>
        /// <value>目標件数。</value>
        string IssueCountOfGoal { get; }

        /// <summary>
        /// 実績件数を取得します。
        /// </summary>
        /// <value>実績件数。</value>
        string IssueCountOfActual { get; }

        #endregion

        #region カスタムフィールド

        /// <summary>
        /// カスタムテキスト1の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト1の値。</value>
        string CustomText1 { get; }

        /// <summary>
        /// カスタムテキスト2の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト2の値。</value>
        string CustomText2 { get; }

        /// <summary>
        /// カスタムテキスト3の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト3の値。</value>
        string CustomText3 { get; }

        /// <summary>
        /// カスタムテキスト4の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト4の値。</value>
        string CustomText4 { get; }

        /// <summary>
        /// カスタムテキスト5の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト5の値。</value>
        string CustomText5 { get; }

        /// <summary>
        /// カスタムテキスト6の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト6の値。</value>
        string CustomText6 { get; }

        /// <summary>
        /// カスタムテキスト7の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト7の値。</value>
        string CustomText7 { get; }

        /// <summary>
        /// カスタムテキスト8の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト8の値。</value>
        string CustomText8 { get; }

        /// <summary>
        /// カスタムテキスト9の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト9の値。</value>
        string CustomText9 { get; }

        /// <summary>
        /// カスタムテキスト10の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト10の値。</value>
        string CustomText10 { get; }

        /// <summary>
        /// カスタムテキスト11の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト11の値。</value>
        string CustomText11 { get; }

        /// <summary>
        /// カスタムテキスト12の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト12の値。</value>
        string CustomText12 { get; }

        /// <summary>
        /// カスタムテキスト13の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト13の値。</value>
        string CustomText13 { get; }

        /// <summary>
        /// カスタムテキスト14の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト14の値。</value>
        string CustomText14 { get; }

        /// <summary>
        /// カスタムテキスト15の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト15の値。</value>
        string CustomText15 { get; }

        /// <summary>
        /// カスタムテキスト16の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト16の値。</value>
        string CustomText16 { get; }

        /// <summary>
        /// カスタムテキスト17の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト17の値。</value>
        string CustomText17 { get; }

        /// <summary>
        /// カスタムテキスト18の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト18の値。</value>
        string CustomText18 { get; }

        /// <summary>
        /// カスタムテキスト19の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト19の値。</value>
        string CustomText19 { get; }

        /// <summary>
        /// カスタムテキスト20の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト20の値。</value>
        string CustomText20 { get; }

        #endregion

        #region 指摘のプロパティの定義

        /// <summary>
        /// 修正方針ステータスを使用するかを取得します。
        /// </summary>
        /// <value>修正方針ステータスを使用するか。</value>
        bool UseCorrectionPolicyStatus { get; }

        /// <summary>
        /// 指摘理由を記録するかを取得します。
        /// </summary>
        /// <value>指摘理由を記録するか。</value>
        bool UseReason { get; }

        /// <summary>
        /// 分類のデフォルト値を取得します。
        /// </summary>
        /// <value>分類のデフォルト値。デフォルト値が設定されていない時は空文字列です。</value>
        string CategoryDefaultValue { get; }

        /// <summary>
        /// 分類の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>分類の選択肢一覧。選択肢が定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<string> CategoryAllowedValues { get; }

        /// <summary>
        /// 検出工程のデフォルト値を取得します。
        /// </summary>
        /// <value>検出工程のデフォルト値。デフォルト値が設定されていない時は空文字列です。</value>
        string DetectionActivityDefaultValue { get; }

        /// <summary>
        /// 検出工程の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>検出工程の選択肢一覧。選択肢が定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<string> DetectionActivityAllowedValues { get; }

        /// <summary>
        /// 原因工程のデフォルト値を取得します。
        /// </summary>
        /// <value>原因工程のデフォルト値。デフォルト値が設定されていない時は空文字列です。</value>
        string InjectionActivityDefaultValue { get; }

        /// <summary>
        /// 原因工程の選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>原因工程の選択肢一覧。選択肢が定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<string> InjectionActivityAllowedValues { get; }

        #endregion

        #region カスタムフィールドの定義

        /// <summary>
        /// レビューのカスタムフィールドの定義を取得します。
        /// </summary>
        /// <value>
        /// レビューのカスタムフィールドの定義。
        /// レビューのカスタムフィールドが存在しない旧バージョンのレビューファイルでは、要素数0のコレクションです。
        /// </value>
        IEnumerable<IReviewCustomFieldDefinition> ReviewCustomFieldDefinitions { get; }

        /// <summary>
        /// メンバのカスタムロールの定義を取得します。
        /// </summary>
        /// <value>
        /// メンバのカスタムロールの定義。
        /// メンバのカスタムロールの定義が存在しない旧バージョンのレビューファイルでは、要素数0のコレクションです。
        /// </value>
        IEnumerable<IMemberCustomRoleDefinition> MemberCustomRoleDefinitions { get; }

        /// <summary>
        /// メンバのカスタムフィールドの定義を取得します。
        /// </summary>
        /// <value>
        /// メンバのカスタムフィールドの定義。
        /// メンバのカスタムフィールドの定義が存在しない旧バージョンのレビューファイルでは、要素数0のコレクションです。
        /// </value>
        IEnumerable<IMemberCustomFieldDefinition> MemberCustomFieldDefinitions { get; }

        /// <summary>
        /// 指摘のカスタムフィールドの定義を取得します。
        /// </summary>
        /// <value>指摘のカスタムフィールドの定義。</value>
        IEnumerable<IIssueCustomFieldDefinition> IssueCustomFieldDefinitions { get; }

        #endregion

        #endregion
    }
}
