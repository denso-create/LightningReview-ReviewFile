using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class Review : EntityBase
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Goal { get; set; }

        [XmlElement]
        public string Domain { get; set; }

        [XmlElement]
        public Documents Documents { get; set; }

        public IEnumerable<Issue> AllIssues() 
        {
            throw new NotImplementedException();
        }
    }


}
