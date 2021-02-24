using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V10
{
    [XmlRoot]
    public class OutlineNode : IOutlineNode
    {
        #region プロパティ

        [XmlAttribute]
        public string GlobalID { get; set; }

        public string GID { get => GlobalID; set => GlobalID = value; }

        [XmlAttribute]
        public string Name { get; set; }

        //[XmlArray("")]
        //[XmlArrayItem("OutlineNode")]
        //public List<OutlineNode> ChildNodes { get; set; }

        /// <summary>
        /// 子ノードの一覧
        /// </summary>
        public IEnumerable<IOutlineNode> Children => throw new NotImplementedException();

        #endregion
    }
}
