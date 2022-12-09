using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// メタデータ
    /// </summary>
    public class MetaData : IMetaData
    {
        #region 公開プロパティ

        /// <inheritdoc />
        public string Key { get; set; }

        /// <inheritdoc />
        public bool Encrypted { get; set; }

        /// <summary>
        /// 値(任意の型でメモリ上に保持する)
        /// </summary>
        [JsonIgnore]
        private object Value { get; set; }

        /// <summary>
        /// 値をJsonに変換した文字列
        /// </summary>
        public string ValueString { get; set; }

        #endregion

        #region 公開サービス

        /// <inheritdoc />
        public T GetValue<T>(T defaultValue = default)
        {
            // 値の復元
            RestoreFromValueString<T>();

            if (Value is T value)
            {
                return value;
            }

            return defaultValue;
        }

        #endregion

        #region 内部処理

        /// <summary>
        /// 永続化用のValueStringから値を復元する
        /// </summary>
        /// <typeparam name="T">復元する型</typeparam>
        private void RestoreFromValueString<T>()
        {
            // 既に値が復元済みまたは、値をJsonに変換した文字列が空の場合は復元不要
            if (Value != null || string.IsNullOrEmpty(ValueString)) return;

            Value = JsonSerializer.Deserialize<T>(ValueString);
        }

        #endregion
    }
}
