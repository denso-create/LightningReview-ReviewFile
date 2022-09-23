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
        /// フィールド名
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <inheritdoc cref="Enabled" />
        [XmlElement]
        public string UseThisField { get; set; }

        /// <inheritdoc />
        public bool Enabled => bool.TryParse(UseThisField, out var result) ? result : false;

        /// <inheritdoc />
        [XmlElement]
        public string DisplayName { get; set; }

        /// <inheritdoc />
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

        /// <inheritdoc />
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