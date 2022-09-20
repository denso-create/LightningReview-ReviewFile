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

        /// <summary>
        /// グローバルID
        /// </summary>
        public string GID { get => GlobalID; set => GlobalID = value; }

        /// <summary>
        /// ノード名
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 子ノードの一覧
        /// </summary>
        public IEnumerable<IOutlineNode> Children => ChildNodes;

        /// <summary>
        /// 子ノードの一覧
        /// </summary>
        [XmlElement("OutlineNode")]
        public List<OutlineNode> ChildNodes { get; set; }

        #endregion
    }
}
