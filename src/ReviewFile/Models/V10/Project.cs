using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
{
    /// <summary>
    /// プロジェクト
    /// </summary>
    [XmlRoot]
    public class Project
    {
        #region プロパティ

        /// <summary>
        /// プロジェクトコード
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// プロジェクト名
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        #endregion
    }
}
