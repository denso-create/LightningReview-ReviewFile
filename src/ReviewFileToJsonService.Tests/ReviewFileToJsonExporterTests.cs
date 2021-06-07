using DensoCreate.LightningReview.ReviewFileToJsonService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DensoCreate.LightningReview.ReviewFileToJsonService.Tests
{
    /// <summary>
    /// ReviewFileToJsonExporterクラスのテスト
    /// </summary>
    [TestClass]
    public class ReviewFileToJsonExporterTests
    {
        /// <summary>
        /// テストデータ格納フォルダ（ビルドしたDLLファイルからの相対パス）
        /// </summary>
        protected virtual string TestDataFolderName => @"TestData";

        /// <summary>
        /// テストデータのファイルパスを取得する
        /// </summary>
        /// <param name="fileName">テストデータのファイル名</param>
        /// <returns>テストデータのファイルパス</returns>
        protected string GetTestDataPath(string fileName = null)
        {
            var exePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var dir = Path.Combine(exePath, TestDataFolderName);

            if (string.IsNullOrEmpty(fileName))
            {
                return dir;
            }

            var path = Path.Combine(dir, fileName);
            return path;
        }

        /// <summary>
        /// Exportメソッドの引数のテスト
        /// </summary>
        [TestMethod]
        public void ExportParamTest()
        {
            var revxFolder = GetTestDataPath("ExportParamTest");
            var outputPath = GetTestDataPath("output.json");
            var exporter = new ReviewFileToJsonExporter();

            // フォルダ直下を指定
            exporter.Export(revxFolder, outputPath);
            var json = File.ReadAllText(outputPath);
            dynamic jsonModel = JsonConvert.DeserializeObject(json);
            Assert.AreEqual(3, (int)jsonModel.TotalReviewCount);

            // サブフォルダ以下も指定
            exporter.Export(revxFolder, outputPath,true);
            json = File.ReadAllText(outputPath);
            jsonModel = JsonConvert.DeserializeObject(json);
            Assert.AreEqual(6, (int)jsonModel.TotalReviewCount);

            // Unicodeエスケープしないように設定
            exporter.Export(revxFolder, outputPath, unescapedUnicode: true);
            json = File.ReadAllText(outputPath);
            //出力ファイルの文字列中にひらがな、漢字が含まれているか確認する
            Assert.IsTrue(Regex.IsMatch(json, @"[\p{IsHiragana}\p{IsCJKUnifiedIdeographs}]+"));
        }

        /// <summary>
        /// Exportメソッドのテスト
        /// </summary>
        [TestMethod]
        public void ExportTest()
        {
            var revxFolder = GetTestDataPath();
            var outputPath = GetTestDataPath("output.json");
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            var logMessage = string.Empty;
            // エクスポート処理
            var exporter = new ReviewFileToJsonExporter();
            exporter.Logger = (message) => logMessage = message;
            exporter.Export(revxFolder, outputPath);

            Assert.AreEqual($"3件のレビューファイルが見つかりました。", logMessage);

            // 出力先のファイルが生成されたか確認する
            Assert.IsTrue(File.Exists(outputPath));

            var json = File.ReadAllText(outputPath);
            dynamic jsonModel = JsonConvert.DeserializeObject(json);

            // 出力されたJsonの内容をテストする
            Assert.IsNotNull(jsonModel.Reviews);
            Assert.AreEqual(3,jsonModel.Reviews.Count);
            Assert.AreEqual(3, jsonModel.Reviews[0].Issues.Count);
            Assert.AreEqual(3, jsonModel.Reviews[1].Issues.Count);
            Assert.AreEqual(3, jsonModel.Reviews[2].Issues.Count);
            var issue1 = jsonModel.Reviews[0].Issues[0];
            Assert.AreEqual("1", (string)issue1.LID);
            Assert.AreEqual("Member2", (string)issue1.AssignedTo);
            Assert.AreEqual("Member3", (string)issue1.ConfirmedBy);
        }

        /// <summary>
        /// ReviewFileToJsonExporterクラスのパフォーマンステスト
        /// </summary>
        [TestCategory("SkipWhenLiveUnitTesting")]
        [TestMethod]
        public void PerformanceTest()
        {
            var revxFolder = GetTestDataPath();

            // テスト用のフォルダを作成する
            var performanceTestFolder = Path.Combine(revxFolder, "PerformanceTestData");
            RecreateDirectory(performanceTestFolder);

            #region テストデータの作成

            // 指定されたフォルダ以下のレビューファイルに対して、レビューのデータを取得する
            var ReviewFile = Directory.GetFiles(revxFolder, "*.revx", SearchOption.AllDirectories).FirstOrDefault();

            // テストファイルの作成
            for (var i = 0; i < 1000; i++)
            {
                var destFilePath = Path.Combine(performanceTestFolder, $"PerformanceReviewFile{i}.revx");
                File.Copy(ReviewFile, destFilePath);
            }

            #endregion

            #region パフォーマンステスト

            var stopwatch = new Stopwatch();

            var outputPath = Path.Combine(performanceTestFolder, "output.json");
            var exporter = new ReviewFileToJsonExporter();
            exporter.Export(performanceTestFolder, outputPath);
            stopwatch.Start();

            // 処理時間が5000ms以内であるか
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 5000);

            #endregion
        }

        /// <summary>
        /// Loggerのテスト
        /// </summary>
        [TestMethod]
        public void LoggerTest()
        {
            var exporter = new ReviewFileToJsonExporter();
            exporter.Logger = (message) => Console.WriteLine(message);
            Assert.IsNotNull(exporter.Logger);
        }

        /// <summary>
        /// フォルダを作成する。すでにあればファイルを削除して再作成する
        /// </summary>
        /// <param name="folder"></param>
        private void RecreateDirectory(string folder)
        {
            if (Directory.Exists(folder))
            {
                var files = Directory.GetFiles(folder);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            else
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}
