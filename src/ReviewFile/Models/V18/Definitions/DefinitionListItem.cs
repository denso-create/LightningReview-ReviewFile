using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions
{
    /// <summary>
    /// Definitionのリストアイテム
    /// </summary>
    public class DefinitionListItem : EntityBase
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// デフォルト
        /// </summary>
        [XmlElement]
        public string Default { get; set; }
    }
}
