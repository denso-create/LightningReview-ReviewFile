using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// レビューのカスタムフィールドの定義
    /// </summary>
    public class ReviewCustomFieldDefinition : EntityBase, IReviewCustomFieldDefinition
    {
        #region プロパティ

        /// <summary>
        /// 表示名
        /// </summary>
        [XmlElement]
        private string DisplayName { get; set; }

        /// <summary>
        /// 選択肢のリストを改行区切りで連結した文字列
        /// </summary>
        /// <remarks>
        /// 文字列中の選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        IEnumerable<string> AllowedValues
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
        [XmlElement("UseThisField")]
        private string Enabled { get; set; }

        /// <summary>
        /// 所属するグループ
        /// </summary>
        /// <value>
        /// 所属するグループ。
        /// [値域]            [値に対応するグループ]
        /// General           基本設定
        /// Project           プロジェクト
        /// PlanAndActual     計画と実績 
        /// </value>
        [XmlElement]
        private string Group { get; set; }

        /// <summary>
        /// フィールドの選択肢の一覧
        /// </summary>
        [XmlElement("ListItems")]
        public DefinitionListItems ReviewCustomFieldDefinitionItems { get; set; }

        #endregion
    }
}