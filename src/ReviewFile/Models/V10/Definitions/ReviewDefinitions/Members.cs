using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
{
    /// <summary>
    /// メンバ
    /// </summary>
    [XmlRoot]
    public class Members
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 報告者
        /// </summary>
        [XmlAttribute]
        public string Reviewer { get; set; }

        /// <summary>
        /// 修正者
        /// </summary>
        [XmlAttribute]
        public string Reviewee { get; set; }

        /// <summary>
        /// 確認者
        /// </summary>
        [XmlAttribute]
        public string Moderator { get; set; }
    }
}
