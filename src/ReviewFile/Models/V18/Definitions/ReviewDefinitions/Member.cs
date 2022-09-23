using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// メンバ
    /// </summary>
    [XmlRoot]
    public class Member : EntityBase, IReviewMember
    {
        /// <inheritdoc />
        [XmlElement]
        public string Name { get; set; }

        /// <inheritdoc cref="Reviewer" />
        [XmlElement("Reviewer")]
        public string ReviewerString { get; set; }

        /// <inheritdoc />
        public bool Reviewer => bool.TryParse(ReviewerString, out var result) ? result : false;

        /// <inheritdoc cref="Reviewee"/>
        [XmlElement("Reviewee")]
        public string RevieweeString { get; set; }

        /// <inheritdoc />
        public bool Reviewee => bool.TryParse(RevieweeString, out var result) ? result : false;

        /// <inheritdoc cref="Moderator"/>
        [XmlElement("Moderator")]
        public string ModeratorString { get; set; }

        /// <inheritdoc />
        public bool Moderator => bool.TryParse(ModeratorString, out var result) ? result : false;

        /// <inheritdoc />
        /// <remarks>
        /// タグの定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// タグの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        [XmlElement]
        public string Tag { get; set; } = string.Empty;

        #region カスタムフィールド

        /// <inheritdoc cref="CustomRole1" />
        [XmlElement("CustomRole1")]
        public string CustomRole1String { get; set; }

        /// <inheritdoc />
        public bool CustomRole1 => bool.TryParse(CustomRole1String, out var result) ? result : false;

        /// <inheritdoc cref="CustomRole2" />
        [XmlElement("CustomRole2")]
        public string CustomRole2String { get; set; }

        /// <inheritdoc />
        public bool CustomRole2 => bool.TryParse(CustomRole2String, out var result) ? result : false;

        /// <inheritdoc cref="CustomRole3" />
        [XmlElement("CustomRole3")]
        public string CustomRole3String { get; set; }

        /// <inheritdoc />
        public bool CustomRole3 => bool.TryParse(CustomRole3String, out var result) ? result : false;

        /// <inheritdoc cref="CustomRole4" />
        [XmlElement("CustomRole4")]
        public string CustomRole4String { get; set; }

        /// <inheritdoc />
        public bool CustomRole4 => bool.TryParse(CustomRole4String, out var result) ? result : false;

        /// <inheritdoc cref="CustomRole5" />
        [XmlElement("CustomRole5")]
        public string CustomRole5String { get; set; }

        /// <inheritdoc />
        public bool CustomRole5 => bool.TryParse(CustomRole5String, out var result) ? result : false;

        /// <inheritdoc />
        /// <remarks>
        /// カスタムテキスト1以降の定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// カスタムテキストの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        [XmlElement]
        public string CustomText1 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText2 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText3 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText4 { get; set; } = string.Empty;

        /// <inheritdoc />
        [XmlElement]
        public string CustomText5 { get; set; } = string.Empty;

        #endregion
    }
}
