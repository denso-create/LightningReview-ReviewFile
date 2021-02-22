using LightningReview.ReviewFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LightningReview.ReviewFile.Tests
{
    [TestClass]
    public class ReviewFileReaderTests : TestBase
    {
        private string RevFileName = "RevFile1.revx";

        [DataRow("V10")]
        [DataRow("V18")]
        [DataTestMethod]
        public void ReadFileTest(string version)
        {
            var review = ReadReviewFile(version,RevFileName);

            Assert.IsNotNull(review);
            Assert.AreEqual(GetTestDataPath(version,RevFileName), review.FilePath);
        }

        [DataRow("V10")]
        [DataRow("V18")]
        [DataTestMethod]
        public void ReadFolderTest(string version)
        {
            var folder = GetTestDataPath(version);

            var reader = new ReviewFileReader();
            var reviews = reader.ReadFolder(folder);

            // 直下のフォルダ
            Assert.IsNotNull(reviews);
            Assert.AreEqual(2, reviews.Count());

            // サブフォルダも対象
            reviews = reader.ReadFolder(folder, true);
            Assert.AreEqual(4, reviews.Count());
        }

        [DataRow("V10")]
        [DataRow("V18")]
        [DataTestMethod]
        public void ReviewTest(string version)
        {
            var review = ReadReviewFile(version,RevFileName);

            // ドキュメントの絶対パス
            var currentPath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var testDataPath = Path.Combine(currentPath, "TestData", version, RevFileName);
            Assert.AreEqual(testDataPath, review.FilePath);

            Assert.AreEqual("b90a3142-2c05-4550-9ac5-008ea6461bc0", review.GID);
            Assert.AreEqual("作成者", review.CreatedBy);
            Assert.AreEqual(DateTime.Parse("2021/02/12 6:16:01"), review.CreatedDateTime);
            Assert.AreEqual("最終更新者", review.LastUpdatedBy);
            Assert.AreEqual(DateTime.Parse("2021/02/22 18:42:46"), review.LastUpdatedDateTime);
            Assert.AreEqual("RevTitle", review.Name);
            Assert.AreEqual("RevPurpose", review.Goal);
            Assert.AreEqual("RevEndCondition", review.EndCondition);
            Assert.AreEqual("RevPlace", review.Place);
            Assert.AreEqual("RevProjectCode", review.ProjectCode);
            Assert.AreEqual("RevProjectName", review.ProjectName);
            Assert.AreEqual(DateTime.Parse("2021/2/18 0:00:00"), review.PlannedDate);
            Assert.AreEqual(DateTime.Parse("2021/2/19 0:00:00"), review.ActualDate);
            Assert.AreEqual("1", review.PlannedTime);
            Assert.AreEqual("2", review.ActualTime);
            Assert.AreEqual("ページ", review.Unit);
            Assert.AreEqual("3", review.PlannedScale);
            Assert.AreEqual("4", review.ActualScale);
            Assert.AreEqual("5", review.IssueCountOfGoal);
            Assert.AreEqual("3", review.IssueCountOfActual);
        }

        [DataRow("V10")]
        [DataRow("V18")]
        [DataTestMethod]
        public void DocumentTest(string version)
        {
            var review = ReadReviewFile(version,RevFileName);
            Assert.IsNotNull(review.Documents);

            // ドキュメントは2つ
            Assert.AreEqual(2, review.Documents.Count());

            // 1つめのドキュメント
            var doc1 = review.Documents.ToList()[0];
            Assert.AreEqual("Doc1", doc1.Name);

            // TODO V1の場合はOutlineNodeのXML構造が独特なのでXMLの属性マッピングで永続化できない
            /*
            #region アウトラインツリー
            // アウトラインツリー
            Assert.AreEqual(2, doc1.OutlineNodes.Count());
            var node1 = doc1.OutlineNodes.ElementAt(0);
            Assert.AreEqual("outline1", node1.Name);
            Assert.AreEqual("outline1-1", node1.Children.ElementAt(0).Name);
            Assert.AreEqual("outline1-2", node1.Children.ElementAt(1).Name);

            var node2 = doc1.OutlineNodes.ToList()[1];
            Assert.AreEqual("outline2", node2.Name);
            Assert.AreEqual("outline2-1", node2.Children.ElementAt(0).Name);
            #endregion
            */

            #region 指摘件数
            Assert.AreEqual(3, review.Issues.Count());
            //Assert.AreEqual(2, doc1.AllIssues.Count());
            #endregion
        }

        [DataRow("V10")]
        [DataRow("V18")]
        [DataTestMethod]
        public void IssueTest(string version)
        {
            var review = ReadReviewFile(version,RevFileName);
            var issues = review.Issues;
            Assert.IsNotNull(issues,"Review.Issuesがnullです");

            // 指摘のフィールド
            var issue1 = issues.FirstOrDefault(i => i.LID == "1");
            Assert.IsNotNull(issue1,$"LID=1の指摘がありません 。指摘数={issues.Count()}");
            Assert.AreEqual("Issue1 Description", issue1.Description);
            Assert.AreEqual("不具合", issue1.Type);
            Assert.AreEqual("未修正", issue1.Status);
            Assert.AreEqual("高", issue1.Priority);
            Assert.AreEqual("中", issue1.Importance);
            Assert.AreEqual("Member1", issue1.ReportedBy);
            Assert.AreEqual("Member2", issue1.AssignedTo);
            Assert.AreEqual("Member3", issue1.ConfirmedBy);
        }
    }
}
