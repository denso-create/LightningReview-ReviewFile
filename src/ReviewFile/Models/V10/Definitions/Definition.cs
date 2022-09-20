using System.Xml.Serialization;
using DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions.IssueDefinitions;
using DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions.ReviewDefinitions;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions
{
    /// <summary>
    /// 定義
    /// </summary>
    [XmlRoot]
    public class Definition
    {
        /// <summary>
        /// レビューの定義
        /// </summary>
        [XmlElement]
        public ReviewDefinition ReviewDefinition { get; set; }

        /// <summary>
        /// 指摘の定義
        /// </summary>
        [XmlElement]
        public IssueDefinition IssueDefinition { get; set; }
    }
}
