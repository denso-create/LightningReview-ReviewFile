namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// メンバのカスタムフィールドのインターフェース
    /// </summary>
    public interface IMemberCustomFieldDefinition
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