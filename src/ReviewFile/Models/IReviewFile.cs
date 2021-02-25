using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Models
{
    /// <summary>
    /// レビューファイルのインタフェース
    /// </summary>
    public interface IReviewFile
    {
        #region 公開プロパティ

        /// <summary>
        /// スキーマバージョン値
        /// </summary>
        string SchemaVersion { get; set; }

        /// <summary>
        /// レビュー
        /// </summary>
        IReview Review { get; }

        #endregion
    }
}
