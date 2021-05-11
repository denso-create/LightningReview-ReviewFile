using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// 各エンティティに共通する基底クラス
    /// </summary>
    public abstract class EntityBase
    {
        #region 構築

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EntityBase()
        {
            GID = Guid.NewGuid().ToString();
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// グローバルID
        /// </summary>
        [XmlElement]
        public string GID { get; set; } 

        /// <summary>
        /// 作成者
        /// </summary>
        [XmlElement]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 最終更新者
        /// </summary>
        [XmlElement]
        public string LastUpdatedBy { get; set; }

        /// <summary>
        /// 作成日時の文字列
        /// </summary>
        [XmlElement("CreatedDateTime")]
        public string CreatedDateTimeString { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime? CreatedDateTime => string.IsNullOrEmpty(CreatedDateTimeString) ? (DateTime?) null : DateTime.Parse(CreatedDateTimeString);

        /// <summary>
        /// 最終更新日時の文字列
        /// </summary>
        [XmlElement("LastUpdatedDateTime")]
        public string LastUpdatedDateTimeString { get; set; }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        public DateTime? LastUpdatedDateTime => string.IsNullOrEmpty(LastUpdatedDateTimeString) ? (DateTime?) null : DateTime.Parse(LastUpdatedDateTimeString);

        #endregion
    }
}
