namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// メンバのインタフェースです。
    /// </summary>
    public interface IReviewMember
    {
        #region 公開プロパティ

        /// <summary>
        /// メンバーの名前を取得します。
        /// </summary>
        /// <value>メンバーの名前。</value>
        string Name { get; }

        /// <summary>
        /// メンバーはレビューワかを取得します。
        /// </summary>
        /// <value>メンバーはレビューワか。</value>
        bool Reviewer { get; }

        /// <summary>
        /// メンバーはレビューイかを取得します。
        /// </summary>
        /// <value>メンバーはレビューイか。</value>
        bool Reviewee { get; }

        /// <summary>
        /// メンバーは確認者かを取得します。
        /// </summary>
        /// <value>メンバーは確認者か。</value>
        bool Moderator { get; }

        /// <summary>
        /// カスタムロール1の値を取得します。
        /// </summary>
        /// <value>カスタムロール1の値。</value>
        bool CustomRole1 { get; }

        /// <summary>
        /// カスタムロール2の値を取得します。
        /// </summary>
        /// <value>カスタムロール2の値。</value>
        bool CustomRole2 { get; }

        /// <summary>
        /// カスタムロール3の値を取得します。
        /// </summary>
        /// <value>カスタムロール3の値。</value>
        bool CustomRole3 { get; }

        /// <summary>
        /// カスタムロール4の値を取得します。
        /// </summary>
        /// <value>カスタムロール4の値。</value>
        bool CustomRole4 { get; }

        /// <summary>
        /// カスタムロール5の値を取得します。
        /// </summary>
        /// <value>カスタムロール5の値。</value>
        bool CustomRole5 { get; }

        /// <summary>
        /// カスタムテキスト1の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト1の値。</value>
        string CustomText1 { get; }

        /// <summary>
        /// カスタムテキスト2の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト2の値。</value>
        string CustomText2 { get; }

        /// <summary>
        /// カスタムテキスト3の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト3の値。</value>
        string CustomText3 { get; }

        /// <summary>
        /// カスタムテキスト4の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト4の値。</value>
        string CustomText4 { get; }

        /// <summary>
        /// カスタムテキスト5の値を取得します。
        /// </summary>
        /// <value>カスタムテキスト5の値。</value>
        string CustomText5 { get; }

        /// <summary>
        /// UI非表示な情報をタグとして取得します。
        /// </summary>
        /// <value>UI非表示な情報。</value>
        string Tag { get; }

        #endregion
    }
}