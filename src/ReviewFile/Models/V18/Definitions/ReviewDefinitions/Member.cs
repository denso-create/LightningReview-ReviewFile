using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// メンバ
    /// </summary>
    [XmlRoot]
    public class Member : EntityBase, IReviewMember
    {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 報告者
        /// </summary>
        [XmlElement]
        public string Reviewer { get; set; }

        /// <summary>
        /// 修正者
        /// </summary>
        [XmlElement]
        public string Reviewee { get; set; }

        /// <summary>
        /// 確認者
        /// </summary>
        [XmlElement]
        public string Moderator { get; set; }

        /// <summary>
        /// UI非表示な情報をタグとして取得
        /// </summary>
        [XmlElement]
        public string Tag { get; set; }

        #region カスタムフィールド

        /// <summary>
        /// カスタムロール1
        /// </summary>
        [XmlElement] 
        public string CustomRole1 { get; set;  }

        /// <summary>
        /// カスタムロール2
        /// </summary>
        [XmlElement]
        public string CustomRole2 { get; set;  }

        /// <summary>
        /// カスタムロール3
        /// </summary>
        [XmlElement]
        public string CustomRole3 { get; set;  }

        /// <summary>
        /// カスタムロール4
        /// </summary>
        [XmlElement]
        public string CustomRole4 { get; set;  }

        /// <summary>
        /// カスタムロール5
        /// </summary>
        [XmlElement]
        public string CustomRole5 { get; set;  }

        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        [XmlElement]
        public string CustomText1 { get; set; }

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        [XmlElement]
        public string CustomText2 { get; set; }

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        [XmlElement]
        public string CustomText3 { get; set; }

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        [XmlElement]
        public string CustomText4 { get; set; }

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        [XmlElement]
        public string CustomText5 { get; set; }

        #endregion
    }
}
