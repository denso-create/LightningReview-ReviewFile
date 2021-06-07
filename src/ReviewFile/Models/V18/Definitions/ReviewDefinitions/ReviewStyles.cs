using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// レビュー形式一覧
    /// </summary>
    [XmlRoot]
    public class ReviewStyles : EntityBase
    {
        /// <summary>
        /// レビュー形式の定義
        /// </summary>
        [XmlElement("ListItems")]
        public DefinitionListItems ReviewStyleItems { get; set; }
    }
}
