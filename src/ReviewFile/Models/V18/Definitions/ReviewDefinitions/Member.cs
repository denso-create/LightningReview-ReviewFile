using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// メンバ
    /// </summary>
    [XmlRoot]
    public class Member : EntityBase, IReviewMember
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 報告者
        /// </summary>
        [XmlElement("Reviewer")]
        public string ReviewerString { get; set; }

        /// <inheritdoc />
        public bool Reviewer => bool.TryParse(ReviewerString, out var result) ? result : false;

        /// <summary>
        /// 修正者
        /// </summary>
        [XmlElement("Reviewee")]
        public string RevieweeString { get; set; }

        /// <inheritdoc />
        public bool Reviewee => bool.TryParse(RevieweeString, out var result) ? result : false;

        /// <summary>
        /// 確認者
        /// </summary>
        [XmlElement("Moderator")]
        public string ModeratorString { get; set; }

        /// <inheritdoc />
        public bool Moderator => bool.TryParse(ModeratorString, out var result) ? result : false;

        /// <summary>
        /// UI非表示な情報をタグとして取得
        /// </summary>
        /// <remarks>
        /// タグの定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// タグの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        [XmlElement]
        public string Tag { get; set; } = string.Empty;

        #region カスタムフィールド

        /// <summary>
        /// カスタムロール1
        /// </summary>
        [XmlElement("CustomRole1")]
        public string CustomRole1String { get; set; }

        /// <inheritdoc />
        public bool CustomRole1 => bool.TryParse(CustomRole1String, out var result) ? result : false;

        /// <summary>
        /// カスタムロール2
        /// </summary>
        [XmlElement("CustomRole2")]
        public string CustomRole2String { get; set; }

        /// <inheritdoc />
        public bool CustomRole2 => bool.TryParse(CustomRole2String, out var result) ? result : false;

        /// <summary>
        /// カスタムロール3
        /// </summary>
        [XmlElement("CustomRole3")]
        public string CustomRole3String { get; set; }

        /// <inheritdoc />
        public bool CustomRole3 => bool.TryParse(CustomRole3String, out var result) ? result : false;

        /// <summary>
        /// カスタムロール4
        /// </summary>
        [XmlElement("CustomRole4")]
        public string CustomRole4String { get; set; }

        /// <inheritdoc />
        public bool CustomRole4 => bool.TryParse(CustomRole4String, out var result) ? result : false;

        /// <summary>
        /// カスタムロール5
        /// </summary>
        [XmlElement("CustomRole5")]
        public string CustomRole5String { get; set; }

        /// <inheritdoc />
        public bool CustomRole5 => bool.TryParse(CustomRole5String, out var result) ? result : false;

        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        /// <remarks>
        /// カスタムテキスト1以降の定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// カスタムテキストの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyで初期化する。
        /// </remarks>
        [XmlElement]
        public string CustomText1 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        [XmlElement]
        public string CustomText2 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        [XmlElement]
        public string CustomText3 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        [XmlElement]
        public string CustomText4 { get; set; } = string.Empty;

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        [XmlElement]
        public string CustomText5 { get; set; } = string.Empty;

        #endregion
    }
}
