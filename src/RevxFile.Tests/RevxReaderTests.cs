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

            // �h�L�������g��2��
            Assert.AreEqual(2, review.Documents.List.Count);

            // 1�߂̃h�L�������g
            var doc1 = review.Documents.List[0];
            Assert.AreEqual("Doc1X", doc1.Name);

            #region �A�E�g���C���c���[
            // �A�E�g���C���c���[
            Assert.IsNotNull(doc1.OutlineTree);
            Assert.AreEqual(2, doc1.OutlineTree.VirtualRoot.Children.Count);

            // ������̃A�N�Z�X���\
            Assert.AreEqual(2, doc1.OutlineNodes.Count());
            var node1 = doc1.OutlineNodes[0];
            Assert.AreEqual("outline1", node1.Name);
            Assert.AreEqual("outline1-1", node1.Children[0].Name);
            Assert.AreEqual("outline1-2", node1.Children[1].Name);

            var node2 = doc1.OutlineNodes[1];
            Assert.AreEqual("outline2", node2.Name);
            Assert.AreEqual("outline2-1", node2.Children[0].Name);
            #endregion

            #region �w�E����
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

            // �w�E�̃t�B�[���h
            var issue1 = allIssues.First(i => i.LID == "1");
            Assert.AreEqual("Issue1 Description", issue1.Description);
            Assert.AreEqual("�s�", issue1.Type);
            Assert.AreEqual("���C��", issue1.Status);
            Assert.AreEqual("��", issue1.Priority);
            Assert.AreEqual("��", issue1.Importance);
            Assert.AreEqual("Member1", issue1.ReportedBy);
            Assert.AreEqual("Member2", issue1.AssignedTo);
            Assert.AreEqual("Member3", issue1.ConfirmedBy);
        }
    }
}
