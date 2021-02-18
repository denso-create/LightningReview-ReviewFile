using System;
using System.Collections.Generic;
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
        public string GlobalId { get; set; }
        public string GID { get => GlobalId; set => GlobalId = value; }

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
        /// 場所（関連付けられているアウトラインノードの名前）
        /// </summary>
        public string OutlineName {
	        get
	        {
		        var outlineName = Regex.Match(OutlinePath, @"[^/]+$");
		        return outlineName.Value;
	        }
        }

        /// <summary>
        /// 場所（ルートレベルのアウトラインノードの名前）
        /// </summary>
        public string RootOutlineName {
	        get
	        {
		        var rootOutlineName = Regex.Match(OutlinePath.TrimStart('/'), @"^[^/]+");
		        return rootOutlineName.Value;
	        }
        }

        [XmlElement]
        public string OutlinePath { get; set; }

        [XmlElement]
        public string ReportedBy { get; set; }

        [XmlElement("DateReported")]
        public string DateReportedString { get; set; }
        public DateTime? DateReported => DateTime.Parse(DateReportedString);

        [XmlElement]
        public string NeedToFix { get; set; }

        [XmlElement]
        public string AssignedTo { get; set; }

        [XmlElement("DueDate")]
        public string DueDateString { get; set; }
        public DateTime? DueDate => DateTime.Parse(DueDateString);

        [XmlElement("DateFixed")]
        public string DateFixedString { get; set; }
        public DateTime? DateFixed => DateTime.Parse(DateFixedString);

        [XmlElement]
        public string Resolution { get; set; }

        [XmlElement]
        public string ConfirmedBy { get; set; }

        [XmlElement("DateConfirmed")]
        public string DateConfirmedString { get; set; }
        public DateTime? DateConfirmed => DateTime.Parse(DateConfirmedString);

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
