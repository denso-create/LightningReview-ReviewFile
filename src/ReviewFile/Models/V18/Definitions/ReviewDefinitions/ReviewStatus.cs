using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// V2.0より前のバージョンのレビューのステータス一覧
    /// </summary>
    [XmlRoot("Status")]
    public class ReviewStatus : EntityBase
    {
        /// <summary>
        /// レビューのステータスの定義
        /// </summary>
        [XmlElement("ListItems")]
        public DefinitionListItems ReviewStatusItems { get; set; }
    }
}
