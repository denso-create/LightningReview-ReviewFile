﻿using System;
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
        string GID { get; set; }

        /// <summary>
        /// ノード名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 子ノードの一覧
        /// </summary>
        IEnumerable<IOutlineNode> Children { get; }

        #endregion
    }
}
