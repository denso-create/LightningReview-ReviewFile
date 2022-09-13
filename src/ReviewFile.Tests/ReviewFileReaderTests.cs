using DensoCreate.LightningReview.ReviewFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DensoCreate.LightningReview.ReviewFile.Exceptions;
using DensoCreate.LightningReview.ReviewFile.Tests.Base;
using System.Collections.Generic;

namespace DensoCreate.LightningReview.ReviewFile.Tests
{
    /// <summary>
    /// ReviewFileReaderクラスのテスト
    /// </summary>
    [TestClass]
    public class ReviewFileReaderTests : TestBase
    {
        /// <summary>
        /// テストデータ
        /// </summary>
        private readonly string RevFileName = "RevFile1.revx";

        /// <summary>
        /// Reviewの未設定を確認するテストデータ
        /// </summary>
        private readonly string NotSetValueReviewName = "NotSetValueReview.revx";

        /// <summary>
        /// Issueの未設定を確認するテストデータ
        /// </summary>
        private readonly string NotSetValueIssueName = "NotSetValueIssue.revx";

        /// <summary>
        /// Stream内のReviewFile要素が存在しないテストデータ
        /// </summary>
        private readonly string NotReviewFileStreamName = "NotReviewFileStreamTestDate.revx";

        /// <summary>
        /// ファイルパス引数でのReadメソッドのテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void ReadFileTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);

            Assert.IsNotNull(review);
            Assert.AreEqual(GetTestDataPath(version, RevFileName), review.FilePath);
        }

        /// <summary>
        /// ReadFolderメソッドのテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void ReadFolderTest(string version)
        {
            var folder = GetTestDataPath(version);

            var reader = new ReviewFileReader();
            var reviews = reader.ReadFolder(folder);

            // 直下のフォルダ
            Assert.IsNotNull(reviews);
            Assert.AreEqual(4, reviews.Count());

            // サブフォルダも対象
            reviews = reader.ReadFolder(folder, true);
            Assert.AreEqual(6, reviews.Count());
        }

        /// <summary>
        /// レビューファイルが存在しない場合の異常値のテスト
        /// </summary>
        [TestMethod]
        public void ReadNotExistFolderTest()
        {
            const string folderPath = "NotExist";
            var reader = new ReviewFileReader();

            try
            {
                var reviews = reader.ReadFolder(folderPath);
            }
            catch (Exception exception)
            {
                Assert.AreEqual($"{folderPath} is not a valid directory.", exception.Message);
                return;
            }

            Assert.Fail();
        }

        /// <summary>
        /// Stream引数でのReadメソッドのテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void ReadStreamTest(string version)
        {
            var review = ReadReviewStream(version, RevFileName);
            Assert.IsNotNull(review);
            Assert.AreEqual(string.Empty, review.FilePath);
        }

        /// <summary>
        /// Stream内のReviewFile要素が存在しない場合のテスト
        /// </summary>
        [TestMethod]
        public void ReadReviewFileElementMissingTest()
        {
            try
            {
                var review = ReadReviewStream("", NotReviewFileStreamName);
            }
            catch (ReviewFileFormatException reviewFileFormatException)
            {
                Assert.AreEqual("ReviewFile Element Missing", reviewFileFormatException.Message);
                return;
            }

            Assert.Fail();
        }

        /// <summary>
        /// Null値を引数でのReadメソッドのテスト
        /// </summary>
        [TestMethod]
        public void ReadNullStreamTest()
        {
            var reader = new ReviewFileReader();

            try
            {
                reader.Read(Stream.Null);
            }
            catch (ReviewFileFormatException reviewFileFormatException)
            {
                Assert.AreEqual("Root element is missing.", reviewFileFormatException.Message);
                return;
            }

            Assert.Fail();
        }

        /// <summary>
        /// 非同期メソッドのテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        /// <returns></returns>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public async Task ReadAsyncTest(string version)
        {
            #region ReadAsync

            var filepath = GetTestDataPath(version, RevFileName);
            var reader = new ReviewFileReader();
            var review = await reader.ReadAsync(filepath);
            Assert.IsNotNull(review);
            Assert.AreEqual(GetTestDataPath(version, RevFileName), review.FilePath);

            #endregion

            #region ReadFolderAsync

            var folder = GetTestDataPath(version);

            //直下のフォルダ
            var reviews = await reader.ReadFolderAsync(folder);
            Assert.IsNotNull(reviews);
            Assert.AreEqual(4, reviews.Count());

            // サブフォルダも対象
            reviews = await reader.ReadFolderAsync(folder, true);
            Assert.AreEqual(6, reviews.Count());

            #endregion

            #region ReadAsync(Stream)

            review = await ReadAsyncReviewStream(version, RevFileName);
            Assert.IsNotNull(review);
            Assert.AreEqual(string.Empty, review.FilePath);

            #endregion
        }

