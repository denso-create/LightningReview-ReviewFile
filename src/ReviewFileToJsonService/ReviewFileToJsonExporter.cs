using LightningReview.ReviewFile;
using ReviewFileToJsonService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LightningReview.ReviewFileToJsonService
{
    /// <summary>
    /// RevxのJsonエクスポート
    /// </summary>
    public class ReviewFileToJsonExporter
    {
        public Action<string> Logger { get; set; }

        /// <summary>
        /// 指定フォルダのレビューファイルを集計してJSONファイルに出力する
        /// </summary>
        /// <param name="revxFolder"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="includeSubFolders"></param>
        public void Export(string revxFolder,string outputFilePath,bool includeSubFolders=false)
        {
            var reader = new ReviewFileReader();
            var readReviews = reader.ReadFolder(revxFolder, includeSubFolders);
            // Jsonモデル
            var jsonModel = new JsonModel(readReviews);

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            // ログ出力
            Logger?.Invoke($"{readReviews.Count()}件のレビューファイルが見つかりました。");

            // JSONとして書き出しする
            var jsonString = JsonSerializer.Serialize(jsonModel, options);
            File.WriteAllText(outputFilePath, jsonString);
        }

    }
}
