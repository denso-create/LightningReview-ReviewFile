using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// アウトラインノードのインタフェースです。
    /// </summary>
    public interface IOutlineNode
    {
        #region 公開プロパティ
        
        /// <summary>
        /// グローバルIDを取得します。
        /// </summary>
        string GID { get; }

        /// <summary>
        /// ノード名を取得します。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 子ノードの一覧を取得します。
        /// </summary>
        IEnumerable<IOutlineNode> Children { get; }

        #endregion
    }
}
