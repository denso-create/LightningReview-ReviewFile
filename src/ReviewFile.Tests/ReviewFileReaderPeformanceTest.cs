﻿using LightningReview.ReviewFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LightningReview.ReviewFile.Tests
{
    [TestClass]
    public class ReviewFileReaderPeformanceTest : TestBase
    {
        //[TestCategory("SkipWhenLiveUnitTesting")]
        [DataRow("V10",500)]
        [DataRow("V18",500)]
        [DataTestMethod]
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
            // 実行時間は1ファイルあたり5ms以内であること
            // 例： 1000ファイル = 5秒
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < dataCount * 10);

            //RemoveDirectory(peformanceTestFolder);
        }
    }
}