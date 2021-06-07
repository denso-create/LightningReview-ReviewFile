using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// レビュー種別一覧
    /// </summary>
    [XmlRoot]
    public  class ReviewTypes : EntityBase
    {
        /// <summary>
        /// レビュー形式の定義
        /// </summary>
        [XmlElement("ListItems")]
        public DefinitionListItems ReviewTypeItems { get; set; }
    }
}
