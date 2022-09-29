using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.MemberDefinitions
{
    /// <summary>
    /// メンバのカスタムロールの定義の一覧
    /// </summary>
    [XmlRoot("CustomRoles")]
    public class MemberCustomRoles : EntityBase
    {
        /// <summary>
        /// メンバのカスタムロールの定義の一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("MemberCustomRoleDefinition")]
        public List<MemberCustomRoleDefinition> MemberCustomRoleDefinitions { get; set; }
    }
}