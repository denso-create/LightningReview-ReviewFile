using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions.IssueDefinitions
{
    /// <summary>
    /// 指摘の定義
    /// </summary>
    [XmlRoot]
    public class IssueDefinition
    {
        #region 定数定義

        /// <summary>
        /// 分類に対応するフィールド定義の名前
        /// </summary>
        private const string c_CategoryDefinitionName = "Category";

        /// <summary>
        /// 検出工程に対応するフィールド定義の名前
        /// </summary>
        private const string c_DetectionActivityDefinitionName = "DetectionActivity";

        /// <summary>
        /// 原因工程に対応するフィールド定義の名前
        /// </summary>
        private const string c_InjectionActivityDefinitionName = "InjectionActivity";

        /// <summary>
        /// カスタムフィールドに対応するフィールド定義の名前
        /// </summary>
        private const string c_CustomFieldDefinitionName = "CustomText";

        #endregion

        #region プロパティ

        /// <summary>
        /// 指摘のフィールドの定義一覧
        /// </summary>
        [XmlArray("Fields")]
        [XmlArrayItem("Field")]
        public List<Field> Fields { get; set; }

        /// <summary>
        /// 分類のデフォルト値
        /// </summary>
        public string CategoryDefaultValue => Fields
	        .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_CategoryDefinitionName).DefaultValue;

        /// <summary>
        /// 分類の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> CategoryAllowedValues => Fields
	        .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_CategoryDefinitionName).AllowedValues;

        /// <summary>
        /// 検出工程のデフォルト値
        /// </summary>
        public string DetectionActivityDefaultValue => Fields
            .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_DetectionActivityDefinitionName).DefaultValue;

        /// <summary>
        /// 検出工程の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> DetectionActivityAllowedValues => Fields
            .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_DetectionActivityDefinitionName).AllowedValues;

        /// <summary>
        /// 原因工程のデフォルト値
        /// </summary>
        public string InjectionActivityDefaultValue => Fields
            .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_InjectionActivityDefinitionName).DefaultValue;

        /// <summary>
        /// 原因工程の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> InjectionActivityAllowedValues => Fields
            .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_InjectionActivityDefinitionName).AllowedValues;

        /// <summary>
        /// カスタムフィールドの定義一覧
        /// </summary>
	    public IEnumerable<IIssueCustomFieldDefinition> CustomFieldDefinitions
        {
            get
            {
                // フィールド定義全体から、"CustomText1～10"のフィールド定義のみ取り出して返す
                return Fields.Where(fieldDefinition => fieldDefinition.Name.StartsWith(c_CustomFieldDefinitionName));
            }
        }

        #endregion
    }
}