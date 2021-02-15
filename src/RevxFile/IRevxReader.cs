using LightningReview.RevxFile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightningReview.RevxFile
{
    interface IRevxReader
    {
        /// <summary>
        /// 指定ファイルのレビューファイルを読み込みます。
        /// </summary>
        /// <param name="filepath">対象のrevxファイル</param>
        /// <returns></returns>
        IReview Read(string filepath);

        Task<IReview> ReadAsync(string filepath);

        /// <summary>
        /// 指定フォルダのレビューファイルを読み込みます。
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="readSubFodler"></param>
        /// <returns></returns>
        IEnumerable<IReview> ReadFolder(string folderPath,bool readSubFodler=false);
        
        Task<IEnumerable<IReview>> ReadFolderAsync(string folderPath, bool readSubFodler = false);
    }
}
