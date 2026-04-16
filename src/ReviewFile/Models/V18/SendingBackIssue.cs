using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// ç∑ÇµñﬂÇµéwìE
    /// </summary>
    [XmlRoot]
    public class SendingBackIssue : ISendingBackIssue
    {
        /// <inheritdoc />
        [XmlElement]
        public string CorrectionPolicy { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Description { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Reason { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string Resolution { get; set; }
    }
}