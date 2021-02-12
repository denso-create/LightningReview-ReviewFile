using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class Issue : EntityBase
    {
        [XmlElement]
        public string LID{ get; set; }

        [XmlElement]
        public string Type { get; set; }

        [XmlElement]
        public string Description { get; set; }

        [XmlElement]
        public string Status { get; set; }

        [XmlElement]
        public string Priority { get; set; }

        [XmlElement]
        public string Reason { get; set; }

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



    }
}
