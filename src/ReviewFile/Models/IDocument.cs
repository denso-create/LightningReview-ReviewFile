using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// ドキュメントのインタフェースです。
    /// </summary>
    public interface IDocument
    {
        #region 公開プロパティ

        /// <summary>
        /// グローバルIDを取得します。
        /// </summary>
        /// <value>グローバルID。</value>
        string GID { get; }

        /// <summary>
        /// ローカルIDを取得します。
        /// </summary>
        /// <value>ローカルID。</value>
        string LID { get; }

        /// <summary>
        /// ドキュメント名を取得します。
        /// </summary>
        /// <value>ドキュメント名。</value>
        string Name { get; }

        /// <summary>
        /// ドキュメントの絶対パスを取得します。
        /// </summary>
        /// <value>ドキュメントの絶対パス。</value>
        string AbsolutePath { get; }

        /// <summary>
        /// 関連づいているアプリケーションを取得します。
        /// </summary>
        /// <value>関連づいているアプリケーション。</value>
        string ApplicationType { get; }

        /// <summary>
        /// このドキュメントに関連づくアウトラインの一覧を取得します。
        /// </summary>
        /// <value>アウトラインの一覧。関連づくアウトラインがない時は、要素数0のコレクションです。</value>
        IEnumerable<IOutlineNode> OutlineNodes { get; }

        #endregion
    }
}
