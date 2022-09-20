using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// レビューファイルのインタフェースです。
    /// </summary>
    public interface IReviewFile
    {
        #region 公開プロパティ

        /// <summary>
        /// スキーマバージョン値を取得します。
        /// </summary>
        string SchemaVersion { get; }

        /// <summary>
        /// レビューを取得します。
        /// </summary>
        IReview Review { get; }

        #endregion
    }
}
