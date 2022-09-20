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
        string GID { get; }

        /// <summary>
        /// ローカルIDを取得します。
        /// </summary>
        string LID { get; }

        /// <summary>
        /// ドキュメント名を取得します。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ドキュメントの絶対パスを取得します。
        /// </summary>
        string AbsolutePath { get; }

        /// <summary>
        /// 関連づいているアプリケーションを取得します。
        /// </summary>
        string ApplicationType { get; }

        /// <summary>
        /// このドキュメントに関連づくアウトラインの一覧を取得します。
        /// </summary>
        IEnumerable<IOutlineNode> OutlineNodes { get; }

        #endregion
    }
}
