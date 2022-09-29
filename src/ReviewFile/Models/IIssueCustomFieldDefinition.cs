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
        /// <value>表示名。</value>
        string DisplayName { get; }

        /// <summary>
        /// 選択肢一覧を取得します。
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証します。
        /// </remarks>
        /// <value>選択肢一覧。選択肢が定義されていない時は、要素数0のコレクションです。</value>
        IEnumerable<string> AllowedValues { get; }

        /// <summary>
        /// デフォルト値を取得します。
        /// </summary>
        /// <value>デフォルト値。デフォルト値が設定されていない時は空文字列です。</value>
        string DefaultValue { get; }

        /// <summary>
        /// フィールドを使用するかを取得します。
        /// </summary>
        /// <value>フィールドを使用するか。</value>
        bool Enabled { get; }

        #endregion
    }
}