using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.MemberDefinitions
{
    /// <summary>
    /// メンバのカスタムロールの定義
    /// </summary>
    [XmlRoot]
    public class MemberCustomRoleDefinition : EntityBase, IMemberCustomRoleDefinition
    {
        /// <summary>
        /// 表示名
        /// </summary>
        [XmlElement]
        public string DisplayName { get; set; }

        /// <summary>
        /// フィールドを使用するか否か
        /// </summary>
        [XmlElement("UseThisField")]
        public string Enabled { get; set; }
    }
}