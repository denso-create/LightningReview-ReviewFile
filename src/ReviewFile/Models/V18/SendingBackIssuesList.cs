using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// 差し戻し指摘リストのコンテナ
    /// </summary>
    [XmlRoot]
    public class SendingBackIssuesList : EntityBase
    {
        /// <summary>
        /// 差し戻し指摘の一覧
        /// </summary>
        [XmlArray("List")]
        [XmlArrayItem("Issue")]
        public List<Issue> List { get; set; } = new List<Issue>();
    }
}