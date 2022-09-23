using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
{
    /// <summary>
    /// アウトラインノード
    /// </summary>
    [XmlRoot]
    public class OutlineNode : IOutlineNode
    {
        #region プロパティ

        /// <summary>
        /// グローバルID（V10定義）
        /// </summary>
        [XmlAttribute]
        public string GlobalID { get; set; }

        /// <inheritdoc />
        public string GID { get => GlobalID; set => GlobalID = value; }

        /// <inheritdoc />
        [XmlAttribute]
        public string Name { get; set; }

        /// <inheritdoc />
        public IEnumerable<IOutlineNode> Children => ChildNodes;

        /// <inheritdoc cref="Children" />
        [XmlElement("OutlineNode")]
        public List<OutlineNode> ChildNodes { get; set; }

        #endregion
    }
}
