using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.MemberDefinitions
{
    /// <summary>
    /// メンバの定義
    /// </summary>
    [XmlRoot]
    public class MemberDefinition : EntityBase
    {
        /// <summary>
        /// カスタムロールの一覧
        /// </summary>
        [XmlElement("CustomRoles")]
        public MemberCustomRoles CustomRoles { get; set; }

        /// <summary>
        /// カスタムフィールドの一覧
        /// </summary>
        [XmlElement("CustomFields")]
        public MemberCustomFields CustomFields { get; set; }
    }
}