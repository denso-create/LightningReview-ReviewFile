using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models.V18
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            GID = Guid.NewGuid().ToString();
        }

        [XmlElement]
        public string GID { get; set; } 


        [XmlElement]
        public string CreatedBy { get; set; }

        [XmlElement]
        public string LastUpdatedBy { get; set; }

        [XmlElement("CreatedDateTime")]
        public string CreatedDateTimeString { get; set; }

        public DateTime CreatedDateTime => DateTime.Parse(CreatedDateTimeString);

        [XmlElement("LastUpdatedDateTime")]
        public string LastUpdatedDateTimeString { get; set; }

        public DateTime LastUpdatedDateTime => DateTime.Parse(LastUpdatedDateTimeString);

    }
}
