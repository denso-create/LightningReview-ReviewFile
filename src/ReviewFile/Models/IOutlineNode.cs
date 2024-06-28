using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// アウトラインノードのインタフェースです。
    /// </summary>
    public interface IOutlineNode
    {
        #region 公開プロパティ
        
        /// <summary>
        /// グローバルIDを取得します。
        /// </summary>
        /// <value>グローバルID。</value>
        string GID { get; }

        /// <summary>
        /// ノード名を取得します。
        /// </summary>
        /// <value>ノード名。</value>
        string Name { get; }

        /// <summary>
        /// 子ノードの一覧を取得します。
        /// </summary>
        /// <value>子ノードの一覧。子ノードがない時は、要素数0のコレクションです。</value>
        IEnumerable<IOutlineNode> Children { get; }

        /// <summary>
        /// メタデータの一覧を取得します。
        /// </summary>
        /// <value>メタデータの一覧。メタデータがない時は、要素数0のコレクションです。</value>
        IEnumerable<IMetaData> MetaDatas { get; }

        #endregion

        #region 公開サービス

        /// <summary>
        /// 指定したキーのメタデータを取得します。
        /// </summary>
        /// <param name="key">キー。</param>
        /// <param name="defaultValue">値が取得できなかった場合の値。</param>
        /// <returns>取得する値。</returns>
        T GetMetaData<T>(string key, T defaultValue = default);

        #endregion
    }
}
