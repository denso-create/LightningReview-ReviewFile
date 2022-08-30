using System.Xml.Serialization;
using DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.IssueDefinitions;
using DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.MemberDefinitions;
using DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions
{
    /// <summary>
    /// 定義
    /// </summary>
    [XmlRoot]
    public class Definition : EntityBase
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

        /// <summary>
        /// メンバの定義
        /// </summary>
        [XmlElement]
        public MemberDefinition MemberDefinition { get; set; }
    }
}
