using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Models
{
    /// <summary>
    /// アウトラインノードのインタフェース
    /// </summary>
    public interface IOutlineNode
    {
	    #region 公開プロパティ
        
        /// <summary>
        /// グローバルID
        /// </summary>
        string GID { get; set; }

        /// <summary>
        /// ノード名
        /// </summary>
        string Name { get; set; }

        IEnumerable<IOutlineNode> Children { get; }

        #endregion
    }
}
