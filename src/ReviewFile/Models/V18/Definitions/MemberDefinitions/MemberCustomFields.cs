using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.MemberDefinitions
{
    /// <summary>
    /// メンバのカスタムフィールドの定義の一覧
    /// </summary>
    [XmlRoot("CustomFields")]
    public class MemberCustomFields : EntityBase
    {
        /// <summary>
        /// メンバのカスタムフィールドの定義の一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("MemberCustomFieldDefinition")]
        public List<MemberCustomFieldDefinition> MemberCustomFieldDefinitions { get; set; }
    }
}