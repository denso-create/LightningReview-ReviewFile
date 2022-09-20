using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions.ReviewDefinitions
{
    /// <summary>
    /// メンバ
    /// </summary>
    [XmlRoot]
    public class Member : IReviewMember
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 報告者
        /// </summary>
        [XmlAttribute("Reviewer")]
        public string ReviewerString { get; set; }

        /// <inheritdoc />
        public bool Reviewer => bool.TryParse(ReviewerString, out var result) ? result : false;

        /// <summary>
        /// 修正者
        /// </summary>
        [XmlAttribute("Reviewee")]
        public string RevieweeString { get; set; }

        /// <inheritdoc />
        public bool Reviewee => bool.TryParse(RevieweeString, out var result) ? result : false;

        /// <summary>
        /// 確認者
        /// </summary>
        [XmlAttribute("Moderator")]
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
        public string Tag => string.Empty;

        #region カスタムフィールド

        /// <summary>
        /// カスタムロール1
        /// </summary>
        /// <remarks>
        /// カスタムロール1以降の定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// カスタムロールの値が未設定の状態とXML属性が存在しない状態を一貫させるため、falseを返す。
        /// </remarks>
        public bool CustomRole1 => false;

        /// <summary>
        /// カスタムロール2
        /// </summary>
        public bool CustomRole2 => false;

        /// <summary>
        /// カスタムロール3
        /// </summary>
        public bool CustomRole3 => false;

        /// <summary>
        /// カスタムロール4
        /// </summary>
        public bool CustomRole4 => false;

        /// <summary>
        /// カスタムロール5
        /// </summary>
        public bool CustomRole5 => false;

        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        /// <remarks>
        /// カスタムテキスト1以降の定義がないバージョンのレビューファイルを開いた場合は、該当のXML属性が存在しないためnullとなる。
        /// カスタムテキストの値が未設定の状態とXML属性が存在しない状態を一貫させるため、string.Emptyを返す。
        /// </remarks>
        public string CustomText1 => string.Empty;

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        public string CustomText2 => string.Empty;

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        public string CustomText3 => string.Empty;

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        public string CustomText4 => string.Empty;

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        public string CustomText5 => string.Empty;

        #endregion
    }
}
