using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models.V10
{
    [XmlRoot]
    public class Review : IReview
    {
        #region 永続化プロパティ
        [XmlAttribute]
        public string GlobalId { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Goal { get; set; }

        [XmlElement]
        public string Domain { get; set; }

        [XmlElement]
        public string Place { get; set; }

        [XmlElement]
        public string PlannedDate { get; set; }

        [XmlElement]
        public string ActualDate { get; set; }

        [XmlElement]
        public string PlannedTime { get; set; }

        [XmlElement]
        public string ActualTime { get; set; }

        [XmlElement]
        public string Unit { get; set; }

        [XmlElement]
        public string PlannedScale { get; set; }

        [XmlElement]
        public List<Document> Documents { get; set; }

        [XmlElement]
        public List<Issue> Issues { get; set; }

        [XmlElement]
        public Project Project { get; set; }

        [XmlElement]
        public string LastUpdatedBy { get; set; }

        [XmlElement("CreatedDateTime")]
        public string CreatedDateTimeString { get; set; }


        [XmlElement("LastUpdatedDateTime")]
        public string LastUpdatedDateTimeString { get; set; }

        [XmlElement]
        public string CreatedBy { get; set; }

        #endregion

        public string GID { get => GlobalId; set => GlobalId = value; }

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; }

        public DateTime CreatedDateTime => DateTime.Parse(CreatedDateTimeString);

        public DateTime LastUpdatedDateTime => DateTime.Parse(LastUpdatedDateTimeString);
        
        
        public IEnumerable<IIssue> AllIssues => Issues;

        IEnumerable<IDocument> IReview.Documents => throw new NotImplementedException();

    }

}
