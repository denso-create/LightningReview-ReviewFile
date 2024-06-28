using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DensoCreate.LightningReview.ReviewFile.Models.V18.Utilities;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// 各エンティティに共通する基底クラス
    /// </summary>
    public abstract class EntityBase
    {
        #region フィールド

        /// <summary>
        /// メタデータの値の文字列
        /// </summary>
        private string m_MetaDataString = string.Empty;

        /// <summary>
        /// メタデータのディクショナリ
        /// </summary>
        private IDictionary<string, MetaData> m_MetaDataDictionary = new Dictionary<string, MetaData>();

        #endregion

        #region 構築

        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected EntityBase()
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

        /// <summary>
        /// メタデータの一覧を取得します。
        /// </summary>
        /// <value>メタデータの一覧。メタデータがない時は、要素数0のコレクションです。</value>
        public IEnumerable<IMetaData> MetaDatas => m_MetaDataDictionary.Values;

        /// <summary>
        /// メタデータの値の文字列
        /// </summary>
        [XmlElement]
        public string MetaDataString
        {
            get => m_MetaDataString;
            set
            {
                m_MetaDataString = value;
                m_MetaDataDictionary = JsonConvertMetaDataUtility.Deserialize(m_MetaDataString);
            }
        }

        #endregion

        #region 公開サービス

        /// <summary>
        /// 指定したキーのメタデータを取得します。
        /// </summary>
        /// <param name="key">キー。</param>
        /// <param name="defaultValue">値が取得できなかった場合の値。</param>
        /// <returns>取得する値。</returns>
        public T GetMetaData<T>(string key, T defaultValue = default)
        {
            if (m_MetaDataDictionary.ContainsKey(key))
            {
                // キーが存在すれば、その値を返す
                var metaData = m_MetaDataDictionary[key];
                return metaData.GetValue(defaultValue);
            }

            // キーが存在しない場合は、デフォルト値を返す
            return defaultValue;
        }

        #endregion
    }
}
