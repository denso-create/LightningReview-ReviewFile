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

        /// <inheritdoc />
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 設定日の文字列
        /// </summary>
        [XmlElement("SelectedOn")]
        public string SelectedOnString { get; set; }

        /// <inheritdoc />
        public DateTime? SelectedOn => DateTime.TryParse(SelectedOnString, out var result) ? result : (DateTime?)null;

        /// <inheritdoc />
        [XmlElement]
        public string SelectedBy { get; set; } = string.Empty;

        /// <inheritdoc cref="IsClosed" />
        [XmlElement("IsClosed")]
        public string IsClosedString { get; set; }

        /// <inheritdoc />
        public bool IsClosed => bool.TryParse(IsClosedString, out var result) ? result : false;

        /// <inheritdoc cref="IsSelected" />
        [XmlElement("IsSelected")]
        public string IsSelectedString { get; set; }

        /// <inheritdoc />
        public bool IsSelected => bool.TryParse(IsSelectedString, out var result) ? result : false;

        /// <inheritdoc cref="Color" />
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