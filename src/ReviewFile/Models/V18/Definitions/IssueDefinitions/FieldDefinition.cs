﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.IssueDefinitions
{
    /// <summary>
    /// フィールド定義
    /// </summary>
    [XmlRoot]
    public class FieldDefinition : EntityBase, IIssueCustomFieldDefinition
    {
        /// <summary>
        /// フィールドを使用するか否か
        /// </summary>
        [XmlElement("UseThisField")]
        public string Enabled { get; set; }

        /// <summary>
        /// フィールド名
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

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
        IEnumerable<string> AllowedValues
        {
            get
            {
                var allowedValues = new List<string>();

                foreach (var fieldItem in FieldDefinitionItems.ListItems)
                {
                    allowedValues.Add(fieldItem.Name);
                }

                return allowedValues;
            }
        }

        /// <summary>
        /// デフォルト値
        /// </summary>
        string DefaultValue
        {
            get
            {
                foreach (var fieldItem in FieldDefinitionItems.ListItems)
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
        [XmlElement("ListItems")]
        public DefinitionListItems FieldDefinitionItems { get; set; }

    }
}
