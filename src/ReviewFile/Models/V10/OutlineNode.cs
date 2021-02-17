﻿using System;
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
        public string GlobalId { get; set; }

        public string GID { get => GlobalId; set => GlobalId = value; }

        [XmlAttribute]
        public string Name { get; set; }

        //[XmlArray("")]
        //[XmlArrayItem("OutlineNode")]
        //public List<OutlineNode> ChildNodes { get; set; }

        public IEnumerable<IOutlineNode> Children => throw new NotImplementedException();

        #endregion
    }
}
