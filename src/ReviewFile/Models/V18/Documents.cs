using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// ドキュメントの一覧
    /// </summary>
    [XmlRoot]
    public class Documents : EntityBase
    {
        #region プロパティ

        /// <summary>
        /// ドキュメントの一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("Document")]
        public List<Document> List { get; set; } = new List<Document>();

        #endregion
    }
}
