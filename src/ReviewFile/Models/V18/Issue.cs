using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// 指摘
    /// </summary>
    [XmlRoot]
    public class Issue : EntityBase, IIssue
    {
        #region プロパティ

        /// <inheritdoc />
        [XmlElement]
        public string LID { get; set; }

        /// <inheritdoc />
        [XmlIgnore]
        public IDocument Document { get; set; }

        /// <inheritdoc />
        public string DocumentID => Document.GID;

        /// <inheritdoc />
        [XmlIgnore]
        public IOutlineNode OutlineNode { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Type { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CorrectionPolicy { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Category { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Description { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Reason { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string SendingBackReason { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Status { get; set; }

        /// <inheritdoc cref="IsSendingBack"/>
        [XmlElement("IsSendingBack")]
        public string IsSendingBackString { get; set; }

        /// <inheritdoc />
        public bool IsSendingBack => bool.TryParse(IsSendingBackString, out var result) ? result : default;

        /// <inheritdoc cref="HasBeenSentBack" />
        [XmlElement("HasBeenSentBack")]
        public string HasBeenSentBackString { get; set; }

        /// <inheritdoc />
        public bool HasBeenSentBack => bool.TryParse(HasBeenSentBackString, out var result) ? result : true;

        /// <inheritdoc />
        [XmlElement]
        public string DetectionActivity { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string InjectionActivity { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Priority { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Importance { get; set; }

        /// <inheritdoc />
        public string OutlineName
        {
            get
            {
                // アウトラインパスの末尾のアウトライン名を取得
                return OutlinePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            }
        }

        /// <inheritdoc />
        public string RootOutlineName
        {
            get
            {
                // アウトラインパスの先頭のアウトライン名を取得
                return OutlinePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).First();
            }
        }

        /// <inheritdoc />
        [XmlElement]
        public string OutlinePath { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string ReportedBy { get; set; }

        /// <summary>
        /// 報告日の文字列
        /// </summary>
        [XmlElement("DateReported")]
        public string DateReportedString { get; set; }

        /// <inheritdoc />
        public DateTime? DateReported => string.IsNullOrEmpty(DateReportedString) ? (DateTime?)null : DateTime.Parse(DateReportedString);

        /// <inheritdoc />
        [XmlElement]
        public string NeedToFix { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string AssignedTo { get; set; }

        /// <summary>
        /// 期日の文字列
        /// </summary>
        [XmlElement("DueDate")]
        public string DueDateString { get; set; }

        /// <inheritdoc />
        public DateTime? DueDate => string.IsNullOrEmpty(DueDateString) ? (DateTime?)null : DateTime.Parse(DueDateString);

        /// <summary>
        /// 修正日の文字列
        /// </summary>
        [XmlElement("DateFixed")]
        public string DateFixedString { get; set; }

        /// <inheritdoc />
        public DateTime? DateFixed => string.IsNullOrEmpty(DateFixedString) ? (DateTime?)null : DateTime.Parse(DateFixedString);

        /// <inheritdoc />
        [XmlElement]
        public string Resolution { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string ConfirmedBy { get; set; }

        /// <summary>
        /// 確認日の文字列
        /// </summary>
        [XmlElement("DateConfirmed")]
        public string DateConfirmedString { get; set; }

        /// <inheritdoc />
        public DateTime? DateConfirmed => string.IsNullOrEmpty(DateConfirmedString) ? (DateTime?)null : DateTime.Parse(DateConfirmedString);

        /// <inheritdoc />
        [XmlElement]
        public string Comment { get; set; }

        #region カスタムフィールド

        /// <inheritdoc />
        [XmlElement]
        public string CustomText1 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText2 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText3 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText4 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText5 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText6 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText7 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText8 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText9 { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string CustomText10 { get; set; }

        /// <inheritdoc />
        /// <remarks>
        /// カスタムテキスト11以降の定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// カスタムテキストの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        [XmlElement]
        public string CustomText11 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText12 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText13 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText14 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText15 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText16 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText17 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText18 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText19 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText20 { get; set; } = string.Empty;

        #endregion

        #endregion
    }
}
