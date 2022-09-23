using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.MemberDefinitions
{
    /// <summary>
    /// メンバのカスタムロールの定義
    /// </summary>
    [XmlRoot]
    public class MemberCustomRoleDefinition : EntityBase, IMemberCustomRoleDefinition
    {
        /// <inheritdoc />
        [XmlElement]
        public string DisplayName { get; set; }

        /// <inheritdoc cref="Enabled" />
        [XmlElement]
        public string UseThisField { get; set; }

        /// <inheritdoc />
        public bool Enabled => bool.TryParse(UseThisField, out var result) ? result : false;
    }
}