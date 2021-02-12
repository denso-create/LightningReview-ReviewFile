using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RevxToJsonService.Tests
{
    [TestClass]
    public class RevxToJsonExporterTests
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


        [TestMethod]
        public void ExportTest()
        {
            var revxFolder = GetTestDataPath();
            var outputPath = GetTestDataPath("output.json");
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            // エクスポート
            var exporter = new RevxToJsonExporter();
            exporter.Export(revxFolder, outputPath);

            // ファイルの内容をテスト
            Assert.IsTrue(File.Exists(outputPath));

            var json = File.ReadAllText(outputPath);
            dynamic jsonModel = JsonConvert.DeserializeObject(json);

            // 中身を確認
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

        [TestCategory("SkipWhenLiveUnitTesting")]
        [TestMethod]
        public void PerfomanceTest()
        {
            var revxFolder = GetTestDataPath();

            // テスト用のフォルダを作成する
            var peformanceTestFolder = Path.Combine(revxFolder, "PeformanceTestData.");
            RecreateDirectory(peformanceTestFolder);

            #region テストデータの作成

            // 指定されたフォルダ以下のレビューファイルに対して、レビューのデータを取得する
            var revxFile = Directory.GetFiles(revxFolder, "*.revx", SearchOption.AllDirectories).FirstOrDefault();

            // テストファイルの作成
            for ( var i=0;i<1000;i++)
            {
                var destFilePath = Path.Combine(peformanceTestFolder, $"PerformanceRevxFile{i}.revx");
                File.Copy(revxFile, destFilePath);
            }

            #endregion

            #region 実行して時間を計測する

            var stopwatch = new Stopwatch();

            var outputPath = Path.Combine(peformanceTestFolder, "output.json");
            var exporter = new RevxToJsonExporter();
            exporter.Export(peformanceTestFolder, outputPath);
            stopwatch.Start();

            // 実行時間は5000ms以内であること
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 5000);
            #endregion
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
            } else 
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}
