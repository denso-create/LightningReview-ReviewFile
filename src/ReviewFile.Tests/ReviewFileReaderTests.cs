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

            // レビューの絶対パス
            var currentPath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var testDataPath = Path.Combine(currentPath, "TestData", version, RevFileName);
            Assert.AreEqual(testDataPath, review.FilePath);

            // レビューのフィールド
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

            // ドキュメントは2つあるか
            Assert.AreEqual(2, review.Documents.Count());

            // 1つ目のドキュメントのフィールド
            var doc1 = review.Documents.ToList()[0];
            Assert.AreEqual("Doc1", doc1.Name);
            Assert.AreEqual("EXCEL", doc1.ApplicationType);
            Assert.AreEqual("4d7c6fbc-3eb5-4166-a2c3-257b5d0646ef", doc1.GID);
            Assert.AreEqual("1", doc1.LID);

            // ドキュメントの絶対パス（テストデータにはsrc\ReviewFile.Tests\TestData以下のテスト用Excelファイルを関連づけている）
            Assert.AreEqual(@"C:\Git\LightningReview-RevxFile\src\ReviewFile.Tests\TestData\ドキュメントモデル確認用テストデータ.xlsx", doc1.AbsolutePath);

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

            // 1つ目の指摘のフィールド
            var issue1 = issues.FirstOrDefault(i => i.LID == "1");
            Assert.IsNotNull(issue1,$"LID=1の指摘がありません 。指摘数={issues.Count()}");
            Assert.AreEqual("a74cde8d-d7e7-4948-8a60-82f0fabea5f8", issue1.GID);
            Assert.AreEqual("不具合", issue1.Type);
            Assert.AreEqual("Issue1 CorrectionPolicy", issue1.CorrectionPolicy);
            Assert.AreEqual("RevCategory2", issue1.Category);
            Assert.AreEqual("Issue1 Description", issue1.Description);
            Assert.AreEqual("Issue1 Reason", issue1.Reason);
            Assert.AreEqual("RevSendingBackReason", issue1.SendingBackReason);
            Assert.AreEqual("未修正", issue1.Status);
            Assert.AreEqual("True", issue1.IsSendingBack);
            Assert.AreEqual("True", issue1.HasBeenSentBack);
            Assert.AreEqual("RevDetectionActivity2", issue1.DetectionActivity);
            Assert.AreEqual("RevInjectionActivity2", issue1.InjectionActivity);
            Assert.AreEqual("高", issue1.Priority);
            Assert.AreEqual("中", issue1.Importance);
            Assert.AreEqual("outline1-1", issue1.OutlineName);
            Assert.AreEqual("Doc1", issue1.RootOutlineName);
            Assert.AreEqual("/Doc1/outline1/outline1-1", issue1.OutlinePath);
            Assert.AreEqual("Member1", issue1.ReportedBy);
            Assert.AreEqual(DateTime.Parse("2021/2/12 0:00:00"), issue1.DateReported);
            Assert.AreEqual("はい", issue1.NeedToFix);
            Assert.AreEqual("Member2", issue1.AssignedTo);
            Assert.AreEqual(DateTime.Parse("2021/2/13 0:00:00"), issue1.DueDate);
            Assert.AreEqual(DateTime.Parse("2021/2/14 0:00:00"), issue1.DateFixed);
            Assert.AreEqual("Issue1 Resolution", issue1.Resolution);
            Assert.AreEqual("Member3", issue1.ConfirmedBy);
            Assert.AreEqual(DateTime.Parse("2021/2/15 0:00:00"), issue1.DateConfirmed);
            Assert.AreEqual("RevComment", issue1.Comment);
            Assert.AreEqual("TextA2", issue1.CustomText1);
            Assert.AreEqual("TextB2", issue1.CustomText2);
            Assert.AreEqual("TextC2", issue1.CustomText3);
            Assert.AreEqual("TextD2", issue1.CustomText4);
            Assert.AreEqual("TextE2", issue1.CustomText5);
            Assert.AreEqual("TextF2", issue1.CustomText6);
            Assert.AreEqual("TextG2", issue1.CustomText7);
            Assert.AreEqual("TextH2", issue1.CustomText8);
            Assert.AreEqual("TextI2", issue1.CustomText9);
            Assert.AreEqual("TextJ2", issue1.CustomText10);
        }
    }
}
