using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    public abstract class EntityBase
    {
	    #region 構築

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EntityBase()
        {
            GID = Guid.NewGuid().ToString();
        }

        #endregion

        #region プロパティ

        [XmlElement]
        public string GID { get; set; } 

        [XmlElement]
        public string CreatedBy { get; set; }

        [XmlElement]
        public string LastUpdatedBy { get; set; }

        [XmlElement("CreatedDateTime")]
        public string CreatedDateTimeString { get; set; }
        public DateTime? CreatedDateTime => string.IsNullOrEmpty(CreatedDateTimeString) ? (DateTime?) null : DateTime.Parse(CreatedDateTimeString);

        [XmlElement("LastUpdatedDateTime")]
        public string LastUpdatedDateTimeString { get; set; }
        public DateTime? LastUpdatedDateTime => string.IsNullOrEmpty(LastUpdatedDateTimeString) ? (DateTime?) null : DateTime.Parse(LastUpdatedDateTimeString);

        #endregion
    }
}
