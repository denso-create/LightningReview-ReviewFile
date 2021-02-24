using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
    [XmlRoot]
    public class Project
    {
        #region プロパティ

        [XmlElement]
        public string Code { get; set; }

        [XmlElement]
        public string Name { get; set; }

        #endregion
    }
}
