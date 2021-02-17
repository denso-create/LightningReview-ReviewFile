using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
    [XmlRoot]
    public class Document : IDocument
    {
	    #region プロパティ

        [XmlAttribute]
        public string GlobalId { get; set; }
        public string GID { get => GlobalId; set => GlobalId = value; }

        [XmlAttribute]
        public string ID { get; set; }
        public string LID { get => ID; set => ID = value; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public string AbsolutePath { get; set; }

        [XmlElement]
        public string ApplicationType { get; set; }
        
        //[XmlArray]
        //[XmlArrayItem("OutlineTree")]
        //public List<OutlineNode> OutlineTree { get; set; }

        /// <summary>
        /// このドキュメントに関連づくアウトラインの一覧
        /// </summary>
        public IEnumerable<IOutlineNode> OutlineNodes => throw new NotImplementedException();

        #endregion
    }
}
