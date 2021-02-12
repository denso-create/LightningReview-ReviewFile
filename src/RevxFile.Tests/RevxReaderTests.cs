using LightningReview.RevxFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LightningReview.RevxFile.Tests
{
    [TestClass]
    public class RevxReaderTests : TestBase
    {
        protected Review LoadRevx(string filePath)
        {
            var filepath = GetTestDataPath(filePath);
            var reader = new RevxReader();
            var review = reader.Load(filepath);
            return review;
        }

        [TestMethod]
        public void LoadTest()
        {
            var review = LoadRevx("RevFile1.revx");
            Assert.AreEqual("RevTitle",review.Name);
        }

        [TestMethod]
        public void EntityBaseTests()
        {
            var review = LoadRevx("RevFile1.revx");

            Assert.IsNotNull(review.CreatedBy);
            Assert.IsTrue(review.CreatedDateTime < DateTime.Now);
        }

        [TestMethod]
        public void DocumentTest()
        {
            var review = LoadRevx("RevFile1.revx");
            Assert.IsNotNull(review.Documents.List);

            // ドキュメントは2つ
            Assert.AreEqual(2, review.Documents.List.Count);

            // 1つめのドキュメント
            var doc1 = review.Documents.List[0];
            Assert.AreEqual("Doc1X", doc1.Name);

            // アウトラインツリー
            Assert.IsNotNull(doc1.OutlineTree);
            Assert.IsNotNull(doc1.OutlineTree.VirtualRoot);

        }

    }
}
