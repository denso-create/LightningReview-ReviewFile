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

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public DateTime? SelectedOn => (DateTime?)null;

        /// <inheritdoc />
        public string SelectedBy => string.Empty;

        /// <inheritdoc />

        public bool IsClosed => false;

        /// <inheritdoc cref="IsSelected" />
        public string IsSelectedString { get; set; }

        /// <inheritdoc />
        public bool IsSelected => bool.TryParse(IsSelectedString, out var result) ? result : false;

        /// <inheritdoc />
        public string Color => c_DefaultColor;

        #endregion
    }
}