using LightningReview.ReviewFile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LightningReview.ReviewFile
{
    /// <summary>
    /// レビューファイルのリーダーのインタフェース
    /// </summary>
    public interface IReviewFileReader
    {
        /// <summary>
        /// 指定ファイルのレビューファイルを読み込みます。
        /// </summary>
        /// <param name="filepath">レビューファイルのパス</param>
        /// <returns>ロードしたレビューモデル</returns>
        IReview Read(string filepath);

        Task<IReview> ReadAsync(string filepath);

        /// <summary>
        /// 指定フォルダのレビューファイルを読み込みます。
        /// </summary>
        /// <param name="folderPath">フォルダのパス</param>
        /// <param name="readSubFodler">サブフォルダも対象にするか</param>
        /// <returns>ロードしたレビューモデル</returns>
        IEnumerable<IReview> ReadFolder(string folderPath, bool readSubFodler = false);
        
        Task<IEnumerable<IReview>> ReadFolderAsync(string folderPath, bool readSubFodler = false);

        /// <summary>
        /// レビューファイルのストリームを読み込みます。
        /// </summary>
        /// <param name="reviewFileStream">レビューファイルのストリーム</param>
        /// <returns>ロードしたレビューモデル</returns>
        IReview Read(Stream reviewFileStream);

        Task<IReview> ReadAsync(Stream reviewFileStream);
    }
}
