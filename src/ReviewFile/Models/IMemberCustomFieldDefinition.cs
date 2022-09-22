namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// メンバのカスタムフィールドのインターフェースです。
    /// </summary>
    public interface IMemberCustomFieldDefinition
    {
        #region 公開プロパティ

        /// <summary>
        /// 表示名を取得します。
        /// </summary>
        /// <value>表示名。</value>
        string DisplayName { get; }

        /// <summary>
        /// フィールドを使用するかを取得します。
        /// </summary>
        /// <value>フィールドを使用するか。</value>
        bool Enabled { get; }

        #endregion
    }
}