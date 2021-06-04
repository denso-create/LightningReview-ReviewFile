using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
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
    }
}
