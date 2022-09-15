using System.Collections.Generic;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// 指摘のカスタムフィールドのインターフェース
    /// </summary>
	public interface IIssueCustomFieldDefinition
    {
        #region 公開プロパティ

        /// <summary>
        /// 表示名
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// 選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> AllowedValues { get; }

        /// <summary>
        /// デフォルト値
        /// </summary>
        string DefaultValue { get; }

        /// <summary>
        /// フィールドを使用するか
        /// </summary>
        string Enabled { get; }

        #endregion
    }
}