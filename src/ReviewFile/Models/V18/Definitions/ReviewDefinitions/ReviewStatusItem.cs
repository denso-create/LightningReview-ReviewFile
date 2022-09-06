using System;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// V2.0以降のレビューのステータスの定義
    /// </summary>
    public class ReviewStatusItem : EntityBase, IStatusItem
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 設定日の文字列
        /// </summary>
        [XmlElement("SelectedOn")]
        public string SelectedOnString { get; set; }

        /// <summary>
        /// 設定日
        /// </summary>
        public DateTime? SelectedOn =>string.IsNullOrEmpty(SelectedOnString) ? (DateTime?)null : DateTime.Parse(SelectedOnString);

        /// <summary>
        /// 設定者
        /// </summary>
        [XmlElement]
        public string SelectedBy { get; set; }

        /// <summary>
        /// クローズを意味するステータスか
        /// </summary>
        [XmlElement]
        public string IsClosed { get; set; }

        /// <summary>
        /// このステータスが、現在のステータスとして設定されているか
        /// </summary>
        [XmlElement]
        public string IsSelected { get; set; }

        /// <summary>
        /// ステータスの色
        /// </summary>
        /// <value>
        /// 色の種類の文字列。
        /// 本プロパティの値域と、それぞれの値に対応する種類を以下に示します。
        /// [値域]      [値に対応する種類]
        /// None        なし
        /// Red         赤
        /// Orange      橙
        /// Yellow      黄
        /// Green       緑
        /// Blue        青
        /// Purple      紫
        /// Gray        灰
        /// LightRed    薄い赤
        /// LightOrange 薄い橙
        /// LightYellow 薄い黄
        /// LightGreen  薄い緑
        /// LightBlue   薄い青
        /// LightPurple 薄い紫
        /// LightGray   薄い灰
        /// </value>
        [XmlElement]
        public string Color { get; set; }
    }
}