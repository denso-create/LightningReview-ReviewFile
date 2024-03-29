﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// V2.0以降のレビューのステータス一覧
    /// </summary>
    [XmlRoot("StatusItems")]
    public class ReviewStatusItems : EntityBase
    {
        /// <summary>
        /// レビューのステータスの定義の一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("StatusItem")]
        public List<ReviewStatusItem> ReviewStatusItemList { get; set; }
    }
}