using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Defenitions
{
    /// <summary>
    /// 定義
    /// </summary>
    [XmlRoot]
    public class Defenition : EntityBase
    {
        /// <summary>
        /// 未対応の要素
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// 未対応の要素
        /// </summary>
        [XmlElement]
        public string Name { get; set; }
    }
}
