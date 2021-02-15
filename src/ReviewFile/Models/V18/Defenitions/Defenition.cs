using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18.Defenitions
{

    [XmlRoot]
    public class Defenition : EntityBase
    {
        [XmlElement]
        public string Code { get; set; }

        [XmlElement]
        public string Name { get; set; }
    }
}
