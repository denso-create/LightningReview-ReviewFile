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
	    /// <summary>
	    /// 指摘のフィールドの定義一覧
	    /// </summary>
	    [XmlElement]
	    public Fields Fields { get; set; }

        /// <summary>
        /// カスタムフィールドの定義一覧
        /// </summary>
	    public IEnumerable<IIssueCustomFieldDefinition> CustomFieldDefinitions{
		    get
		    {
			    // フィールド定義全体から、"CustomText1～20"のフィールド定義のみ取り出して返す
			    return Fields.FieldDefinitions.Where( fieldDefinition => fieldDefinition.Name.StartsWith("CustomText"));
		    }
	    }
    }
}
