using System.Collections.Generic;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// レビューのカスタムフィールドのインターフェースです。
    /// </summary>
	public interface IReviewCustomFieldDefinition
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
        /// フィールドを使用するかを取得します。
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 所属するグループを取得します。
        /// </summary>
        /// <value>
        /// 所属するグループの値域を以下に示します。
        /// [値域]
        /// 基本設定
        /// プロジェクト
        /// 計画と実績 
        /// </value>
        string Group { get; }

        #endregion
    }
}