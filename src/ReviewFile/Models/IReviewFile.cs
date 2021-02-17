using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Models
{
    public interface IReviewFile
    {
        /// <summary>
        /// スキーマバージョン値
        /// </summary>
        string SchemaVersion { get; set; }

        /// <summary>
        /// レビュー
        /// </summary>
        IReview Review { get; }
    }
}
