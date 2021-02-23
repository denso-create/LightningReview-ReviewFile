using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
    [XmlRoot]
    public class Issue : IIssue
    {
	    #region プロパティ
        
	    [XmlAttribute]
        public string GlobalID { get; set; }
        public string GID { get => GlobalID; set => GlobalID = value; }

        [XmlAttribute]
        public string ID { get; set; }
        public string LID { get=>ID; set=>ID=value; }

        [XmlElement]
        public string Type { get; set; }

        [XmlElement]
        public string CorrectionPolicy { get; set; }

        [XmlElement]
        public string Category { get; set; }

        [XmlElement]
        public string Description { get; set; }

        [XmlElement]
        public string Reason { get; set; }

        [XmlElement]
        public string SendingBackReason { get; set; }

        [XmlElement]
        public string Status { get; set; }

        [XmlElement]
        public string IsSendingBack { get; set; }

        [XmlElement]
        public string HasBeenSentBack { get; set; }
        
        [XmlElement]
        public string DetectionActivity { get; set; }

        [XmlElement]
        public string InjectionActivity { get; set; }

        [XmlElement]
        public string Priority { get; set; }

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

        [XmlElement]
        public string OutlinePath { get; set; }

        [XmlElement]
        public string ReportedBy { get; set; }

        [XmlElement("DateReported")]
        public string DateReportedString { get; set; }
        public DateTime? DateReported => string.IsNullOrEmpty(DateReportedString) ? (DateTime?) null : DateTime.Parse(DateReportedString);

        [XmlElement]
        public string NeedToFix { get; set; }

        [XmlElement]
        public string AssignedTo { get; set; }

        [XmlElement("DueDate")]
        public string DueDateString { get; set; }
        public DateTime? DueDate =>string.IsNullOrEmpty(DueDateString) ? (DateTime?)null : DateTime.Parse(DueDateString);

        [XmlElement("DateFixed")]
        public string DateFixedString { get; set; }
        public DateTime? DateFixed => string.IsNullOrEmpty(DateFixedString) ? (DateTime?) null : DateTime.Parse(DateFixedString);
  
        [XmlElement]
        public string Resolution { get; set; }

        [XmlElement]
        public string ConfirmedBy { get; set; }

        [XmlElement("DateConfirmed")]
        public string DateConfirmedString { get; set; }
        public DateTime? DateConfirmed => string.IsNullOrEmpty(DateConfirmedString) ? (DateTime?) null : DateTime.Parse(DateConfirmedString);

        [XmlElement]
        public string Comment { get; set; }

        #region カスタムフィールド

        [XmlElement]
        public string CustomText1 { get; set; }

        [XmlElement]
        public string CustomText2 { get; set; }

        [XmlElement]
        public string CustomText3 { get; set; }

        [XmlElement]
        public string CustomText4 { get; set; }

        [XmlElement]
        public string CustomText5 { get; set; }

        [XmlElement]
        public string CustomText6 { get; set; }

        [XmlElement]
        public string CustomText7 { get; set; }

        [XmlElement]
        public string CustomText8 { get; set; }

        [XmlElement]
        public string CustomText9 { get; set; }

        [XmlElement]
        public string CustomText10 { get; set; }

        #endregion

        #endregion
    }
}