        /// <summary>
        /// Reviewモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void ReviewTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);

            // レビューの絶対パス
            var currentPath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var testDataPath = Path.Combine(currentPath, "TestData", version, RevFileName);
            Assert.AreEqual(testDataPath, review.FilePath);

            // レビューのフィールド
            Assert.AreEqual("b90a3142-2c05-4550-9ac5-008ea6461bc0", review.GID);
            Assert.AreEqual("作成者", review.CreatedBy);
            Assert.AreEqual(DateTime.Parse("2021/02/12 6:16:01"), review.CreatedDateTime);
            Assert.AreEqual("最終更新者", review.LastUpdatedBy);
            if (version == "V20")
            {
                // V20のテストデータ作成時に最終更新日時が更新されたため、
                // versionが"V20"の場合は期待値を変更する。
                // 新しいバージョンのテストをする際にテストデータを更新した場合は、同様に期待値を変更すること。
                Assert.AreEqual(DateTime.Parse("2022/07/29 11:43:30"), review.LastUpdatedDateTime);
            }
            else
            {
                Assert.AreEqual(DateTime.Parse("2021/02/22 18:42:46"), review.LastUpdatedDateTime);
            }
            Assert.AreEqual("RevTitle", review.Name);
            Assert.AreEqual("RevPurpose", review.Goal);
            Assert.AreEqual("RevEndCondition", review.EndCondition);
            Assert.AreEqual("RevPlace", review.Place);
            Assert.AreEqual("RevProjectCode", review.ProjectCode);
            Assert.AreEqual("RevProjectName", review.ProjectName);
            Assert.AreEqual("RevReviewType2", review.ReviewType);
            CollectionAssert.AreEqual(new List<string>() { "RevReviewType1", "RevReviewType2" }, review.ReviewTypeAllowedValues.ToArray());
            Assert.AreEqual("RevDomain2", review.Domain);
            CollectionAssert.AreEqual(new List<string>() { "RevDomain1", "RevDomain2" }, review.DomainAllowedValues.ToArray());
            Assert.AreEqual("RevStatus2", review.ReviewStatus);
            CollectionAssert.AreEqual(new List<string>() { "RevStatus1", "RevStatus2" }, review.ReviewStatusAllowedValues.ToArray());
            Assert.AreEqual("RevReviewStyle2", review.ReviewStyle);
            CollectionAssert.AreEqual(new List<string>() { "RevReviewStyle1", "RevReviewStyle2" }, review.ReviewStyleAllowedValues.ToArray());
            Assert.AreEqual(DateTime.Parse("2021/2/18 0:00:00"), review.PlannedDate);
            Assert.AreEqual(DateTime.Parse("2021/2/19 0:00:00"), review.ActualDate);
            Assert.AreEqual("1", review.PlannedTime);
            Assert.AreEqual("2", review.ActualTime);
            Assert.AreEqual("ページ", review.Unit);
            Assert.AreEqual("3", review.PlannedScale);
            Assert.AreEqual("4", review.ActualScale);
            Assert.AreEqual("5", review.IssueCountOfGoal);
            Assert.AreEqual("3", review.IssueCountOfActual);
            Assert.AreEqual("True", review.UseCorrectionPolicyStatus);
            Assert.AreEqual("True", review.UseReason);
            Assert.AreEqual("RevCategory2", review.CategoryDefaultValue);
            CollectionAssert.AreEqual(new List<string>() { "RevCategory1", "RevCategory2" }, review.CategoryAllowedValues.ToArray());
            Assert.AreEqual("RevDetectionActivity2", review.DetectionActivityDefaultValue);
            CollectionAssert.AreEqual(new List<string>() { "RevDetectionActivity1", "RevDetectionActivity2" }, review.DetectionActivityAllowedValues.ToArray());
            Assert.AreEqual("RevInjectionActivity2", review.InjectionActivityDefaultValue);
            CollectionAssert.AreEqual(new List<string>() { "RevInjectionActivity1", "RevInjectionActivity2" }, review.InjectionActivityAllowedValues.ToArray());

            // 指摘、ドキュメント、メンバ、ステータスの定義の個数
            Assert.AreEqual(4, review.Issues.Count());
            Assert.AreEqual(2, review.Documents.Count());
            Assert.AreEqual(3, review.Members.Count());
            Assert.AreEqual(1, review.StatusItems.Count());

