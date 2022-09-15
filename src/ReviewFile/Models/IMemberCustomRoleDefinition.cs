namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// メンバのカスタムロールのインターフェース
    /// </summary>
    public interface IMemberCustomRoleDefinition
    {
        #region 公開プロパティ

        /// <summary>
        /// 表示名
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// フィールドを使用するか
        /// </summary>
        string Enabled { get; }

        #endregion
    }
}