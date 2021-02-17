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
        string GID { get; set; }
        string LID { get; set; }
        string Type { get; set; }
        string Description { get; set; }
        string Comment { get; set; }
        string Category { get; set; }
        string Status { get; set; }
        string Priority { get; set; }
        string Reason { get; set; }
        string Importance { get; set; }
        string IsSendingBack { get; set; }
        string HasBeenSentBack { get; set; }
        string DetectionActivity { get; set; }
        string InjectionActivity { get; set; }
        string OutlinePath { get; set; }
        string NeedToFix { get; set; }
        string ReportedBy { get; set; }
        string AssignedTo { get; set; }
        string ConfirmedBy { get; set; }
        string Resolution { get; set; }
        string CustomText1 { get; set; }
        string CustomText2 { get; set; }
        string CustomText3 { get; set; }
        string CustomText4 { get; set; }
        string CustomText5 { get; set; }
        string CustomText6 { get; set; }
        string CustomText7 { get; set; }
        string CustomText8 { get; set; }
        string CustomText9 { get; set; }
        string CustomText10 { get; set; }
    }
}
