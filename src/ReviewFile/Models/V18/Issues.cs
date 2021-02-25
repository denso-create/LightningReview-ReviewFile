using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// 指摘の一覧
    /// </summary>
    [XmlRoot]
    public class Issues : EntityBase
    {
        #region プロパティ

        /// <summary>
        /// 指摘の一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("Issue")]
        public List<Issue> List { get; set; }  = new List<Issue>();

        #endregion
    }

}
