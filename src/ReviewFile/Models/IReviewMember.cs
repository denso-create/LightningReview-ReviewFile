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
        string Name { get; }

        /// <summary>
        /// メンバーはレビューワかを取得します。
        /// </summary>
        bool Reviewer { get; }

        /// <summary>
        /// メンバーはレビューイかを取得します。
        /// </summary>
        bool Reviewee { get; }

        /// <summary>
        /// メンバーは確認者かを取得します。
        /// </summary>
        bool Moderator { get; }

        /// <summary>
        /// カスタムロール1の値を取得します。
        /// </summary>
        bool CustomRole1 { get; }

        /// <summary>
        /// カスタムロール2の値を取得します。
        /// </summary>
        bool CustomRole2 { get; }

        /// <summary>
        /// カスタムロール3の値を取得します。
        /// </summary>
        bool CustomRole3 { get; }

        /// <summary>
        /// カスタムロール4の値を取得します。
        /// </summary>
        bool CustomRole4 { get; }

        /// <summary>
        /// カスタムロール5の値を取得します。
        /// </summary>
        bool CustomRole5 { get; }

        /// <summary>
        /// カスタムテキスト1の値を取得します。
        /// </summary>
        string CustomText1 { get; }

        /// <summary>
        /// カスタムテキスト2の値を取得します。
        /// </summary>
        string CustomText2 { get; }

        /// <summary>
        /// カスタムテキスト3の値を取得します。
        /// </summary>
        string CustomText3 { get; }

        /// <summary>
        /// カスタムテキスト4の値を取得します。
        /// </summary>
        string CustomText4 { get; }

        /// <summary>
        /// カスタムテキスト5の値を取得します。
        /// </summary>
        string CustomText5 { get; }

        /// <summary>
        /// UI非表示な情報をタグとして取得します。
        /// </summary>
        string Tag { get; }

        #endregion
    }
}