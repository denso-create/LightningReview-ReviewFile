using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.IssueDefinitions
{
    /// <summary>
    /// 指摘のフィールドの定義一覧
    /// </summary>
    [XmlRoot]
	public class Fields : EntityBase
    {
        /// <summary>
        /// 指摘のフィールドの定義一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("FieldDefinition")]
        public List<FieldDefinition> FieldDefinitions { get; set; }
    }
}