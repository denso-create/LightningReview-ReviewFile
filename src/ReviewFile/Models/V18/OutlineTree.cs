using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// アウトラインツリー
    /// </summary>
    [XmlRoot]
    public class OutlineTree : EntityBase
    {
        #region プロパティ

        /// <summary>
        /// 仮想で保持するルートノード
        /// </summary>
        [XmlElement]
        public OutlineNode VirtualRoot { get; set; } = new OutlineNode();

        #endregion
    }
}
