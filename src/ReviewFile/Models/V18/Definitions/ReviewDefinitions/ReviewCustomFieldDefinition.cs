using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// レビューのカスタムフィールドの定義
    /// </summary>
    public class ReviewCustomFieldDefinition : EntityBase, IReviewCustomFieldDefinition
    {
        #region 定数定義

        /// <summary>
        /// Groupプロパティの初期値
        /// </summary>
        private const string c_DefaultGroup = "基本設定";

        #endregion

        #region プロパティ

        /// <summary>
        /// 表示名
        /// </summary>
        [XmlElement]
        public string DisplayName { get; set; }

        /// <summary>
        /// 選択肢のリストを改行区切りで連結した文字列
        /// </summary>
        /// <remarks>
        /// 文字列中の選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> AllowedValues
        {
            get
            {
                var allowedValues = new List<string>();

                foreach (var fieldItem in ReviewCustomFieldDefinitionItems.ListItems)
                {
                    allowedValues.Add(fieldItem.Name);
                }

                return allowedValues;
            }
        }

        /// <summary>
        /// フィールドを使用するか否か
        /// </summary>
        [XmlElement]
        public string UseThisField { get; set; }

        /// <inheritdoc />
        public bool Enabled => bool.TryParse(UseThisField, out var result) ? result : false;

        /// <summary>
        /// 所属するグループ
        /// </summary>
        /// <remarks>
        /// この属性は、対応するレビューファイルの設定値を一度も変更していない場合、初期値が空文字列となる。
        /// 空文字列の場合は、初期値の"基本設定"に変換したいため、いったん本プロパティでデシリアライズしている。
        /// </remarks>
        [XmlElement("Group")]
        public string GroupString { get; set; }

        /// <summary>
        /// 所属するグループ
        /// </summary>
        /// <value>
        /// 所属するグループの値域を以下に示します。
        /// [値域]
        /// 基本設定
        /// プロジェクト
        /// 計画と実績 
        /// </value>
        public string Group => string.IsNullOrEmpty(GroupString) ? c_DefaultGroup : GroupString;

        /// <summary>
        /// フィールドの選択肢の一覧
        /// </summary>
        [XmlElement("ListItems")]
        public DefinitionListItems ReviewCustomFieldDefinitionItems { get; set; }

        #endregion
    }
}