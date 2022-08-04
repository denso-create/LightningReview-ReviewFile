using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// V2.0以降のレビューのステータスの定義
    /// </summary>
    public class ReviewStatusItem
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// ステータスが選択状態か
        /// </summary>
        [XmlElement]
        public string IsSelected { get; set; }
    }
}