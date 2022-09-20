using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.IssueDefinitions
{
    /// <summary>
    /// 指摘の定義
    /// </summary>
    [XmlRoot]
    public class IssueDefinition : EntityBase
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
        [XmlElement]
        public Fields Fields { get; set; }

        /// <summary>
        /// 分類のデフォルト値
        /// </summary>
        public string CategoryDefaultValue => Fields.FieldDefinitions
            .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_CategoryDefinitionName).DefaultValue;
        
        /// <summary>
        /// 分類の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> CategoryAllowedValues => Fields.FieldDefinitions
	        .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_CategoryDefinitionName).AllowedValues;

        /// <summary>
        /// 検出工程のデフォルト値
        /// </summary>
        public string DetectionActivityDefaultValue => Fields.FieldDefinitions
	        .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_DetectionActivityDefinitionName).DefaultValue;
        
        /// <summary>
        /// 検出工程の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> DetectionActivityAllowedValues => Fields.FieldDefinitions
	        .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_DetectionActivityDefinitionName).AllowedValues;

        /// <summary>
        /// 原因工程のデフォルト値
        /// </summary>
        public string InjectionActivityDefaultValue => Fields.FieldDefinitions
	        .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_InjectionActivityDefinitionName).DefaultValue;
        
        /// <summary>
        /// 原因工程の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> InjectionActivityAllowedValues => Fields.FieldDefinitions
	        .FirstOrDefault(fieldDefinition => fieldDefinition.Name == c_InjectionActivityDefinitionName).AllowedValues;

        /// <summary>
        /// カスタムフィールドの定義一覧
        /// </summary>
	    public IEnumerable<IIssueCustomFieldDefinition> CustomFieldDefinitions
        {
            get
            {
                // フィールド定義全体から、"CustomText1～20"のフィールド定義のみ取り出して返す
                return Fields.FieldDefinitions.Where(fieldDefinition => fieldDefinition.Name.StartsWith(c_CustomFieldDefinitionName));
            }
        }

        #endregion
    }
}
