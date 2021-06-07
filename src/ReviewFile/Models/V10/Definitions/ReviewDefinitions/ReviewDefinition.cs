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
        /// メンバ一覧
        /// </summary>
        [XmlArray("Members")]
        [XmlArrayItem("Member")]
        public List<Member> Members{ get; set; }

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
        /// レビューのステータス一覧
        /// </summary>
        [XmlArray("Status")]
        [XmlArrayItem("Status")]
        public List<ReviewStatus> StatusList { get; set; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string Status
        {
            get
            {
                foreach (var status in StatusList)
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
        /// レビュ形式一覧
        /// </summary>
        [XmlArray("ReviewStyles")]
        [XmlArrayItem("ReviewStyle")]
        public List<ReviewStyle> ReviewStyles { get; set; }

        /// <summary>
        /// レビュ形式
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

    }
}
