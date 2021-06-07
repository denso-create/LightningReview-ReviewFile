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

        /// <summary>
        /// グローバルID
        /// </summary>
        public string GID { get => GlobalID; set => GlobalID = value; }

        /// <summary>
        /// ローカルID（V10定義）
        /// </summary>
        [XmlAttribute]
        public string ID { get; set; }

        /// <summary>
        /// ローカルID
        /// </summary>
        public string LID { get => ID; set => ID = value; }

        /// <summary>
        /// ドキュメント名
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// ドキュメントの絶対パス
        /// </summary>
        [XmlElement]
        public string AbsolutePath { get; set; }

        /// <summary>
        /// 関連づいているアプリケーション
        /// </summary>
        [XmlElement]
        public string ApplicationType { get; set; }
        
        /// <summary>
        /// このドキュメントに関連づくアウトラインの一覧
        /// </summary>
        public IEnumerable<IOutlineNode> OutlineNodes => throw new NotImplementedException();

        #endregion
    }
}
