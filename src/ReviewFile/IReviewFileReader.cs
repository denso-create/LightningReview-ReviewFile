using DensoCreate.LightningReview.ReviewFile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DensoCreate.LightningReview.ReviewFile
{
    /// <summary>
    /// レビューファイルのリーダーのインタフェース
    /// </summary>
    public interface IReviewFileReader
    {
        /// <summary>
        /// 指定ファイルのレビューファイルを読み込みます。
        /// </summary>
        /// <param name="filePath">レビューファイルのパス</param>
        /// <returns>ロードしたレビューモデル</returns>
        IReview Read(string filePath);

        /// <summary>
        /// 非同期で指定ファイルのレビューファイルを読み込みます。
        /// </summary>
        /// <param name="filePath">レビューファイルのパス</param>
        /// <returns>ロードしたレビューモデル</returns>
        Task<IReview> ReadAsync(string filePath);

        /// <summary>
        /// 指定フォルダのレビューファイルを読み込みます。
        /// </summary>
        /// <param name="folderPath">フォルダのパス</param>
        /// <param name="includeSubFodler">サブフォルダも対象にするか</param>
        /// <returns>ロードしたレビューモデル</returns>
        IEnumerable<IReview> ReadFolder(string folderPath, bool includeSubFodler = false);
        
        /// <summary>
        /// 非同期で指定フォルダのレビューファイルを読み込みます。
        /// </summary>
        /// <param name="folderPath">フォルダのパス</param>
        /// <param name="includeSubFodler">サブフォルダも対象にするか</param>
        /// <returns>ロードしたレビューモデル</returns>
        Task<IEnumerable<IReview>> ReadFolderAsync(string folderPath, bool includeSubFodler = false);

        /// <summary>
        /// レビューファイルのストリームを読み込みます。
        /// </summary>
        /// <param name="reviewFileStream">レビューファイルのストリーム</param>
        /// <returns>ロードしたレビューモデル</returns>
        IReview Read(Stream reviewFileStream);

        /// <summary>
        /// 非同期でレビューファイルのストリームを読み込みます。
        /// </summary>
        /// <param name="reviewFileStream">レビューファイルのストリーム</param>
        /// <returns>ロードしたレビューモデル</returns>
        Task<IReview> ReadAsync(Stream reviewFileStream);
    }
}
