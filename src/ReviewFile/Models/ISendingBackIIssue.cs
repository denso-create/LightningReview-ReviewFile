using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// 差し戻し指摘のインタフェースです。
    /// </summary>
    public interface ISendingBackIssue
    {
        #region 公開プロパティ

        /// <summary>
        /// 修正方針を取得します。
        /// </summary>
        /// <value>修正方針。</value>
        string CorrectionPolicy { get; }
        
        /// <summary>
        /// 説明を取得します。
        /// </summary>
        /// <value>説明。</value>
        string Description { get; }

        /// <summary>
        /// 指摘理由を取得します。
        /// </summary>
        /// <value>指摘理由。</value>
        string Reason { get; }

        /// <summary>
        /// 対策を取得します。
        /// </summary>
        /// <value>対策。</value>
        string Resolution { get; }

        #endregion
    }
}
