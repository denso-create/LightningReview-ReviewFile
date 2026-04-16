using DensoCreate.LightningReview.ReviewFile.Models;
using DensoCreate.LightningReview.ReviewFileToJsonService.Extensions;

namespace DensoCreate.LightningReview.ReviewFileToJsonService
{
    /// <summary>
    /// 差し戻し指摘
    /// </summary>
    public class SendingBackIssue
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SendingBackIssue()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sendingBackIssue"></param>
        public SendingBackIssue(ISendingBackIssue sendingBackIssue)
        {
            this.CopyFieldsFrom(sendingBackIssue);
        }

        /// <summary>
        /// 修正方針
        /// </summary>
        public string CorrectionPolicy { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 指摘理由
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 対策
        /// </summary>
        public string Resolution { get; set; }
    }
}