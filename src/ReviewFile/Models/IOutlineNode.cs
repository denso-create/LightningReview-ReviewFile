using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
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
        string GID { get; }

        /// <summary>
        /// ノード名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 子ノードの一覧
        /// </summary>
        IEnumerable<IOutlineNode> Children { get; }

        #endregion
    }
}
