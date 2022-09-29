using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions.ReviewDefinitions
{
    /// <summary>
    /// メンバ
    /// </summary>
    [XmlRoot]
    public class Member : IReviewMember
    {
        /// <inheritdoc />
        [XmlAttribute]
        public string Name { get; set; }

        /// <inheritdoc cref="Reviewer" />
        [XmlAttribute("Reviewer")]
        public string ReviewerString { get; set; }

        /// <inheritdoc />
        public bool Reviewer => bool.TryParse(ReviewerString, out var result) ? result : false;

        /// <inheritdoc cref="Reviewee"/>
        [XmlAttribute("Reviewee")]
        public string RevieweeString { get; set; }

        /// <inheritdoc />
        public bool Reviewee => bool.TryParse(RevieweeString, out var result) ? result : false;

        /// <inheritdoc cref="Moderator"/>
        [XmlAttribute("Moderator")]
        public string ModeratorString { get; set; }

        /// <inheritdoc />
        public bool Moderator => bool.TryParse(ModeratorString, out var result) ? result : false;

        /// <inheritdoc />
        /// <remarks>
        /// V10ではタグの定義が存在せず、nullとなる。
        /// タグの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        public string Tag => string.Empty;

        #region カスタムフィールド

        /// <inheritdoc />
        /// <remarks>
        /// V10ではカスタムロール1以降のの定義が存在せず、nullとなる。
        /// カスタムロールの値が未設定の状態とXML属性が存在しない状態を一貫させるため、falseを返す。
        /// </remarks>
        public bool CustomRole1 => false;

        /// <inheritdoc />
        public bool CustomRole2 => false;

        /// <inheritdoc />
        public bool CustomRole3 => false;

        /// <inheritdoc />
        public bool CustomRole4 => false;

        /// <inheritdoc />
        public bool CustomRole5 => false;

        /// <inheritdoc />
        /// <remarks>
        /// V10ではカスタムテキスト1以降の定義が存在せず、nullとなる。
        /// カスタムテキストの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyを返す。
        /// </remarks>
        public string CustomText1 => string.Empty;

        /// <inheritdoc />
        public string CustomText2 => string.Empty;

        /// <inheritdoc />
        public string CustomText3 => string.Empty;

        /// <inheritdoc />
        public string CustomText4 => string.Empty;

        /// <inheritdoc />
        public string CustomText5 => string.Empty;

        #endregion
    }
}
