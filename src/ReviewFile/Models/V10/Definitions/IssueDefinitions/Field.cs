using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions.IssueDefinitions
{
    /// <summary>
    /// フィールド定義
    /// </summary>
    [XmlRoot]
    public class Field : IIssueCustomFieldDefinition
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// フィールドを使用するか否か
        /// </summary>
        [XmlElement]
        public string UseThisField { get; set; }

        /// <inheritdoc />
        public bool Enabled => bool.TryParse(UseThisField, out var result) ? result : false;

        /// <summary>
        /// 表示名
        /// </summary>
        [XmlElement]
        public string DisplayName { get; set; }

        /// <summary>
        /// 選択肢のリスト
        /// </summary>
        /// <remarks>
        /// 文字列中の選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> AllowedValues
        {
            get
            {
                var allowedValues = new List<string>();

                foreach (var fieldItem in FieldDefinitionItems)
                {
                    allowedValues.Add(fieldItem.Name);
                }

                return allowedValues;
            }
        }

        /// <summary>
        /// デフォルト値
        /// </summary>
        public string DefaultValue
        {
            get
            {
                foreach (var fieldItem in FieldDefinitionItems)
                {
                    if (fieldItem.Default == "True")
                    {
                        return fieldItem.Name;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// フィールドの選択肢の一覧
        /// </summary>
        [XmlArray("ListItems")]
        [XmlArrayItem("ListItem")]
        public List<DefinitionListItem> FieldDefinitionItems { get; set; }
    }
}