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
        string GID { get; }

        /// <summary>
        /// ローカルIDを取得します。
        /// </summary>
        string LID { get; }

        /// <summary>
        /// 対象ドキュメントを取得します。
        /// </summary>
        IDocument Document { get; }

        /// <summary>
        /// 対象ドキュメントのIDを取得します。
        /// </summary>
        string DocumentID { get; }

        /// <summary>
        /// 関連づいているアウトラインノードを取得します。
        /// </summary>
        IOutlineNode OutlineNode { get; }

        /// <summary>
        /// タイプを取得します。
        /// </summary>
        string Type { get; }

        /// <summary>
        /// 修正方針を取得します。
        /// </summary>
        string CorrectionPolicy { get; }

        /// <summary>
        /// 分類を取得します。
        /// </summary>
        string Category { get; }

        /// <summary>
        /// 説明を取得します。
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 指摘理由を取得します。
        /// </summary>
        string Reason { get; }

        /// <summary>
        /// 差し戻し理由を取得します。
        /// </summary>
        string SendingBackReason{ get; }

        /// <summary>
        /// 指摘のステータスを取得します。
        /// </summary>
        string Status { get; }

        /// <summary>
        /// 現在差戻し中かどうかを取得します。
        /// </summary>
        bool IsSendingBack { get; }

        /// <summary>
        /// 過去に一度でも差し戻しがあったかを取得します。
        /// </summary>
        bool HasBeenSentBack { get; }
        
        /// <summary>
        /// 検出工程を取得します。
        /// </summary>
        string DetectionActivity { get; }

        /// <summary>
        /// 原因工程を取得します。
        /// </summary>
        string InjectionActivity { get; }

        /// <summary>
        /// 優先度を取得します。
        /// </summary>
        string Priority { get; }

        /// <summary>
        /// 重大度を取得します。
        /// </summary>
        string Importance { get; }

        /// <summary>
        /// 関連づいているアウトラインノードの名前を取得します。
        /// </summary>
       string OutlineName { get; }

        /// <summary>
        /// ルートレベルのアウトラインノードの名前を取得します。
        /// </summary>
        string RootOutlineName { get; }

        /// <summary>
        /// アウトラインノードのパスを取得します。
        /// </summary>
        string OutlinePath { get; }

        /// <summary>
        /// 報告者を取得します。
        /// </summary>
        string ReportedBy { get; }

        /// <summary>
        /// 報告日を取得します。
        /// </summary>
        DateTime? DateReported { get; }

        /// <summary>
        /// 対策要否を取得します。
        /// </summary>
        string NeedToFix { get; }

        /// <summary>
        /// 修正者を取得します。
        /// </summary>
        string AssignedTo { get; }

        /// <summary>
        /// 期日を取得します。
        /// </summary>
        DateTime? DueDate { get; }
        
        /// <summary>
        /// 修正日を取得します。
        /// </summary>
        DateTime? DateFixed { get; }

        /// <summary>
        /// 対策を取得します。
        /// </summary>
        string Resolution { get; }

        /// <summary>
        /// 確認者を取得します。
        /// </summary>
        string ConfirmedBy { get; }

        /// <summary>
        /// 確認日を取得します。
        /// </summary>
        DateTime? DateConfirmed { get; }

        /// <summary>
        /// コメントを取得します。
        /// </summary>
        string Comment { get; }
        
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
    }
}
