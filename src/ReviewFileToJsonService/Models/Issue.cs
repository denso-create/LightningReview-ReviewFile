using System;
using System.Collections.Generic;
using System.Text;
using LightningReview.ReviewFile.Models;
using ReviewFileToJsonService.Extensions;

namespace ReviewFileToJsonService.Models
{
    public class Issue 
    {
        public Issue() { }

        public Issue(IIssue issue)
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
        public string GID { get; set; }
        public string Comment { get; set; }
        public string Category { get; set; }
        public string IsSendingBack { get; set; }
        public string HasBeenSentBack { get; set; }
        public string DetectionActivity { get; set; }
        public string InjectionActivity { get; set; }
        public string OutlinePath { get; set; }
        public string NeedToFix { get; set; }
    }
}
