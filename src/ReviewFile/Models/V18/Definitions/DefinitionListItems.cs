using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions
{
    /// <summary>
    /// Definitionのリストアイテム一覧
    /// </summary>
    [XmlRoot("ListItems")]
    public class DefinitionListItems : EntityBase
    {
        /// <summary>
        /// リストアイテム一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("ListItem")]
        public List<DefinitionListItem> ListItems { get; set; }
    }
}
