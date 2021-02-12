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
        [TestMethod]
        public void Load1000_PeformanceTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for ( var i=0;i<1000;i++)
            {
                var review = LoadRevx("RevFilePeformance30.revx");
                var issues = review.AllIssues;

                Assert.AreEqual(30, issues.Count());
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 5000);
        }
    }
}
