using System.Collections.Generic;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V10.Definitions.ReviewDefinitions
{
    /// <summary>
    /// レビューの定義
    /// </summary>
    [XmlRoot]
    public class ReviewDefinition
    {
        /// <summary>
        /// レビュー種別一覧
        /// </summary>
        [XmlArray("ReviewTypes")]
        [XmlArrayItem("ReviewType")]
        public List<ReviewType> ReviewTypes { get; set; }

        /// <summary>
        /// レビュー種別
        /// </summary>
        public string ReviewType
        {
            get
            {
                foreach (var reviewTypes in ReviewTypes)
                {
                    if (reviewTypes.Default == "true")
                    {
                        return reviewTypes.Name;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// レビュー種別の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> ReviewTypeAllowedValues
        {
            get
            {
                var allowedValues = new List<string>();

                foreach (var reviewTypeItem in ReviewTypes)
                {
                    allowedValues.Add(reviewTypeItem.Name);
                }

                return allowedValues;
            }
        }

        /// <summary>
        /// メンバ一覧
        /// </summary>
        [XmlArray("Members")]
        [XmlArrayItem("Member")]
        public List<Member> Members { get; set; }

        /// <summary>
        /// ドメイン一覧
        /// </summary>
        [XmlArray("Domains")]
        [XmlArrayItem("Domain")]
        public List<Domain> Domains { get; set; }

        /// <summary>
        /// ドメイン
        /// </summary>
        public string Domain
        {
            get
            {
                foreach (var domain in Domains)
                {
                    if (domain.Default == "true")
                    {
                        return domain.Name;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// ドメインの選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> DomainAllowedValues
        {
            get
            {
                var allowedValues = new List<string>();

                foreach (var domainItem in Domains)
                {
                    allowedValues.Add(domainItem.Name);
                }

                return allowedValues;
            }
        }

        /// <summary>
        /// レビューのステータス一覧
        /// </summary>
        [XmlArray("Status")]
        [XmlArrayItem("Status")]
        public List<ReviewStatus> ReviewStatus { get; set; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string Status
        {
            get
            {
                foreach (var status in ReviewStatus)
                {
                    if (status.Default == "true")
                    {
                        return status.Name;
                    }
                }

                return string.Empty;
            }
        }
        
        /// <summary>
        /// レビューのステータスの選択肢一覧
        /// </summary>
        public IEnumerable<string> StatusAllowedValues
        {
            get
            {
                var allowedValues = new List<string>();

                foreach (var statusItem in ReviewStatus)
                {
                    allowedValues.Add(statusItem.Name);
                }

                return allowedValues;
            }
        }

        /// <summary>
        /// 現在設定されているレビューのステータス
        /// </summary>
        public IStatusItem StatusItem
        {
            get
            {
                foreach (var statusItem in ReviewStatus)
                {
                    if (statusItem.Default == "true")
                    {
                        return new ReviewStatusItem()
                        {
                            Name = statusItem.Name,
                            IsSelectedString = statusItem.Default,
                        };
                    }
                }

                // ステータスが未設定の場合、nullを返す
                return null;
            }
        }

        /// <summary>
        /// レビューのステータスの選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<IStatusItem> StatusItems
        {
            get
            {
                var allowedValues = new List<IStatusItem>();

                foreach (var statusItem in ReviewStatus)
                {
                    allowedValues.Add(new ReviewStatusItem()
                    {
                        Name = statusItem.Name,
                        IsSelectedString = statusItem.Default,
                    });
                }

                return allowedValues;
            }
        }

        /// <summary>
        /// レビュー形式一覧
        /// </summary>
        [XmlArray("ReviewStyles")]
        [XmlArrayItem("ReviewStyle")]
        public List<ReviewStyle> ReviewStyles { get; set; }

        /// <summary>
        /// レビュー形式
        /// </summary>
        public string ReviewStyle
        {
            get
            {
                foreach (var reviewStyles in ReviewStyles)
                {
                    if (reviewStyles.Default == "true")
                    {
                        return reviewStyles.Name;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// レビュー形式の選択肢一覧
        /// </summary>
        /// <remarks>
        /// 選択肢の出現順はリストの並び順と一致することを保証する
        /// </remarks>
        public IEnumerable<string> ReviewStyleAllowedValues
        {
	        get
	        {
		        var allowedValues = new List<string>();

		        foreach (var reviewStyleItem in ReviewStyles)
		        {
			        allowedValues.Add(reviewStyleItem.Name);
		        }

		        return allowedValues;
	        }
        }
    }
}
