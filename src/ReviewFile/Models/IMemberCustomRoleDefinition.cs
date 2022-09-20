namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// メンバのカスタムロールのインターフェースです。
    /// </summary>
    public interface IMemberCustomRoleDefinition
    {
        #region 公開プロパティ

        /// <summary>
        /// 表示名を取得します。
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// フィールドを使用するかを取得します。
        /// </summary>
        bool Enabled { get; }

        #endregion
    }
}