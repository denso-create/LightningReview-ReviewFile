using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// ドキュメントのインタフェース
    /// </summary>
    public interface IDocument
    {
        #region 公開プロパティ

        /// <summary>
        /// グローバルID
        /// </summary>
        string GID { get; }

        /// <summary>
        /// ローカルID
        /// </summary>
        string LID { get; }

        /// <summary>
        /// ドキュメント名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ドキュメントの絶対パス
        /// </summary>
        string AbsolutePath { get; }

        /// <summary>
        /// 関連づいているアプリケーション
        /// </summary>
        string ApplicationType { get; }

        /// <summary>
        /// このドキュメントに関連づくアウトラインの一覧
        /// </summary>
        IEnumerable<IOutlineNode> OutlineNodes { get; }

        #endregion
    }
}
