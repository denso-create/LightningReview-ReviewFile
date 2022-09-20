using System;
using System.Collections.Generic;
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

                foreach (var reviewTypeItem in ReviewTypes.ReviewTypeItems.ListItems)
                {
                    allowedValues.Add(reviewTypeItem.Name);
                }

                return allowedValues;
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

                foreach (var domainItem in Domains.DomainItems.ListItems)
                {
                    allowedValues.Add(domainItem.Name);
                }

                return allowedValues;
            }
        }

        /// <summary>
        /// V2.0より前のバージョンのレビューのステータス一覧
        /// </summary>
        [XmlElement("Status")]
        public ReviewStatus ReviewStatus { get; set; }

        /// <summary>
        /// V2.0以降のレビューのステータス一覧
        /// </summary>
        [XmlElement("StatusItems")]
        public ReviewStatusItems ReviewStatusItems { get; set; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string Status
        {
            get
            {
                // V2.0以降で1度でも保存されていた場合、
                // V2.0以降の選択されたステータスの文字列を取得する
                if (ReviewStatusItems != null)
                {
                    foreach (var statusItem in ReviewStatusItems.ReviewStatusItemList)
                    {
                        if (statusItem.IsSelected)
                        {
                            return statusItem.Name;
                        }
                    }

                    // V2.0以降で保存されていたがステータスが未設定の場合、空文字を返す
                    return string.Empty;
                }

                foreach (var statusItem in ReviewStatus.ReviewStatusItems.ListItems)
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
        /// レビューのステータスの選択肢一覧
        /// </summary>
        public IEnumerable<string> StatusAllowedValues
        {
            get
            {
                var allowedValues = new List<string>();

                // V2.0以降で1度でも保存されていた場合、
                // V2.0以降の選択されたステータスの文字列から選択肢の一覧を作成して返す
                if (ReviewStatusItems != null)
                {
                    foreach (var statusItem in ReviewStatusItems.ReviewStatusItemList)
                    {
                        allowedValues.Add(statusItem.Name);
                    }

                    return allowedValues;
                }

                foreach (var statusItem in ReviewStatus.ReviewStatusItems.ListItems)
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
                // V2.0以降で1度でも保存されていた場合、
                // V2.0以降の選択されたステータスを返す
                if (ReviewStatusItems != null)
                {
                    foreach (var statusItem in ReviewStatusItems.ReviewStatusItemList)
                    {
                        if (statusItem.IsSelected)
                        {
                            return statusItem;
                        }
                    }

                    // V2.0以降で保存されていたがステータスが未設定の場合、nullを返す
                    return null;
                }

                // V2.0以降のステータスが存在しない場合、
                // V2.0より前のバージョンのステータスから、IStatusItemを作成して返す
                foreach (var statusItem in ReviewStatus.ReviewStatusItems.ListItems)
                {
                    if (statusItem.Default == "True")
                    {
                        return new ReviewStatusItem()
                        {
                            Name = statusItem.Name,
                            IsSelectedString = statusItem.Default,
                        };
                    }
                }

                // V2.0より前のバージョンのステータスが未設定の場合、nullを返す
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
                // V2.0以降で1度でも保存されていた場合、
                // V2.0以降の選択されたステータスを返す
                if (ReviewStatusItems != null)
                {
                    return ReviewStatusItems.ReviewStatusItemList;
                }

                // V2.0以降のステータスが存在しない場合、
                // V2.0より前のバージョンのステータスから、IStatusItemを作成して返す
                var allowedValues = new List<IStatusItem>();
                foreach (var statusItem in ReviewStatus.ReviewStatusItems.ListItems)
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
        /// レビューのカスタムフィールドの定義一覧
        /// </summary>
        [XmlElement("CustomFields")]
        public ReviewCustomFields CustomFields { get; set; }

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

                foreach (var reviewStyleItem in ReviewStyles.ReviewStyleItems.ListItems)
                {
                    allowedValues.Add(reviewStyleItem.Name);
                }

                return allowedValues;
            }
        }
    }
}
