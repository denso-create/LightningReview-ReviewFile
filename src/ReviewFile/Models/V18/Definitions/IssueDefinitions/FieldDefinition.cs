using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.IssueDefinitions
{
    /// <summary>
    /// フィールド定義
    /// </summary>
    [XmlRoot]
    public class FieldDefinition : EntityBase, IIssueCustomFieldDefinition
    {
        /// <inheritdoc cref="Enabled" />
        [XmlElement]
        public string UseThisField { get; set; }

        /// <inheritdoc />
        public bool Enabled => bool.TryParse(UseThisField, out var result) ? result : false;

        /// <summary>
        /// フィールド名
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <inheritdoc />
        [XmlElement]
        public string DisplayName { get; set; }

        /// <inheritdoc />
        public IEnumerable<string> AllowedValues
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

        /// <inheritdoc />
        public string DefaultValue
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
