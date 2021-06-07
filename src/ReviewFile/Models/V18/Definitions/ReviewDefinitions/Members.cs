using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// メンバ一覧
    /// </summary>
    [XmlRoot]
    public class Members : EntityBase
    {
        /// <summary>
        /// メンバ一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("Member")]
        public List<Member> ListItems { get; set; }
    }
}
