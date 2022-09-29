using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// レビューのカスタムフィールド
    /// </summary>
    [XmlRoot("CustomFields")]
    public class ReviewCustomFields : EntityBase
    {
        /// <summary>
        /// レビューのカスタムフィールドの定義の一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("ReviewCustomFieldDefinition")]
        public List<ReviewCustomFieldDefinition> ReviewCustomFieldDefinitions { get; set; }
    }
}