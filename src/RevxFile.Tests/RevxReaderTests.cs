using LightningReview.RevxFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LightningReview.RevxFile.Tests
{
    [TestClass]
    public class RevxReaderTests : TestBase
    {
        private string RevFileName = "RevFile1.revx";

        [TestMethod]
        public void LoadTest()
        {
            var review = LoadRevx(RevFileName);

            Assert.IsNotNull(review);
            Assert.AreEqual(GetTestDataPath(RevFileName), review.FilePath);
        }

        [TestMethod]
        public void EntityBaseTests()
        {
            var review = LoadRevx(RevFileName);

            Assert.IsNotNull(review.CreatedBy);
            Assert.IsTrue(review.CreatedDateTime < DateTime.Now);
        }

        [TestMethod]
        public void ReviewTest()
        {
            var review = LoadRevx(RevFileName);

            Assert.AreEqual("RevTitle", review.Name);
            Assert.AreEqual("RevPurpose", review.Goal);
        }

        [TestMethod]
        public void DocumentTest()
        {
            var review = LoadRevx(RevFileName);
            Assert.IsNotNull(review.Documents.List);

            // ドキュメントは2つ
            Assert.AreEqual(2, review.Documents.List.Count);

            // 1つめのドキュメント
            var doc1 = review.Documents.List[0];
            Assert.AreEqual("Doc1X", doc1.Name);

            #region アウトラインツリー
            // アウトラインツリー
            Assert.IsNotNull(doc1.OutlineTree);
            Assert.AreEqual(2, doc1.OutlineTree.VirtualRoot.Children.Count);

            // こちらのアクセスも可能
            Assert.AreEqual(2, doc1.OutlineNodes.Count());
            var node1 = doc1.OutlineNodes[0];
            Assert.AreEqual("outline1", node1.Name);
            Assert.AreEqual("outline1-1", node1.Children[0].Name);
            Assert.AreEqual("outline1-2", node1.Children[1].Name);

            var node2 = doc1.OutlineNodes[1];
            Assert.AreEqual("outline2", node2.Name);
            Assert.AreEqual("outline2-1", node2.Children[0].Name);
            #endregion

            #region 指摘件数
            Assert.AreEqual(3, review.AllIssues.Count());
            Assert.AreEqual(2, doc1.AllIssues.Count());
            Assert.AreEqual(1, node1.AllIssues.Count());
            Assert.AreEqual(1, node2.AllIssues.Count());
            #endregion
        }

        [TestMethod]
        public void IssueTest()
        {
            var review = LoadRevx(RevFileName);
            var allIssues = review.AllIssues;

            // 指摘のフィールド
            var issue1 = allIssues.First(i => i.LID == "1");
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
