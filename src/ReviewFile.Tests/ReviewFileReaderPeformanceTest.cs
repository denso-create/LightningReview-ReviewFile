using LightningReview.ReviewFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LightningReview.ReviewFile.Tests
{
    /// <summary>
    /// ReviewFileReaderクラスのパフォーマンステスト
    /// </summary>
    [TestClass]
    public class ReviewFileReaderPeformanceTest : TestBase
    {
        [TestMethod]
        public void Load100Times_PeformanceTest_V10()
        {
            LoadXTimes_PeformanceTest("V10", 100);
        }

        [TestMethod]
        public void Load100Times_PeformanceTest_V18()
        {
            LoadXTimes_PeformanceTest("V18", 100);
        }

        [TestMethod]
        [TestCategory("SkipWhenLiveUnitTesting")]
        public void Load1000Times_PeformanceTest_V10()
        {
            LoadXTimes_PeformanceTest("V10", 1000);
        }

        [TestMethod]
        [TestCategory("SkipWhenLiveUnitTesting")]
        public void Load1000Times_PeformanceTest_V18()
        {
            LoadXTimes_PeformanceTest("V18", 1000);
        }

        //[DataRow("V10", 500)]
        //[DataRow("V18", 500)]
        //[DataTestMethod]
        public void LoadXTimes_PeformanceTest(string version,int dataCount)
        {
            var revxFolder = GetTestDataPath(version);

            // テスト用のフォルダを作成する
            var peformanceTestFolder = Path.Combine(GetTestDataPath(), "PeformanceTestData");
            RecreateDirectory(peformanceTestFolder);

            #region テストデータの作成

            // 指定されたフォルダ以下のレビューファイルに対して、レビューのデータを取得する
            var ReviewFile = Path.Combine(revxFolder, "RevFilePerformance30.revx");
            Assert.IsTrue(File.Exists(ReviewFile),"テストデータがありません");

            // テストファイルの作成
            for (var i = 0; i < dataCount; i++)
            {
                var destFilePath = Path.Combine(peformanceTestFolder, $"PerformanceReviewFile{i}.revx");
                File.Copy(ReviewFile, destFilePath);
            }

            #endregion

            var ReviewFiles = Directory.EnumerateFiles(peformanceTestFolder, "*.revx");

            // 指定数作成できているか
            Assert.AreEqual(dataCount, ReviewFiles.Count());

            // 実際にファイルを読み込む
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach ( var revFilePath in ReviewFiles)
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

            //RemoveDirectory(peformanceTestFolder);
        }
    }
}
