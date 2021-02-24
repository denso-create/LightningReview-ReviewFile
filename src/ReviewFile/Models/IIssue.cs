using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Models
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
        string GID { get; set; }

        /// <summary>
        /// ローカルID
        /// </summary>
        string LID { get; set; }

        /// <summary>
        /// タイプ
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// 修正方針
        /// </summary>
        string CorrectionPolicy { get; set; }

        /// <summary>
        /// 分類
        /// </summary>
        string Category { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 指摘理由
        /// </summary>
        string Reason { get; set; }

        /// <summary>
        /// 差し戻し理由
        /// </summary>
        string SendingBackReason{ get; set; }

        /// <summary>
        /// 指摘のステータス
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// 現在差戻し中かどうか
        /// </summary>
        string IsSendingBack { get; set; }

        /// <summary>
        /// 過去に一度でも差し戻しがあったか
        /// </summary>
        string HasBeenSentBack { get; set; }
        
        /// <summary>
        /// 検出工程
        /// </summary>
        string DetectionActivity { get; set; }

        /// <summary>
        /// 原因工程
        /// </summary>
        string InjectionActivity { get; set; }

        /// <summary>
        /// 優先度
        /// </summary>
        string Priority { get; set; }

        /// <summary>
        /// 重大度
        /// </summary>
        string Importance { get; set; }

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
        string OutlinePath { get; set; }

        /// <summary>
        /// 報告者
        /// </summary>
        string ReportedBy { get; set; }

        /// <summary>
        /// 報告日
        /// </summary>
        DateTime? DateReported { get; }

        /// <summary>
        /// 対策要否
        /// </summary>
        string NeedToFix { get; set; }

        /// <summary>
        /// 修正者
        /// </summary>
        string AssignedTo { get; set; }

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
        string Resolution { get; set; }

        /// <summary>
        /// 確認者
        /// </summary>
        string ConfirmedBy { get; set; }

        /// <summary>
        /// 確認日
        /// </summary>
        DateTime? DateConfirmed { get; }

        /// <summary>
        /// コメント
        /// </summary>
        string Comment { get; set; }
        
        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        string CustomText1 { get; set; }

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        string CustomText2 { get; set; }

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        string CustomText3 { get; set; }

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        string CustomText4 { get; set; }

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        string CustomText5 { get; set; }

        /// <summary>
        /// カスタムテキスト6
        /// </summary>
        string CustomText6 { get; set; }

        /// <summary>
        /// カスタムテキスト7
        /// </summary>
        string CustomText7 { get; set; }

        /// <summary>
        /// カスタムテキスト8
        /// </summary>
        string CustomText8 { get; set; }

        /// <summary>
        /// カスタムテキスト9
        /// </summary>
        string CustomText9 { get; set; }

        /// <summary>
        /// カスタムテキスト10
        /// </summary>
        string CustomText10 { get; set; }
        
        #endregion
    }
}
