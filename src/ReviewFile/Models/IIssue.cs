using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// 指摘のインタフェースです。
    /// </summary>
    public interface IIssue
    {
        #region 公開プロパティ

        /// <summary>
        /// グローバルIDを取得します。
        /// </summary>
        /// <value>グローバルID。</value>
        string GID { get; }

        /// <summary>
        /// ローカルIDを取得します。
        /// </summary>
        /// <value>ローカルID。</value>
        string LID { get; }

        /// <summary>
        /// 対象ドキュメントを取得します。
        /// </summary>
        /// <value>対象ドキュメント。</value>
        IDocument Document { get; }

        /// <summary>
        /// 対象ドキュメントのIDを取得します。
        /// </summary>
        /// <value>対象ドキュメントのID。</value>
        string DocumentID { get; }

        /// <summary>
        /// 関連づいているアウトラインノードを取得します。
        /// </summary>
        /// <value>関連づいているアウトラインノード。この指摘がドキュメント直下にある時はnullです。</value>
        IOutlineNode OutlineNode { get; }

        /// <summary>
        /// タイプを取得します。
        /// </summary>
        /// <value>
        /// タイプ。
        /// 本プロパティの値域を以下に示します。
        /// [値域]
        /// 不具合
        /// 指摘
        /// グッドポイント
        /// </value>
        string Type { get; }

        /// <summary>
        /// 修正方針を取得します。
        /// </summary>
        /// <value>修正方針。</value>
        string CorrectionPolicy { get; }

        /// <summary>
        /// 分類を取得します。
        /// </summary>
        /// <value>分類。</value>
        string Category { get; }

        /// <summary>
        /// 説明を取得します。
        /// </summary>
        /// <value>説明。</value>
        string Description { get; }

        /// <summary>
        /// 指摘理由を取得します。
        /// </summary>
        /// <value>指摘理由。</value>
        string Reason { get; }

        /// <summary>
        /// 差し戻し理由を取得します。
        /// </summary>
        /// <value>差し戻し理由。</value>
        string SendingBackReason { get; }

        /// <summary>
        /// 指摘のステータスを取得します。
        /// </summary>
        /// <value>
        /// 指摘のステータス。
        /// 本プロパティの値域を以下に示します。
        /// [値域]
        /// 未修正
        /// 修正方針検討済み
        /// 修正方針承認済み
        /// 修正済み
        /// 確認済み
        /// </value>
        string Status { get; }

        /// <summary>
        /// 現在差戻し中かどうかを取得します。
        /// </summary>
        /// <value>
        /// 現在差戻し中かどうか。
        /// </value>
        bool IsSendingBack { get; }

        /// <summary>
        /// 過去に一度でも差し戻しがあったかを取得します。
        /// </summary>
        /// <value>
        /// 過去に一度でも差し戻しがあったか。
        /// </value>
        bool HasBeenSentBack { get; }

        /// <summary>
        /// 検出工程を取得します。
        /// </summary>
        /// <value>検出工程。</value>
        string DetectionActivity { get; }

        /// <summary>
        /// 原因工程を取得します。
        /// </summary>
        /// <value>原因工程。</value>
        string InjectionActivity { get; }

        /// <summary>
        /// 優先度を取得します。
        /// </summary>
        /// <value>
        /// 優先度。
        /// 本プロパティの値域を以下に示します。
        /// [値域]
        /// 低
        /// 中
        /// 高
        /// </value>
        string Priority { get; }

        /// <summary>
        /// 重大度を取得します。
        /// </summary>
        /// <value>
        /// 重大度。
        /// 本プロパティの値域を以下に示します。
        /// [値域]
        /// 低
        /// 中
        /// 高
        /// </value>
        string Importance { get; }

        /// <summary>
        /// 関連づいているアウトラインノードの名前を取得します。
        /// </summary>
        /// <value>関連づいているアウトラインノードの名前。</value>
        string OutlineName { get; }

        /// <summary>
        /// ルートレベルのアウトラインノードの名前を取得します。
        /// </summary>
        /// <value>ルートレベルのアウトラインノードの名前。</value>
        string RootOutlineName { get; }

        /// <summary>
        /// アウトラインノードのパスを取得します。
        /// </summary>
        /// <value>アウトラインノードのパス。</value>
        string OutlinePath { get; }

        /// <summary>
        /// 報告者を取得します。
        /// </summary>
        /// <value>報告者。</value>
        string ReportedBy { get; }

        /// <summary>
        /// 報告日を取得します。
        /// </summary>
        /// <value>報告日。報告日が設定されていない時はnullです。</value>
        DateTime? DateReported { get; }

        /// <summary>
        /// 対策要否を取得します。
        /// </summary>
        /// <value>
        /// 対策要否。
        /// 本プロパティの値域を以下に示します。
        /// [値域]
        /// はい
        /// いいえ
        /// 保留
        /// </value>
        string NeedToFix { get; }

        /// <summary>
        /// 修正者を取得します。
        /// </summary>
        /// <value>修正者。</value>
        string AssignedTo { get; }

        /// <summary>
        /// 期日を取得します。
        /// </summary>
        /// <value>期日。期日が設定されていない時はnullです。</value>
        DateTime? DueDate { get; }

        /// <summary>
        /// 修正日を取得します。
        /// </summary>
        /// <value>修正日。修正日が設定されていない時はnullです。</value>
        DateTime? DateFixed { get; }

        /// <summary>
        /// 対策を取得します。
        /// </summary>
        /// <value>対策。</value>
        string Resolution { get; }

        /// <summary>
        /// 確認者を取得します。
        /// </summary>
        /// <value>確認者。</value>
        string ConfirmedBy { get; }

        /// <summary>
        /// 確認日を取得します。
        /// </summary>
        /// <value>確認日。確認日が設定されていない時はnullです。</value>
        DateTime? DateConfirmed { get; }

        /// <summary>
        /// コメントを取得します。
        /// </summary>
        /// <value>コメント。</value>
        string Comment { get; }

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
    }
}
