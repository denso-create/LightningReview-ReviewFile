using System;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// V2.0以降のレビューのステータスの定義
    /// </summary>
    public class ReviewStatusItem : EntityBase, IStatusItem
    {
	    #region 定数定義

        /// <summary>
        /// Colorプロパティの初期値
        /// </summary>
	    private const string c_DefaultColor = "なし";

	    #endregion

	    #region プロパティ

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
        public DateTime? SelectedOn => DateTime.TryParse(SelectedOnString, out var result) ? result : (DateTime?)null;

        /// <summary>
        /// 設定者
        /// </summary>
        [XmlElement]
        public string SelectedBy { get; set; } = string.Empty;

        /// <summary>
        /// クローズを意味するステータスか
        /// </summary>
        [XmlElement("IsClosed")]
        public string IsClosedString { get; set; }

        /// <inheritdoc />

        public bool IsClosed => bool.TryParse(IsClosedString, out var result) ? result : false;

        /// <summary>
        /// このステータスが、現在のステータスとして設定されているか
        /// </summary>
        [XmlElement("IsSelected")]
        public string IsSelectedString { get; set; }

        /// <inheritdoc />
        public bool IsSelected => bool.TryParse(IsSelectedString, out var result) ? result : false;

        /// <summary>
        /// ステータスの色
        /// </summary>
        /// <value>
        /// 色の種類の文字列。
        /// 本プロパティの値域を以下に示します。
        /// [値域]
        /// なし
        /// 赤
        /// 橙
        /// 黄
        /// 緑
        /// 青
        /// 紫
        /// 灰
        /// 薄い赤
        /// 薄い橙
        /// 薄い黄
        /// 薄い緑
        /// 薄い青
        /// 薄い紫
        /// 薄い灰
        /// </value>
        /// <remarks>
        /// この属性は、対応するレビューファイルの設定値を一度も変更していない場合、初期値が空文字列となる。
        /// 空文字列の場合は、初期値の"なし"に変換したいため、いったん本プロパティでデシリアライズしている。
        /// </remarks>
        [XmlElement("Color")]
        public string ColorString { get; set; }

        /// <inheritdoc />
        public string Color => string.IsNullOrEmpty(ColorString) ? c_DefaultColor : ColorString;

        #endregion
    }
}