using System;
using System.Collections.Generic;
using System.Text;
using RevxToJsonService.Extensions;

namespace RevxToJsonService.Models
{
    public class Issue
    {
        public Issue() { }

        public Issue(LightningReview.RevxFile.Models.Issue issue)
        {
            // フィールドをコピー
            this.CopyFieldsFrom(issue);
        }

        public string LID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Reason { get; set; }
        public string Importance { get; set; }
        public string ReportedBy { get; set; }
        public string AssignedTo { get; set; }
        public string ConfirmedBy { get; set; }
        public string Resolution { get; set; }
        public string CustomText1 { get; set; }
        public string CustomText2 { get; set; }
        public string CustomText3 { get; set; }
        public string CustomText4 { get; set; }
        public string CustomText5 { get; set; }
        public string CustomText6 { get; set; }
        public string CustomText7 { get; set; }
        public string CustomText8 { get; set; }
        public string CustomText9 { get; set; }
        public string CustomText10 { get; set; }
    }
}
