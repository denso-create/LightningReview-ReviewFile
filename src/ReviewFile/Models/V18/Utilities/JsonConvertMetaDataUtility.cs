using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18.Utilities
{
    /// <summary>
    /// Jsonをメタデータに変換するユーティリティクラス
    /// </summary>
    internal static class JsonConvertMetaDataUtility
    {
        #region 公開サービス

        /// <summary>
        /// Jsonをメタデータの一覧にデシリアライズする
        /// </summary>
        /// <param name="metaDataString">メタデータの値の文字列</param>
        /// <returns>メタデータの一覧</returns>
        internal static IDictionary<string, MetaData> Deserialize(string metaDataString)
        {
            return JsonSerializer.Deserialize<Dictionary<string, MetaData>>(metaDataString) ??
                   new Dictionary<string, MetaData>();
        }

        #endregion
    }
}
