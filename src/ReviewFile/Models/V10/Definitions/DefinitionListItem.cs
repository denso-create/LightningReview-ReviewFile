﻿using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions
{
    /// <summary>
    /// Definitionのリストアイテム
    /// </summary>
    public class DefinitionListItem
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// デフォルト
        /// </summary>
        [XmlAttribute]
        public string Default { get; set; }
    }
}