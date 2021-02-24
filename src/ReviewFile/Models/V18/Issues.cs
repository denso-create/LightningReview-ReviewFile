using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class Issues : EntityBase
    {
        #region プロパティ

        [XmlArray("List")]
        [XmlArrayItem("Issue")]
        public List<Issue> List { get; set; }  = new List<Issue>();

        #endregion
    }

}
