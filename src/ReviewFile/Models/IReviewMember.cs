namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// メンバのインタフェース
    /// </summary>
	public interface IReviewMember
    {
        #region 公開プロパティ

        /// <summary>
        /// メンバーの名前
        /// </summary>
        string Name { get; }

        /// <summary>
        /// メンバーはレビューワか
        /// </summary>
        string Reviewer { get; }

        /// <summary>
        /// メンバーはレビューイか
        /// </summary>
        string Reviewee { get; }

        /// <summary>
        /// メンバーは確認者か
        /// </summary>
        string Moderator { get; }

        /// <summary>
        /// カスタムロール1
        /// </summary>
        string CustomRole1 { get; }

        /// <summary>
        /// カスタムロール2
        /// </summary>
        string CustomRole2 { get; }

        /// <summary>
        /// カスタムロール3
        /// </summary>
        string CustomRole3 { get; }

        /// <summary>
        /// カスタムロール4
        /// </summary>
        string CustomRole4 { get; }

        /// <summary>
        /// カスタムロール5
        /// </summary>
        string CustomRole5 { get; }

        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        string CustomText1 { get; }

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        string CustomText2 { get; }

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        string CustomText3 { get; }

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        string CustomText4 { get; }

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        string CustomText5 { get; }

        /// <summary>
        /// UI非表示な情報
        /// </summary>
        string Tag { get; }

        #endregion
    }
}