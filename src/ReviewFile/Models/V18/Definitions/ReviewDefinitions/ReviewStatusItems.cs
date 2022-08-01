using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// V2.0のレビューのステータス一覧
    /// </summary>
    [XmlRoot("StatusItems")]
    public class ReviewStatusItems
    {
        /// <summary>
        /// レビューのステータスの定義の一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("StatusItem")]
        public List<ReviewStatusItem> ReviewStatusItemList { get; set; }
    }
}