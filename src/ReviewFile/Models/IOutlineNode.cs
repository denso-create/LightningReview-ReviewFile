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
        /// <value>グローバルID。</value>
        string GID { get; }

        /// <summary>
        /// ノード名を取得します。
        /// </summary>
        /// <value>ノード名。</value>
        string Name { get; }

        /// <summary>
        /// 子ノードの一覧を取得します。
        /// </summary>
        /// <value>子ノードの一覧。子ノードがない時は、要素数0のコレクションです。</value>
        IEnumerable<IOutlineNode> Children { get; }

        #endregion
    }
}
