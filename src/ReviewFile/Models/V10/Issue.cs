using System;
using System.Collections.Generic;
using System.Text;
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
        public string Description { get; set; }

        [XmlElement]
        public string Comment { get; set; }

        [XmlElement]
        public string Category { get; set; }

        [XmlElement]
        public string Status { get; set; }

        [XmlElement]
        public string Priority { get; set; }

        [XmlElement]
        public string Reason { get; set; }

        [XmlElement]
        public string IsSendingBack { get; set; }

        [XmlElement]
        public string NeedToFix { get; set; }

        [XmlElement]
        public string HasBeenSentBack { get; set; }

        [XmlElement]
        public string DetectionActivity { get; set; }

        [XmlElement]
        public string InjectionActivity { get; set; }

        [XmlElement]
        public string OutlinePath { get; set; }

        [XmlElement]
        public string Importance { get; set; }

        [XmlElement]
        public string ReportedBy { get; set; }

        [XmlElement]
        public string AssignedTo { get; set; }

        [XmlElement]
        public string ConfirmedBy { get; set; }

        [XmlElement]
        public string Resolution { get; set; }

        [XmlElement("DateReported")]
        public string DateReportedString { get; set; }

        public DateTime? DateReported => DateTime.Parse(DateReportedString);

        [XmlElement]
        public string DueDateString { get; set; }

        public DateTime? DueDate => DateTime.Parse(DueDateString);

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
