using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// メンバ
    /// </summary>
    [XmlRoot]
    public class Member : EntityBase
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 報告者
        /// </summary>
        [XmlElement]
        public string Reviewer { get; set; }

        /// <summary>
        /// 修正者
        /// </summary>
        [XmlElement]
        public string Reviewee { get; set; }

        /// <summary>
        /// 確認者
        /// </summary>
        [XmlElement]
        public string Moderator { get; set; }
    }
}
