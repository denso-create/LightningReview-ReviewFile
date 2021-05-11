using System;
using System.Collections.Generic;
using System.Text;
using DensoCreate.LightningReview.ReviewFile.Models;
using DensoCreate.LightningReview.ReviewFileToJsonService.Extensions;

namespace DensoCreate.LightningReview.ReviewFileToJsonService
{
    /// <summary>
    /// 指摘
    /// </summary>
    public class Issue 
    {
        #region 構築

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Issue()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="issue"></param>
        public Issue(IIssue issue)
        {
            // フィールドをコピー
            this.CopyFieldsFrom(issue);
        }

        #endregion
        
        #region 公開プロパティ

        /// <summary>
        /// グローバルID
        /// </summary>
        public　string GID { get; set; }

        /// <summary>
        /// ローカルID
        /// </summary>
        public string LID { get; set; }

        /// <summary>
        /// タイプ
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 修正方針
        /// </summary>
        public string CorrectionPolicy { get; set; }

        /// <summary>
        /// 分類
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 指摘理由
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 差し戻し理由
        /// </summary>
        public string SendingBackReason{ get; set; }

        /// <summary>
        /// 指摘のステータス
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 現在差戻し中かどうか
        /// </summary>
        public string IsSendingBack { get; set; }

        /// <summary>
        /// 過去に一度でも差し戻しがあったか
        /// </summary>
        public string HasBeenSentBack { get; set; }
        
        /// <summary>
        /// 検出工程
        /// </summary>
        public string DetectionActivity { get; set; }

        /// <summary>
        /// 原因工程
        /// </summary>
        public string InjectionActivity { get; set; }

        /// <summary>
        /// 優先度
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// 重大度
        /// </summary>
        public string Importance { get; set; }

        /// <summary>
        /// 関連付けられているアウトラインノードの名前
        /// </summary>
        public string OutlineName { get; set; }

        /// <summary>
        /// ルートレベルのアウトラインノードの名前
        /// </summary>
        public string RootOutlineName { get; set; }

        /// <summary>
        /// アウトラインノードのパス
        /// </summary>
        public string OutlinePath { get; set; }

        /// <summary>
        /// 報告者
        /// </summary>
        public string ReportedBy { get; set; }

        /// <summary>
        /// 報告日
        /// </summary>
        public DateTime? DateReported { get; set; }

        /// <summary>
        /// 対策要否
        /// </summary>
        public string NeedToFix { get; set; }

        /// <summary>
        /// 修正者
        /// </summary>
        public string AssignedTo { get; set; }

        /// <summary>
        /// 期日
        /// </summary>
        public DateTime? DueDate { get; set; }
        
        /// <summary>
        /// 修正日
        /// </summary>
        public DateTime? DateFixed { get; set; }

        /// <summary>
        /// 対策
        /// </summary>
        public string Resolution { get; set; }

        /// <summary>
        /// 確認者
        /// </summary>
        public string ConfirmedBy { get; set; }

        /// <summary>
        /// 確認日
        /// </summary>
        public DateTime? DateConfirmed { get; set; }

        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get; set; }
        
        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        public string CustomText1 { get; set; }

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        public string CustomText2 { get; set; }

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        public string CustomText3 { get; set; }

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        public string CustomText4 { get; set; }

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        public string CustomText5 { get; set; }

        /// <summary>
        /// カスタムテキスト6
        /// </summary>
        public string CustomText6 { get; set; }

        /// <summary>
        /// カスタムテキスト7
        /// </summary>
        public string CustomText7 { get; set; }

        /// <summary>
        /// カスタムテキスト8
        /// </summary>
        public string CustomText8 { get; set; }

        /// <summary>
        /// カスタムテキスト9
        /// </summary>
        public string CustomText9 { get; set; }

        /// <summary>
        /// カスタムテキスト10
        /// </summary>
        public string CustomText10 { get; set; }

        #endregion
    }
}
