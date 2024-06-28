using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// メタデータのインタフェースです。
    /// </summary>
    public interface IMetaData
    {
        #region 公開プロパティ

        /// <summary>
        /// メタデータのキーを取得します。
        /// </summary>
        /// <value>メタデータのキー。</value>
        string Key {get;}

        /// <summary>
        /// メタデータが暗号化されているかを取得します。
        /// </summary>
        /// <value>メタデータが暗号化されているか。</value>
        bool Encrypted {get;}

        #endregion

        #region 公開サービス

        /// <summary>
        /// 型を指定して値を取得します。
        /// </summary>
        /// <typeparam name="T">取得する型。</typeparam>
        /// <param name="defaultValue">値が取得できなかった場合の値。</param>
        /// <returns>取得する値。</returns>
        T GetValue<T>(T defaultValue = default);

        #endregion
    }
}
