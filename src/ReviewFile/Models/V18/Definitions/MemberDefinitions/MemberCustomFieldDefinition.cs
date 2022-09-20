using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.MemberDefinitions
{
    /// <summary>
    /// メンバのカスタムフィールドの定義
    /// </summary>
    [XmlRoot]
    public class MemberCustomFieldDefinition : EntityBase, IMemberCustomFieldDefinition
    {
        /// <summary>
        /// 表示名
        /// </summary>
        [XmlElement]
        public string DisplayName { get; set; }

        /// <summary>
        /// フィールドを使用するか否か
        /// </summary>
        [XmlElement]
        public string UseThisField { get; set; }

        /// <inheritdoc />
        public bool Enabled => bool.TryParse(UseThisField, out var result) ? result : false;
    }
}