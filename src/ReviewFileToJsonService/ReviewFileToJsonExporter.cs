using LightningReview.ReviewFile;
using ReviewFileToJsonService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace LightningReview.ReviewFileToJsonService
{
    /// <summary>
    /// RevxのJsonエクスポート
    /// </summary>
    public class ReviewFileToJsonExporter
    {
        /// <summary>
        /// ログ出力
        /// </summary>
        public Action<string> Logger { get; set; }

        /// <summary>
        /// 指定フォルダのレビューファイルを集計してJSONファイルに出力する
        /// </summary>
        /// <param name="revxFolder">レビューファイルが格納されたフォルダ</param>
        /// <param name="outputFilePath">出力ファイルのパス</param>
        /// <param name="includeSubFolders">サブフォルダも含めるか</param>
        /// <param name="unescapedUnicode">Unicodeエスケープを防ぐか</param>
        public void Export(string revxFolder, string outputFilePath, bool includeSubFolders = false, bool unescapedUnicode = false)
        {
            var reader = new ReviewFileReader();
            var readReviews = reader.ReadFolder(revxFolder, includeSubFolders);
            // Jsonモデル
            var jsonModel = new JsonModel(readReviews);

            // シリアライズ時のオプション設定
            var options = new JsonSerializerOptions()
            {
                // 読みやすいようにインデントを付与する
                WriteIndented = true
            };

            if (unescapedUnicode)
            {
                // JSONファイル内の日本語をUnicodeエスケープされないようにすることで
                // UTF-8でエンコードされたJSONファイルとして出力される
                // 出力されたJSONファイルを別ツールを用いて読み込む場合にUTF-8以外で
                // 読み込もうとすると日本語が文字化けしてしまうため、UTF-8で読み込むこと
                options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            }

            // ログ出力
            Logger?.Invoke($"{readReviews.Count()}件のレビューファイルが見つかりました。");

            // JSONとして書き出しする
            var jsonString = JsonSerializer.Serialize(jsonModel, options);
            File.WriteAllText(outputFilePath, jsonString);
        }
    }
}