            if (version == "V10" || version == "V18")
            {
	            // カスタムフィールドの定義の個数
	            Assert.AreEqual(0, review.ReviewCustomFieldDefinitions.Count());
	            Assert.AreEqual(0, review.MemberCustomRoleDefinitions.Count());
	            Assert.AreEqual(0, review.MemberCustomFieldDefinitions.Count());
	            Assert.AreEqual(10, review.IssueCustomFieldDefinitions.Count());

                // 現在のステータスの設定値
                // Name, IsSelected以外は初期値となる
                Assert.AreEqual("RevStatus2", review.ReviewStatusItem.Name);
                Assert.IsNull(review.ReviewStatusItem.SelectedOn);
                Assert.AreEqual("", review.ReviewStatusItem.SelectedBy);
                Assert.AreEqual("False", review.ReviewStatusItem.IsClosed);
                Assert.AreEqual("True", review.ReviewStatusItem.IsSelected);
                Assert.AreEqual("None", review.ReviewStatusItem.Color);
            }

            if (version == "V20")
            {
	            // カスタムフィールドの定義の個数
	            Assert.AreEqual(20, review.ReviewCustomFieldDefinitions.Count());
	            Assert.AreEqual(5, review.MemberCustomRoleDefinitions.Count());
	            Assert.AreEqual(5, review.MemberCustomFieldDefinitions.Count());
	            Assert.AreEqual(20, review.IssueCustomFieldDefinitions.Count());

                // 現在のステータスの設定値
                Assert.AreEqual("RevStatus2", review.ReviewStatusItem.Name);
                Assert.AreEqual(DateTime.Parse("2021/2/18 0:00:00"), review.ReviewStatusItem.SelectedOn);
                Assert.AreEqual("設定者", review.ReviewStatusItem.SelectedBy);
                Assert.AreEqual("True", review.ReviewStatusItem.IsClosed);
                Assert.AreEqual("True", review.ReviewStatusItem.IsSelected);
                Assert.AreEqual("Red", review.ReviewStatusItem.Color);

                // V20のテストデータのみで以下のカスタムフィールドが設定されている。
                Assert.AreEqual("TextA2", review.CustomText1);
                Assert.AreEqual("TextB2", review.CustomText2);
                Assert.AreEqual("TextC2", review.CustomText3);
                Assert.AreEqual("TextD2", review.CustomText4);
                Assert.AreEqual("TextE2", review.CustomText5);
                Assert.AreEqual("TextF2", review.CustomText6);
                Assert.AreEqual("TextG2", review.CustomText7);
                Assert.AreEqual("TextH2", review.CustomText8);
                Assert.AreEqual("TextI2", review.CustomText9);
                Assert.AreEqual("TextJ2", review.CustomText10);
                Assert.AreEqual("TextK2", review.CustomText11);
                Assert.AreEqual("TextL2", review.CustomText12);
                Assert.AreEqual("TextM2", review.CustomText13);
                Assert.AreEqual("TextN2", review.CustomText14);
                Assert.AreEqual("TextO2", review.CustomText15);
                Assert.AreEqual("TextP2", review.CustomText16);
                Assert.AreEqual("TextQ2", review.CustomText17);
                Assert.AreEqual("TextR2", review.CustomText18);
                Assert.AreEqual("TextS2", review.CustomText19);
                Assert.AreEqual("TextT2", review.CustomText20);
            }
        }

        /// <summary>
        /// Reviewモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <remarks>
        /// カスタムテキスト1～20に対応するXML属性はV20のテストデータにのみ存在するため、各バージョンで以下のように検証する。
        ///     ・versionがV10とV18の場合は、初期値の空文字が返ることを検証する。
        ///     ・versionがV20の場合は、取得した未設定の値として空文字が返ることを検証する。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueReviewTest(string version)
        {
            var review = ReadReviewFile(version, NotSetValueReviewName);

            // レビューの未設定のフィールド
            Assert.AreEqual("", review.Goal);
            Assert.AreEqual("", review.EndCondition);
            Assert.AreEqual("", review.Place);
            Assert.AreEqual("", review.ProjectCode);
            Assert.AreEqual("", review.ProjectName);
            Assert.AreEqual("", review.ReviewType);
            CollectionAssert.AreEqual(new List<string>(), review.ReviewTypeAllowedValues.ToArray());
            Assert.AreEqual("", review.Domain);
            CollectionAssert.AreEqual(new List<string>(), review.DomainAllowedValues.ToArray());
            Assert.AreEqual("", review.ReviewStatus);
            CollectionAssert.AreEqual(new List<string>(), review.ReviewStatusAllowedValues.ToArray());
            Assert.AreEqual("", review.ReviewStyle);
            CollectionAssert.AreEqual(new List<string>(), review.ReviewStyleAllowedValues.ToArray());
            Assert.IsNull(review.PlannedDate);
            Assert.IsNull(review.ActualDate);
            Assert.AreEqual("", review.PlannedTime);
            Assert.AreEqual("", review.ActualTime);
            Assert.AreEqual("", review.Unit);
            Assert.AreEqual("", review.PlannedScale);
            Assert.AreEqual("", review.ActualScale);
            Assert.AreEqual("", review.IssueCountOfGoal);
            Assert.AreEqual("0", review.IssueCountOfActual);

            // UseCorrectionPolicyStatus, UseReasonは初期値が空となっている。
            // 明示的にFalseに変えるロジックを挟む必要があるため、本テストメソッドでチェックする。
            Assert.AreEqual("False", review.UseCorrectionPolicyStatus);
            Assert.AreEqual("False", review.UseReason);

            Assert.AreEqual("", review.CategoryDefaultValue);
            CollectionAssert.AreEqual(new List<string>(), review.CategoryAllowedValues.ToArray());
            Assert.AreEqual("", review.DetectionActivityDefaultValue);
            CollectionAssert.AreEqual(new List<string>(), review.DetectionActivityAllowedValues.ToArray());
            Assert.AreEqual("", review.InjectionActivityDefaultValue);
            CollectionAssert.AreEqual(new List<string>(), review.InjectionActivityAllowedValues.ToArray());

            // 指摘、ドキュメント、メンバ、ステータスの定義の個数
            Assert.AreEqual(0, review.Issues.Count());
            Assert.AreEqual(0, review.Documents.Count());
            Assert.AreEqual(0, review.Members.Count());
            Assert.AreEqual(0, review.StatusItems.Count());

            // 現在のステータスの設定値
            Assert.IsNull(review.ReviewStatusItem);

            // ・versionがV10とV18の場合
            //      ・カスタムテキスト1～20に対応するXML属性が存在しない場合は、初期値の空文字が返ることを検証する。
            // ・versionがV20の場合
            //      ・カスタムテキスト1～20に対応するXML属性が存在する場合は、取得した未設定の値として空文字が返ることを検証する。
            Assert.AreEqual("", review.CustomText1);
            Assert.AreEqual("", review.CustomText2);
            Assert.AreEqual("", review.CustomText3);
            Assert.AreEqual("", review.CustomText4);
            Assert.AreEqual("", review.CustomText5);
            Assert.AreEqual("", review.CustomText6);
            Assert.AreEqual("", review.CustomText7);
            Assert.AreEqual("", review.CustomText8);
            Assert.AreEqual("", review.CustomText9);
            Assert.AreEqual("", review.CustomText10);
            Assert.AreEqual("", review.CustomText11);
            Assert.AreEqual("", review.CustomText12);
            Assert.AreEqual("", review.CustomText13);
            Assert.AreEqual("", review.CustomText14);
            Assert.AreEqual("", review.CustomText15);
            Assert.AreEqual("", review.CustomText16);
            Assert.AreEqual("", review.CustomText17);
            Assert.AreEqual("", review.CustomText18);
            Assert.AreEqual("", review.CustomText19);
            Assert.AreEqual("", review.CustomText20);
        }

        /// <summary>
        /// Documentモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void DocumentTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
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

        /// <summary>
        /// Documentモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueDocumentTest(string version)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Issueモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void IssueTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var issues = review.Issues;
            Assert.IsNotNull(issues, "Review.Issuesがnullです");

            // 1つ目の指摘のフィールド
            var issue1 = issues.FirstOrDefault(i => i.LID == "1");
            Assert.IsNotNull(issue1, $"LID=1の指摘がありません 。指摘数={issues.Count()}");
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
            if (version == "V20")
            {
                // V20のテストデータのみで以下のフィールドが設定されている。
                // そのため、versionが"V20"のときのみ値チェックを行う。
                Assert.AreEqual("TextK2", issue1.CustomText11);
                Assert.AreEqual("TextL2", issue1.CustomText12);
                Assert.AreEqual("TextM2", issue1.CustomText13);
                Assert.AreEqual("TextN2", issue1.CustomText14);
                Assert.AreEqual("TextO2", issue1.CustomText15);
                Assert.AreEqual("TextP2", issue1.CustomText16);
                Assert.AreEqual("TextQ2", issue1.CustomText17);
                Assert.AreEqual("TextR2", issue1.CustomText18);
                Assert.AreEqual("TextS2", issue1.CustomText19);
                Assert.AreEqual("TextT2", issue1.CustomText20);
            }
        }

        /// <summary>
        /// Issueモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        /// <remarks>
        /// カスタムテキスト11～20に対応するXML属性はV20のテストデータにのみ存在するため、各バージョンで以下のように検証する。
        ///     ・versionがV10とV18の場合は、初期値の空文字が返ることを検証する。
        ///     ・versionがV20の場合は、取得した未設定の値として空文字が返ることを検証する。
        /// </remarks>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueIssueTest(string version)
        {
            var review = ReadReviewFile(version, NotSetValueIssueName);
            var issues = review.Issues;
            Assert.IsNotNull(issues, "Review.Issuesがnullです");

            // 指摘の未設定のフィールド
            var issue1 = issues.FirstOrDefault(i => i.LID == "1");
            Assert.AreEqual("", issue1.CorrectionPolicy);
            Assert.AreEqual("", issue1.Category);
            Assert.AreEqual("", issue1.Description);
            Assert.AreEqual("", issue1.Reason);
            Assert.AreEqual("", issue1.SendingBackReason);
            Assert.AreEqual("", issue1.DetectionActivity);
            Assert.AreEqual("", issue1.InjectionActivity);
            Assert.AreEqual("", issue1.Importance);
            Assert.IsNull(issue1.DateReported);
            Assert.IsNull(issue1.DueDate);
            Assert.IsNull(issue1.DateFixed);
            Assert.AreEqual("", issue1.Resolution);
            Assert.IsNull(issue1.DateConfirmed);
            Assert.AreEqual("", issue1.Comment);
            Assert.AreEqual("", issue1.CustomText1);
            Assert.AreEqual("", issue1.CustomText2);
            Assert.AreEqual("", issue1.CustomText3);
            Assert.AreEqual("", issue1.CustomText4);
            Assert.AreEqual("", issue1.CustomText5);
            Assert.AreEqual("", issue1.CustomText6);
            Assert.AreEqual("", issue1.CustomText7);
            Assert.AreEqual("", issue1.CustomText8);
            Assert.AreEqual("", issue1.CustomText9);
            Assert.AreEqual("", issue1.CustomText10);

            // ・versionがV10とV18の場合
            //      ・カスタムテキスト11～20に対応するXML属性が存在しない場合は、初期値の空文字が返ることを検証する。
            // versionがV20の場合
            //      ・カスタムテキスト11～20に対応するXML属性が存在する場合は、取得した未設定の値として空文字が返ることを検証する。
            Assert.AreEqual("", issue1.CustomText11);
            Assert.AreEqual("", issue1.CustomText12);
            Assert.AreEqual("", issue1.CustomText13);
            Assert.AreEqual("", issue1.CustomText14);
            Assert.AreEqual("", issue1.CustomText15);
            Assert.AreEqual("", issue1.CustomText16);
            Assert.AreEqual("", issue1.CustomText17);
            Assert.AreEqual("", issue1.CustomText18);
            Assert.AreEqual("", issue1.CustomText19);
            Assert.AreEqual("", issue1.CustomText20);
        }

        /// <summary>
        /// IssueCustomFieldDefinitionモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void IssueCustomFieldDefinitionTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// IssueCustomFieldDefinitionモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueIssueCustomFieldDefinitionTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// MemberCustomFieldDefinitionモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void MemberCustomFieldDefinitionTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// MemberCustomFieldDefinitionモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueMemberCustomFieldDefinitionTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// MemberCustomRoleDefinitionモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void MemberCustomRoleDefinitionTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// MemberCustomRoleDefinitionモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueMemberCustomRoleDefinitionTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// ReviewCustomFieldDefinitionモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void ReviewCustomFieldDefinitionTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// ReviewCustomFieldDefinitionモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueReviewCustomFieldDefinitionTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// ReviewMemberモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void ReviewMemberTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// ReviewMemberモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueReviewMemberTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// OutlineNodeモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void OutlineNodeTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// OutlineNodeモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueOutlineNodeTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// StatusItemモデルのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void StatusItemTest(string version)
        {
	        throw new NotImplementedException();
        }

        /// <summary>
        /// StatusItemモデルのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueStatusItemTest(string version)
        {
	        throw new NotImplementedException();
        }
    }
}
