using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
	/// <summary>
	/// 指摘
	/// </summary>
    [XmlRoot]
    public class Issue : IIssue
    {
        #region プロパティ
        
        /// <summary>
        /// グローバルID（V10定義）
        /// </summary>
        [XmlAttribute]
        public string GlobalID { get; set; }

        /// <summary>
        /// グローバルID
        /// </summary>
        public string GID { get => GlobalID; set => GlobalID = value; }

        /// <summary>
        /// ローカルID（V10定義）
        /// </summary>
        [XmlAttribute]
        public string ID { get; set; }

        /// <summary>
        /// ローカルID
        /// </summary>
        public string LID { get=>ID; set=>ID=value; }

        /// <summary>
        /// タイプ
        /// </summary>
        [XmlElement]
        public string Type { get; set; }

        /// <summary>
        /// 修正方針
        /// </summary>
        [XmlElement]
        public string CorrectionPolicy { get; set; }

        /// <summary>
        /// 分類
        /// </summary>
        [XmlElement]
        public string Category { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        [XmlElement]
        public string Description { get; set; }

        /// <summary>
        /// 指摘理由
        /// </summary>
        [XmlElement]
        public string Reason { get; set; }

        /// <summary>
        /// 差し戻し理由
        /// </summary>
        [XmlElement]
        public string SendingBackReason { get; set; }

        /// <summary>
        /// 指摘のステータス
        /// </summary>
        [XmlElement]
        public string Status { get; set; }

        /// <summary>
        /// 現在差戻し中かどうか
        /// </summary>
        [XmlElement]
        public string IsSendingBack { get; set; }

        /// <summary>
        /// 過去に一度でも差し戻しがあったか
        /// </summary>
        [XmlElement]
        public string HasBeenSentBack { get; set; }
        
        /// <summary>
        /// 検出工程
        /// </summary>
        [XmlElement]
        public string DetectionActivity { get; set; }

        /// <summary>
        /// 原因工程
        /// </summary>
        [XmlElement]
        public string InjectionActivity { get; set; }

        /// <summary>
        /// 優先度
        /// </summary>
        [XmlElement]
        public string Priority { get; set; }

        /// <summary>
        /// 重大度
        /// </summary>
        [XmlElement]
        public string Importance { get; set; }

        /// <summary>
        /// 関連付けられているアウトラインノードの名前
        /// </summary>
        public string OutlineName {
            get
            {
                // アウトラインパスの末尾のアウトライン名を取得
                return OutlinePath.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries).Last();
            }
        }

        /// <summary>
        /// ルートレベルのアウトラインノードの名前
        /// </summary>
        public string RootOutlineName {
            get
            {
                // アウトラインパスの先頭のアウトライン名を取得
                return OutlinePath.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries).First();
            }
        }

        /// <summary>
        /// アウトラインノードのパス
        /// </summary>
        [XmlElement]
        public string OutlinePath { get; set; }

        /// <summary>
        /// 報告者
        /// </summary>
        [XmlElement]
        public string ReportedBy { get; set; }

        /// <summary>
        /// 報告日の文字列
        /// </summary>
        [XmlElement("DateReported")]
        public string DateReportedString { get; set; }

        /// <summary>
        /// 報告日
        /// </summary>
        public DateTime? DateReported => string.IsNullOrEmpty(DateReportedString) ? (DateTime?) null : DateTime.Parse(DateReportedString);

        /// <summary>
        /// 対策要否
        /// </summary>
        [XmlElement]
        public string NeedToFix { get; set; }

        /// <summary>
        /// 修正者
        /// </summary>
        [XmlElement]
        public string AssignedTo { get; set; }

        /// <summary>
        /// 期日の文字列
        /// </summary>
        [XmlElement("DueDate")]
        public string DueDateString { get; set; }

        /// <summary>
        /// 期日
        /// </summary>
        public DateTime? DueDate =>string.IsNullOrEmpty(DueDateString) ? (DateTime?)null : DateTime.Parse(DueDateString);

        /// <summary>
        /// 修正日の文字列
        /// </summary>
        [XmlElement("DateFixed")]
        public string DateFixedString { get; set; }

        /// <summary>
        /// 修正日
        /// </summary>
        public DateTime? DateFixed => string.IsNullOrEmpty(DateFixedString) ? (DateTime?) null : DateTime.Parse(DateFixedString);

        /// <summary>
        /// 対策
        /// </summary>
        [XmlElement]
        public string Resolution { get; set; }

        /// <summary>
        /// 確認者
        /// </summary>
        [XmlElement]
        public string ConfirmedBy { get; set; }

        /// <summary>
        /// 確認日の文字列
        /// </summary>
        [XmlElement("DateConfirmed")]
        public string DateConfirmedString { get; set; }

        /// <summary>
        /// 確認日
        /// </summary>
        public DateTime? DateConfirmed => string.IsNullOrEmpty(DateConfirmedString) ? (DateTime?) null : DateTime.Parse(DateConfirmedString);

        /// <summary>
        /// コメント
        /// </summary>
        [XmlElement]
        public string Comment { get; set; }

        #region カスタムフィールド

        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        [XmlElement]
        public string CustomText1 { get; set; }

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        [XmlElement]
        public string CustomText2 { get; set; }

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        [XmlElement]
        public string CustomText3 { get; set; }

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        [XmlElement]
        public string CustomText4 { get; set; }

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        [XmlElement]
        public string CustomText5 { get; set; }

        /// <summary>
        /// カスタムテキスト6
        /// </summary>
        [XmlElement]
        public string CustomText6 { get; set; }

        /// <summary>
        /// カスタムテキスト7
        /// </summary>
        [XmlElement]
        public string CustomText7 { get; set; }

        /// <summary>
        /// カスタムテキスト8
        /// </summary>
        [XmlElement]
        public string CustomText8 { get; set; }

        /// <summary>
        /// カスタムテキスト9
        /// </summary>
        [XmlElement]
        public string CustomText9 { get; set; }

        /// <summary>
        /// カスタムテキスト10
        /// </summary>
        [XmlElement]
        public string CustomText10 { get; set; }

        #endregion

        #endregion
    }
}
