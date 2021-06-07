using DensoCreate.LightningReview.ReviewFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DensoCreate.LightningReview.ReviewFile.Tests
{
    /// <summary>
    /// ReviewFileReaderクラスのパフォーマンステスト
    /// </summary>
    [TestClass]
    public class ReviewFileReaderPerformanceTest : TestBase
    {
        /// <summary>
        /// V10での100ファイル分のパフォーマンステスト
        /// </summary>
        [TestMethod]
        public void Load100Times_PerformanceTest_V10()
        {
            LoadXTimes_PerformanceTest("V10", 100);
        }

        /// <summary>
        /// V18での100ファイル分のパフォーマンステスト
        /// </summary>
        [TestMethod]
        public void Load100Times_PerformanceTest_V18()
        {
            LoadXTimes_PerformanceTest("V18", 100);
        }

        /// <summary>
        /// V10での1000ファイル分のパフォーマンステスト
        /// </summary>
        [TestMethod]
        [TestCategory("SkipWhenLiveUnitTesting")]
        public void Load1000Times_PerformanceTest_V10()
        {
            LoadXTimes_PerformanceTest("V10", 1000);
        }

        /// <summary>
        /// V18での1000ファイル分のパフォーマンステスト
        /// </summary>
        [TestMethod]
        [TestCategory("SkipWhenLiveUnitTesting")]
        public void Load1000Times_PerformanceTest_V18()
        {
            LoadXTimes_PerformanceTest("V18", 1000);
        }

        /// <summary>
        /// パフォーマンステスト実行処理
        /// </summary>
        /// <param name="version">バージョン</param>
        /// <param name="dataCount">データ数</param>
        public void LoadXTimes_PerformanceTest(string version,int dataCount)
        {
            var revxFolder = GetTestDataPath(version);

            // テスト用のフォルダを作成する
            var performanceTestFolder = Path.Combine(GetTestDataPath(), "PerformanceTestData");
            RecreateDirectory(performanceTestFolder);

            #region テストデータの作成

            // 指定されたフォルダ以下のレビューファイルに対して、レビューのデータを取得する
            var reviewFile = Path.Combine(revxFolder, "RevFilePerformance30.revx");
            Assert.IsTrue(File.Exists(reviewFile),"テストデータがありません");

            // テストファイルの作成
            for (var i = 0; i < dataCount; i++)
            {
                var destFilePath = Path.Combine(performanceTestFolder, $"PerformanceReviewFile{i}.revx");
                File.Copy(reviewFile, destFilePath);
            }

            #endregion

            var reviewFiles = Directory.EnumerateFiles(performanceTestFolder, "*.revx");

            // 指定数作成できているか
            Assert.AreEqual(dataCount, reviewFiles.Count());

            // 実際にファイルを読み込む
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach ( var revFilePath in reviewFiles)
            {
                var review = ReadReviewFile(version,revFilePath);

                // 指摘を取得してみる
                var issues = review.Issues;
                Assert.AreEqual(30,issues.Count());
            }

            stopwatch.Stop();
            // 実行時間は1ファイルあたり10ms以内であること
            // 例： 1000ファイル = 10秒
            var requiredTime = dataCount * 10;
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < requiredTime,$"{stopwatch.ElapsedMilliseconds}ms > {requiredTime}ms: {version}の{dataCount}レビューの読み込みが要求値の{requiredTime}msを超えて{stopwatch.ElapsedMilliseconds}msとなりました。");

            //RemoveDirectory(performanceTestFolder);
        }
    }
}
