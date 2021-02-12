using LightningReview.RevxFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace LightningReview.RevxFile.Tests
{
    [TestClass]
    public class RevxReaderPeformanceTest : TestBase
    {
        [TestCategory("SkipWhenLiveUnitTesting")]
        [TestMethod]
        public void Load1000Times_PeformanceTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // 1000回ファイルを読みこむ
            for ( var i=0;i<1000;i++)
            {
                var review = ReadRevx("RevFilePeformance30.revx");

                // 指摘を取得してみる
                var issues = review.AllIssues;
                Assert.AreEqual(30, issues.Count());
            }

            // 実行時間は5000ms以内であること
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 5000);
        }
    }
}
