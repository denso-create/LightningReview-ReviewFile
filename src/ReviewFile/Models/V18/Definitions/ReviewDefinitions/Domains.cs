using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// ドメイン一覧
    /// </summary>
    [XmlRoot]
    public class Domains : EntityBase
    {
        /// <summary>
        /// ドメインの定義
        /// </summary>
        [XmlElement("ListItems")]
        public DefinitionListItems DomainItems { get; set; }
    }
}
