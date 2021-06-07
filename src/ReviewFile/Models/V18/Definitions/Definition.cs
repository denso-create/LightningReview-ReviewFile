using System.Xml.Serialization;
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
    }
}
