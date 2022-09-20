using System;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions.ReviewDefinitions
{
    /// <summary>
    /// V2.0以降のレビューのステータスの定義
    /// (V10ではデシリアライズ対象のクラスではない)
    /// </summary>
    public class ReviewStatusItem : IStatusItem
    {
        #region 定数定義

        /// <summary>
        /// Colorプロパティの初期値
        /// </summary>
        private const string c_DefaultColor = "なし";

        #endregion

        #region プロパティ

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 設定日
        /// </summary>
        public DateTime? SelectedOn => (DateTime?)null;

        /// <summary>
        /// 設定者
        /// </summary>
        public string SelectedBy => string.Empty;

        /// <inheritdoc />

        public bool IsClosed => false;

        /// <summary>
        /// このステータスが、現在のステータスとして設定されているか
        /// </summary>
        public string IsSelectedString { get; set; }

        /// <inheritdoc />
        public bool IsSelected => bool.TryParse(IsSelectedString, out var result) ? result : false;

        /// <inheritdoc />
        public string Color => c_DefaultColor;

        #endregion
    }
}