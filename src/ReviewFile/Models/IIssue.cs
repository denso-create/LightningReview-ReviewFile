using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// 指摘のインタフェース
    /// </summary>
    public interface IIssue
    {
        #region 公開プロパティ

        /// <summary>
        /// グローバルID
        /// </summary>
        string GID { get; }

        /// <summary>
        /// ローカルID
        /// </summary>
        string LID { get; }

        /// <summary>
        /// 対象ドキュメント
        /// </summary>
        IDocument Document { get; }

        /// <summary>
        /// 対象ドキュメントのID
        /// </summary>
        string DocumentID { get; }

        /// <summary>
        /// 関連付けられているアウトラインノード
        /// </summary>
        IOutlineNode OutlineNode { get; }

        /// <summary>
        /// タイプ
        /// </summary>
        string Type { get; }

        /// <summary>
        /// 修正方針
        /// </summary>
        string CorrectionPolicy { get; }

        /// <summary>
        /// 分類
        /// </summary>
        string Category { get; }

        /// <summary>
        /// 説明
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 指摘理由
        /// </summary>
        string Reason { get; }

        /// <summary>
        /// 差し戻し理由
        /// </summary>
        string SendingBackReason{ get; }

        /// <summary>
        /// 指摘のステータス
        /// </summary>
        string Status { get; }

        /// <summary>
        /// 現在差戻し中かどうか
        /// </summary>
        string IsSendingBack { get; }

        /// <summary>
        /// 過去に一度でも差し戻しがあったか
        /// </summary>
        string HasBeenSentBack { get; }
        
        /// <summary>
        /// 検出工程
        /// </summary>
        string DetectionActivity { get; }

        /// <summary>
        /// 原因工程
        /// </summary>
        string InjectionActivity { get; }

        /// <summary>
        /// 優先度
        /// </summary>
        string Priority { get; }

        /// <summary>
        /// 重大度
        /// </summary>
        string Importance { get; }

        /// <summary>
        /// 関連付けられているアウトラインノードの名前
        /// </summary>
       string OutlineName { get; }

        /// <summary>
        /// ルートレベルのアウトラインノードの名前
        /// </summary>
        string RootOutlineName { get; }

        /// <summary>
        /// アウトラインノードのパス
        /// </summary>
        string OutlinePath { get; }

        /// <summary>
        /// 報告者
        /// </summary>
        string ReportedBy { get; }

        /// <summary>
        /// 報告日
        /// </summary>
        DateTime? DateReported { get; }

        /// <summary>
        /// 対策要否
        /// </summary>
        string NeedToFix { get; }

        /// <summary>
        /// 修正者
        /// </summary>
        string AssignedTo { get; }

        /// <summary>
        /// 期日
        /// </summary>
        DateTime? DueDate { get; }
        
        /// <summary>
        /// 修正日
        /// </summary>
        DateTime? DateFixed { get; }

        /// <summary>
        /// 対策
        /// </summary>
        string Resolution { get; }

        /// <summary>
        /// 確認者
        /// </summary>
        string ConfirmedBy { get; }

        /// <summary>
        /// 確認日
        /// </summary>
        DateTime? DateConfirmed { get; }

        /// <summary>
        /// コメント
        /// </summary>
        string Comment { get; }
        
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
    }
}
