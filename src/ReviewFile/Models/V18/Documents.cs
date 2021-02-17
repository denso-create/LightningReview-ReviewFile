using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    [XmlRoot]
    public class Documents : EntityBase
    {
	    #region プロパティ

        [XmlArray("List")]
        [XmlArrayItem("Document")]
        public List<Document> List { get; set; } = new List<Document>();

        #endregion
    }
}
