using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10
{
    /// <summary>
    /// ドキュメント
    /// </summary>
    [XmlRoot]
    public class Document : IDocument
    {
        #region プロパティ

        /// <summary>
        /// グローバルID（V10定義）
        /// </summary>
        [XmlAttribute]
        public string GlobalID { get; set; }

        /// <inheritdoc />
        public string GID { get => GlobalID; set => GlobalID = value; }

        /// <summary>
        /// ローカルID（V10定義）
        /// </summary>
        [XmlAttribute]
        public string ID { get; set; }

        /// <inheritdoc />
        public string LID { get => ID; set => ID = value; }

        /// <inheritdoc />
        [XmlAttribute]
        public string Name { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string AbsolutePath { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string ApplicationType { get; set; }

        /// <inheritdoc />
        IEnumerable<IOutlineNode> IDocument.OutlineNodes => OutlineNodes;

        /// <inheritdoc cref="IDocument.OutlineNodes"/>
        [XmlArray("OutlineTree")]
        [XmlArrayItem("OutlineNode")]
        public List<OutlineNode> OutlineNodes { get; set; }

        /// <inheritdoc />
        public IEnumerable<IMetaData> MetaDatas => new List<IMetaData>();

        #endregion

        #region 公開サービス

        /// <inheritdoc />
        public T GetMetaData<T>(string key, T defaultValue = default)
        {
            return defaultValue;
        }

        #endregion
    }
}
