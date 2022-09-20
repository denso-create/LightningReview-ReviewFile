using System.Collections.Generic;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// 指摘のカスタムフィールドのインターフェースです。
    /// </summary>
	public interface IIssueCustomFieldDefinition
    {
        #region 公開プロパティ

        /// <summary>
        /// 表示名を取得します。
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// 選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        IEnumerable<string> AllowedValues { get; }

        /// <summary>
        /// デフォルト値を取得します。
        /// </summary>
        string DefaultValue { get; }

        /// <summary>
        /// フィールドを使用するかを取得します。
        /// </summary>
        bool Enabled { get; }

        #endregion
    }
}