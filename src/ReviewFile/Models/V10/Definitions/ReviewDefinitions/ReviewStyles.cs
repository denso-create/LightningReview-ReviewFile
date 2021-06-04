using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
{
    /// <summary>
    /// レビュー形式
    /// </summary>
    [XmlRoot]
    public class ReviewStyles
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// デフォルト
        /// </summary>
        [XmlAttribute]
        public string Default { get; set; }
    }
}
