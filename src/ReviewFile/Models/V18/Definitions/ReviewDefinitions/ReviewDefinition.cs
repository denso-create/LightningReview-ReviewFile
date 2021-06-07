using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions.ReviewDefinitions
{
    /// <summary>
    /// レビューの定義
    /// </summary>
    [XmlRoot]
    public class ReviewDefinition : EntityBase
    {
        /// <summary>
        /// レビュー形式一覧
        /// </summary>
        [XmlElement]
        public ReviewTypes ReviewTypes { get; set; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string ReviewType
        {
            get
            {
                foreach (var reviewTypeItem in ReviewTypes.ReviewTypeItems.ListItems)
                {
                    if (reviewTypeItem.Default == "True")
                    {
                        return reviewTypeItem.Name;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// メンバ一覧
        /// </summary>
        [XmlElement]
        public Members Members { get; set; }

        /// <summary>
        /// ドメイン一覧
        /// </summary>
        [XmlElement]
        public Domains Domains { get; set; }

        /// <summary>
        /// ドメイン
        /// </summary>
        public string Domain
        {
            get
            {
                foreach (var domainItem in Domains.DomainItems.ListItems)
                {
                    if (domainItem.Default == "True")
                    {
                        return domainItem.Name;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// レビューのステータス一覧
        /// </summary>
        [XmlElement("Status")]
        public ReviewStatus StatusList { get; set; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string Status
        {
            get
            {
                foreach (var statusItem in StatusList.ReviewStatusItems.ListItems)
                {
                    if (statusItem.Default == "True")
                    {
                        return statusItem.Name;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// レビュー形式一覧
        /// </summary>
        [XmlElement]
        public ReviewStyles ReviewStyles { get; set; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string ReviewStyle
        {
            get
            {
                foreach (var reviewStyleItem in ReviewStyles.ReviewStyleItems.ListItems)
                {
                    if (reviewStyleItem.Default == "True")
                    {
                        return reviewStyleItem.Name;
                    }
                }

                return string.Empty;
            }
        }
    }
}
