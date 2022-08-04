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
        /// V2.0より前のバージョンのレビューのステータス一覧
        /// </summary>
        [XmlElement("Status")]
        public ReviewStatus StatusList { get; set; }
        
        /// <summary>
        /// V2.0以降のレビューのステータス一覧
        /// </summary>
        [XmlElement] 
        public ReviewStatusItems StatusItems { get; set; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string Status
        {
            get
            { 
	            // V2.0以降で1度でも保存されていた場合、
	            // V2.0以降の選択されたステータスの文字列を取得する
	            if (StatusItems != null)
	            {
                    foreach (var statusItem in StatusItems.ReviewStatusItemList)
                    {
                        if (statusItem.IsSelected == "True")
                        {
                            return statusItem.Name;
                        }
                    }

                    // V2.0以降で保存されていたがステータスが未設定の場合、空文字を返す
                    return string.Empty;
	            }
				
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
        /// レビューの形式
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
