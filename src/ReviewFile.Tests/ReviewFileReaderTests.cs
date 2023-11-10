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
        #region 定数定義

        /// <summary>
        /// テストデータ
        /// </summary>
        private readonly string RevFileName = "RevFile1.revx";

        /// <summary>
        /// Reviewの未設定を確認するテストデータ
        /// </summary>
        private readonly string NotSetValueReviewName = "NotSetValueReview.revx";

        /// <summary>
        /// Documentの未設定を確認するテストデータ
        /// </summary>
        private readonly string NotSetValueDocumentName = "NotSetValueDocument.revx";

        /// <summary>
        /// OutlineNodeの未設定を確認するテストデータ
        /// </summary>
        private readonly string NotSetValueOutlineNodeName = "NotSetValueOutlineNode.revx";

        /// <summary>
        /// Issueの未設定を確認するテストデータ
        /// </summary>
        private readonly string NotSetValueIssueName = "NotSetValueIssue.revx";

        /// <summary>
        /// StatusItemの未設定を確認するテストデータ
        /// </summary>
        private readonly string NotSetValueStatusItemName = "NotSetValueStatusItem.revx";

        /// <summary>
        /// カスタムフィールド全般の未設定を確認するテストデータ
        /// </summary>
        private readonly string NotSetValueCustomFieldName = "NotSetValueCustomField.revx";

        /// <summary>
        /// bool値に対応するXML属性が"False"文字列の場合を確認するテストデータ
        /// </summary>
        private readonly string BoolTypePropertyShouldBeFalseName = "BoolTypePropertyShouldBeFalse.revx";

        /// <summary>
        /// Stream内のReviewFile要素が存在しないテストデータ
        /// </summary>
        private readonly string NotReviewFileStreamName = "NotReviewFileStreamTestDate.revx";

        #endregion

        #region レビューファイルの読み込み

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
            Assert.AreEqual(9, reviews.Count());

            // サブフォルダも対象
            reviews = reader.ReadFolder(folder, true);
            Assert.AreEqual(11, reviews.Count());
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
            Assert.AreEqual(9, reviews.Count());

            // サブフォルダも対象
            reviews = await reader.ReadFolderAsync(folder, true);
            Assert.AreEqual(11, reviews.Count());

            #endregion

            #region ReadAsync(Stream)

            review = await ReadAsyncReviewStream(version, RevFileName);
            Assert.IsNotNull(review);
            Assert.AreEqual(string.Empty, review.FilePath);

            #endregion
        }

        #endregion

        #region IReview

        /// <summary>
        /// IReviewのフィールドが設定された場合のテスト
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

            // インターフェースの拡充に伴うテスト項目追加により、テストデータを更新した結果、最終更新日時も更新される。
            // そのため、バージョンごとに期待値の日付情報を変えている。
            // テストデータを更新した場合は、同様に期待値を変更すること。
            switch (version)
            {
                case "V10":
                    Assert.AreEqual(DateTime.Parse("2021/02/22 18:42:46"), review.LastUpdatedDateTime);
                    break;
                case "V18":
                    Assert.AreEqual(DateTime.Parse("2022/09/19 13:55:29"), review.LastUpdatedDateTime);
                    break;
                case "V20":
                    Assert.AreEqual(DateTime.Parse("2022/09/15 18:34:12"), review.LastUpdatedDateTime);
                    break;
                default:
                    Assert.Fail("想定していないテストパスです。");
                    break;
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

            Assert.AreEqual(true, review.UseCorrectionPolicyStatus);
            Assert.AreEqual(true, review.UseReason);

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
            Assert.AreEqual(2, review.ReviewStatusItems.Count());

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
                Assert.AreEqual(false, review.ReviewStatusItem.IsClosed);
                Assert.AreEqual(true, review.ReviewStatusItem.IsSelected);
                Assert.AreEqual("なし", review.ReviewStatusItem.Color);
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
                Assert.AreEqual(DateTime.Parse("2022/9/15 0:00:00"), review.ReviewStatusItem.SelectedOn);
                Assert.AreEqual("設定者2", review.ReviewStatusItem.SelectedBy);
                Assert.AreEqual(true, review.ReviewStatusItem.IsClosed);
                Assert.AreEqual(true, review.ReviewStatusItem.IsSelected);
                Assert.AreEqual("赤", review.ReviewStatusItem.Color);

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
        /// IReviewのフィールドが未設定の場合のテスト
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

            // (V18以降では)UseCorrectionPolicyStatus, UseReasonはXML上で初期値が空となっているため、明示的にfalseに変えるロジックが必要である。
            // よって、本テストメソッドでfalseになることをチェックする。
            Assert.AreEqual(false, review.UseCorrectionPolicyStatus);
            Assert.AreEqual(false, review.UseReason);

            Assert.AreEqual("", review.CategoryDefaultValue);
            CollectionAssert.AreEqual(new List<string>(), review.CategoryAllowedValues.ToArray());
            Assert.AreEqual("", review.DetectionActivityDefaultValue);
            CollectionAssert.AreEqual(new List<string>(), review.DetectionActivityAllowedValues.ToArray());
            Assert.AreEqual("", review.InjectionActivityDefaultValue);
            CollectionAssert.AreEqual(new List<string>(), review.InjectionActivityAllowedValues.ToArray());

            // 指摘、ドキュメント、ステータスの定義の個数
            // なお、メンバの定義は0になることがないため、本テストメソッドでは検証しない。
            Assert.AreEqual(0, review.Issues.Count());
            Assert.AreEqual(0, review.Documents.Count());
            Assert.AreEqual(0, review.ReviewStatusItems.Count());

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
        /// IReviewのbool型プロパティに対するテスト
        /// </summary>
        /// <remarks>
        /// IReviewのUseCorrectionPolicyStatus, UseReasonは、XML上で"(空文字)", "True", "False"の3値をとる。
        /// "(空文字)", "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void ReviewTest_BoolTypePropertyShouldBeFalse(string version)
        {
            var review = ReadReviewFile(version, BoolTypePropertyShouldBeFalseName);

            // XMLの文字列が"False"のときに正しくパースされるか検証する。
            Assert.AreEqual(false, review.UseCorrectionPolicyStatus);
            Assert.AreEqual(false, review.UseReason);
        }

        #endregion

        #region IDocument

        /// <summary>
        /// IDocumentのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void DocumentTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var documents = review.Documents;
            Assert.IsNotNull(review.Documents, "Review.Documentsがnullです");

            // ドキュメントは2つあるか
            Assert.AreEqual(2, documents.Count());

            // 1つ目のドキュメントのフィールド
            var doc1 = documents.ToList()[0];
            Assert.AreEqual("Doc1", doc1.Name);
            Assert.AreEqual("EXCEL", doc1.ApplicationType);
            Assert.AreEqual("4d7c6fbc-3eb5-4166-a2c3-257b5d0646ef", doc1.GID);
            Assert.AreEqual("1", doc1.LID);

            // ドキュメントの絶対パス（テストデータにはsrc\ReviewFile.Tests\TestData以下のテスト用Excelファイルを関連づけている）
            Assert.AreEqual(@"C:\Git\LightningReview-RevxFile\src\ReviewFile.Tests\TestData\ドキュメントモデル確認用テストデータ.xlsx", doc1.AbsolutePath);

            Assert.AreEqual(2, doc1.OutlineNodes.Count());

            // 
            if (version != "V10")
            {
                // 1つめのドキュメントのメタデータ
                // メタデータは2つあるか
                Assert.AreEqual(2,doc1.MetaDatas.Count());

                // 1つめのメタデータのフィールド
                Assert.AreEqual("TestKey1",doc1.MetaDatas.First().Key);
                Assert.AreEqual("TestValue1",doc1.MetaDatas.First().GetValue<string>());
                Assert.AreEqual(false,doc1.MetaDatas.First().Encrypted);
            }
            
        }

        /// <summary>
        /// IDocumentのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueDocumentTest(string version)
        {
            var review = ReadReviewFile(version, NotSetValueDocumentName);
            var documents = review.Documents;
            Assert.IsNotNull(review.Documents, "Review.Documentsがnullです");

            // ドキュメントは2つあるか
            Assert.AreEqual(2, documents.Count());

            // 1つ目のドキュメントのフィールド
            // なお、Name、GID、LIDはXML上で値が空になることがないため、本テストではチェックの対象外としている。
            var doc1 = documents.ToList()[0];
            Assert.AreEqual("", doc1.ApplicationType);
            Assert.AreEqual("", doc1.AbsolutePath);
            Assert.AreEqual(0, doc1.OutlineNodes.Count());
        }

        #endregion

        #region IIssue

        /// <summary>
        /// IIssueのフィールドが設定された場合のテスト
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
            Assert.AreEqual(true, issue1.IsSendingBack);
            Assert.AreEqual(true, issue1.HasBeenSentBack);
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

            // 指摘が関連づいているドキュメントの検証
            var document = issue1.Document;
            Assert.IsNotNull(document, "Issue.Documentがnullです");
            Assert.AreEqual(issue1.RootOutlineName, document.Name);
            Assert.AreEqual("4d7c6fbc-3eb5-4166-a2c3-257b5d0646ef", document.GID);

            // ドキュメントのIDの検証
            Assert.AreEqual(document.GID, issue1.DocumentID);

            // 指摘が関連づいているアウトラインノードの検証
            var outlineNode = issue1.OutlineNode;
            Assert.IsNotNull(outlineNode, "Issue.OutlineNodeがnullです");
            Assert.AreEqual(issue1.OutlineName, outlineNode.Name);

            // アウトラインノードのGIDはテストデータによって異なるため、バージョンごとに期待値を定義する。
            switch (version)
            {
                case "V10":
                    Assert.AreEqual("887a78e9-4872-42e6-bd07-f340fff6c1e2", outlineNode.GID);
                    break;
                case "V18":
                case "V20":
                    Assert.AreEqual("795e2b7e-5323-4fa1-880f-a2b0e1152cbd", outlineNode.GID);
                    break;
                default:
                    Assert.Fail("想定していないテストパスです。");
                    break;
            }

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
        /// IIssueのフィールドが未設定の場合のテスト
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

            // (V18以降では)IsSendingBack, HasBeenSentBackが一度も変更されていない場合は、XML上で空となっているため、明示的にデフォルト値のfalseに変えるロジックが必要である。
            //   よって、本テストメソッドでチェックする。
            Assert.AreEqual(false, issue1.IsSendingBack);
            Assert.AreEqual(false, issue1.HasBeenSentBack);

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

            // Document, DocumentIDは値が未設定になることがないため、本テストメソッドでは検証しない。

            // 指摘がアウトラインノードに関連づいていない場合の検証
            var outlineNode = issue1.OutlineNode;
            Assert.IsNull(outlineNode);

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
        /// IIssueのbool型プロパティに対するテスト
        /// </summary>
        /// <remarks>
        /// ・IIssueのIsSendingBackは、XML上で"(空文字)", "True", "False"の3値をとる。
        /// 　"(空文字)", "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// ・なお、IIssueのHasBeenSentBackについては、一度差し戻しが発生したら"True"になり続けるため、"(空文字)", "True",の2値しかとらない。
        /// 　すべてのバリエーションが他のテストでカバーされているため、本テストメソッドでは検証しない。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void IssueTest_BoolTypePropertyShouldBeFalse(string version)
        {
            var review = ReadReviewFile(version, BoolTypePropertyShouldBeFalseName);
            var issues = review.Issues;
            Assert.IsNotNull(issues, "Review.Issuesがnullです");

            // XMLの文字列が"False"のときに正しくパースされるか検証する。
            var issue1 = issues.FirstOrDefault(i => i.LID == "1");
            Assert.AreEqual(false, issue1.IsSendingBack);
        }

        #endregion

        #region IIssueCustomFieldDefinition

        /// <summary>
        /// IIssueCustomFieldDefinitionのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void IssueCustomFieldDefinitionTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var customFieldDefinitions = review.IssueCustomFieldDefinitions;
            Assert.IsNotNull(customFieldDefinitions, "Review.IssueCustomFieldDefinitionsがnullです");

            // 設定された1つ目の指摘のカスタムフィールドの定義
            var customFieldDefinition = customFieldDefinitions.FirstOrDefault();
            Assert.AreEqual("カスタムテキスト1", customFieldDefinition.DisplayName);
            Assert.AreEqual("TextA2", customFieldDefinition.DefaultValue);
            Assert.AreEqual(true, customFieldDefinition.Enabled);
            CollectionAssert.AreEqual(new List<string>() { "TextA1", "TextA2" }, customFieldDefinition.AllowedValues.ToArray());
        }

        /// <summary>
        /// IIssueCustomFieldDefinitionのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueIssueCustomFieldDefinitionTest(string version)
        {
            var review = ReadReviewFile(version, NotSetValueCustomFieldName);
            var customFieldDefinitions = review.IssueCustomFieldDefinitions;
            Assert.IsNotNull(customFieldDefinitions, "Review.IssueCustomFieldDefinitionsがnullです");

            // 未設定の1つ目の指摘のカスタムフィールドの定義
            // なお、EnabledとDisplayNameはXML上で値が空になることがないため、本テストではチェックの対象外としている。
            var customFieldDefinition1 = customFieldDefinitions.FirstOrDefault();
            CollectionAssert.AreEqual(new List<string>(), customFieldDefinition1.AllowedValues.ToArray());
            Assert.AreEqual("", customFieldDefinition1.DefaultValue);

            // 選択肢は定義されているが、デフォルト値が設定されていない場合
            var customFieldDefinition2 = customFieldDefinitions.ElementAt(1);
            Assert.AreEqual(2, customFieldDefinition2.AllowedValues.Count());
            Assert.AreEqual("", customFieldDefinition2.DefaultValue);
        }

        /// <summary>
        /// IIssueCustomFieldDefinitionのbool型プロパティに対するテスト
        /// </summary>
        /// <remarks>
        /// IIssueCustomFieldDefinitionのEnabledは、XML上で "True", "False"の2値をとる。
        /// "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void IssueCustomFieldDefinitionTest_BoolTypePropertyShouldBeFalse(string version)
        {
            var review = ReadReviewFile(version, BoolTypePropertyShouldBeFalseName);
            var customFieldDefinitions = review.IssueCustomFieldDefinitions;
            Assert.IsNotNull(customFieldDefinitions, "Review.IssueCustomFieldDefinitionsがnullです");

            // EnabledのXMLの文字列が"False"のときに正しくパースされるか検証する。
            var customFieldDefinition1 = customFieldDefinitions.FirstOrDefault();
            Assert.AreEqual(false, customFieldDefinition1.Enabled);
        }

        #endregion

        #region IMemberCustomFieldDefinition

        /// <summary>
        /// IMemberCustomFieldDefinitionのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void MemberCustomFieldDefinitionTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var customFieldDefinitions = review.MemberCustomFieldDefinitions;
            Assert.IsNotNull(customFieldDefinitions, "Review.MemberCustomFieldDefinitionsがnullです");

            // 設定された1つ目のメンバーのカスタムフィールドの定義
            var customFieldDefinition = customFieldDefinitions.FirstOrDefault();
            Assert.AreEqual("カスタムテキスト1", customFieldDefinition.DisplayName);
            Assert.AreEqual(true, customFieldDefinition.Enabled);
        }

        // 以下の理由から、IMemberCustomFieldDefinitionのフィールドが未設定の場合のテストは作成しない。
        //      ・EnabledとDisplayNameはXML上で値が空になることがないため、未設定のチェックをする必要がない。

        /// <summary>
        /// IMemberCustomFieldDefinitionのbool型プロパティに対するテスト
        /// </summary>
        /// <remarks>
        /// IMemberCustomFieldDefinitionのEnabledは、XML上で "True", "False"の2値をとる。
        /// "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void MemberCustomFieldDefinitionTest_BoolTypePropertyShouldBeFalse(string version)
        {
            var review = ReadReviewFile(version, BoolTypePropertyShouldBeFalseName);
            var customFieldDefinitions = review.MemberCustomFieldDefinitions;
            Assert.IsNotNull(customFieldDefinitions, "Review.MemberCustomFieldDefinitionsがnullです");

            // XMLの文字列が"False"のときに正しくパースされるか検証する。
            var customFieldDefinition = customFieldDefinitions.FirstOrDefault();
            Assert.AreEqual(false, customFieldDefinition.Enabled);
        }

        #endregion

        #region IMemberCustomRoleDefinition

        /// <summary>
        /// IMemberCustomRoleDefinitionのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void MemberCustomRoleDefinitionTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var customRoleDefinitions = review.MemberCustomRoleDefinitions;
            Assert.IsNotNull(customRoleDefinitions, "Review.MemberCustomRoleDefinitionsがnullです");

            // 設定された1つ目のメンバーのカスタムロールの定義
            var customRoleDefinition = customRoleDefinitions.FirstOrDefault();
            Assert.AreEqual("カスタムロール1", customRoleDefinition.DisplayName);
            Assert.AreEqual(true, customRoleDefinition.Enabled);
        }

        // 以下の理由から、IMemberCustomRoleDefinitionのフィールドが未設定の場合のテストは作成しない。
        //      ・EnabledとDisplayNameはXML上で値が空になることがないため、未設定のチェックをする必要がない。

        /// <summary>
        /// IMemberCustomRoleDefinitionのbool型プロパティに対するテスト
        /// </summary>
        /// <remarks>
        /// IMemberCustomRoleDefinitionのEnabledは、XML上で "True", "False"の2値をとる。
        /// "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void MemberCustomRoleDefinitionTest_BoolTypePropertyShouldBeFalse(string version)
        {
            var review = ReadReviewFile(version, BoolTypePropertyShouldBeFalseName);
            var customRoleDefinitions = review.MemberCustomRoleDefinitions;
            Assert.IsNotNull(customRoleDefinitions, "Review.MemberCustomRoleDefinitionsがnullです");

            // XMLの文字列が"False"のときに正しくパースされるか検証する。
            var customRoleDefinition = customRoleDefinitions.FirstOrDefault();
            Assert.AreEqual(false, customRoleDefinition.Enabled);
        }

        #endregion

        #region IReviewCustomFieldDefinition

        /// <summary>
        /// IReviewCustomFieldDefinitionのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void ReviewCustomFieldDefinitionTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var customFieldDefinitions = review.ReviewCustomFieldDefinitions;
            Assert.IsNotNull(customFieldDefinitions, "Review.ReviewCustomFieldDefinitionsがnullです");

            // 設定された1つ目のレビューのカスタムフィールドの定義
            var customFieldDefinition = customFieldDefinitions.FirstOrDefault();
            Assert.AreEqual("カスタムテキスト1", customFieldDefinition.DisplayName);
            Assert.AreEqual(true, customFieldDefinition.Enabled);
            Assert.AreEqual("計画と実績", customFieldDefinition.Group);
            CollectionAssert.AreEqual(new List<string>() { "TextA1", "TextA2" }, customFieldDefinition.AllowedValues.ToArray());
        }

        /// <summary>
        /// IReviewCustomFieldDefinitionのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueReviewCustomFieldDefinitionTest(string version)
        {
            var review = ReadReviewFile(version, NotSetValueCustomFieldName);
            var customFieldDefinitions = review.ReviewCustomFieldDefinitions;
            Assert.IsNotNull(customFieldDefinitions, "Review.ReviewCustomFieldDefinitionsがnullです");

            // 未設定の1つ目のレビューのカスタムフィールドの定義
            // ・EnabledとDisplayNameはXML上で値が空になることがないため、本テストではチェックの対象外としている。
            // ・Groupが初期値で一度も変更されていない場合は、XML上で空となっているため、明示的にデフォルト値の"基本設定"に変えるロジックが必要である。
            //   よって、本テストメソッドでチェックする。
            var customFieldDefinition = customFieldDefinitions.FirstOrDefault();
            Assert.AreEqual("基本設定", customFieldDefinition.Group);
            CollectionAssert.AreEqual(new List<string>(), customFieldDefinition.AllowedValues.ToArray());
        }

        /// <summary>
        /// IReviewCustomFieldDefinitionのbool型プロパティに対するテスト
        /// </summary>
        /// <remarks>
        /// IReviewCustomFieldDefinitionのEnabledは、XML上で "True", "False"の2値をとる。
        /// "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void ReviewCustomFieldDefinitionTest_BoolTypePropertyShouldBeFalse(string version)
        {
            var review = ReadReviewFile(version, BoolTypePropertyShouldBeFalseName);
            var customFieldDefinitions = review.ReviewCustomFieldDefinitions;
            Assert.IsNotNull(customFieldDefinitions, "Review.ReviewCustomFieldDefinitionsがnullです");

            // XMLの文字列が"False"のときに正しくパースされるか検証する。
            var customFieldDefinition = customFieldDefinitions.FirstOrDefault();
            Assert.AreEqual(false, customFieldDefinition.Enabled);
        }

        #endregion

        #region IReviewMember

        /// <summary>
        /// IReviewMemberのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void ReviewMemberTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var members = review.Members;
            Assert.IsNotNull(members, "Review.Membersがnullです");

            // 設定された1つ目のメンバ
            var reviewMember = members.FirstOrDefault();
            Assert.AreEqual("Member1", reviewMember.Name);
            Assert.AreEqual(true, reviewMember.Moderator);
            Assert.AreEqual(true, reviewMember.Reviewee);
            Assert.AreEqual(true, reviewMember.Reviewer);

            if (version == "V20")
            {
                // 以下のフィールドはV20のみで設定されている。
                Assert.AreEqual(true, reviewMember.CustomRole1);
                Assert.AreEqual(true, reviewMember.CustomRole2);
                Assert.AreEqual(true, reviewMember.CustomRole3);
                Assert.AreEqual(true, reviewMember.CustomRole4);
                Assert.AreEqual(true, reviewMember.CustomRole5);
                Assert.AreEqual("TextA", reviewMember.CustomText1);
                Assert.AreEqual("TextB", reviewMember.CustomText2);
                Assert.AreEqual("TextC", reviewMember.CustomText3);
                Assert.AreEqual("TextD", reviewMember.CustomText4);
                Assert.AreEqual("TextE", reviewMember.CustomText5);
                Assert.AreEqual("Tag", reviewMember.Tag);
            }
        }

        /// <summary>
        /// IReviewMemberのフィールドが未設定の場合のテスト
        /// </summary>
        /// <remarks>
        /// カスタムテキスト1～5, カスタムロール1～5, タグに対応するXML属性はV20のテストデータにのみ存在するため、各バージョンで以下のように検証する。
        /// ・カスタムロール1～5
        ///     ・versionがV10とV18の場合は、未定義でありnullになるため、初期値のFalseが返ることを検証する。
        ///     ・versionがV20の場合は、何も操作しないとXML上で初期値が空となっているため、明示的にFalseに変えるロジックが必要である。そのため、Falseの値が返ることを検証する。
        /// ・カスタムテキスト1～5, タグ
        ///     ・versionがV10とV18の場合は、未定義でありnullになるため、初期値の空文字が返ることを検証する。
        ///     ・versionがV20の場合は、取得した未設定の値として空文字が返ることを検証する。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueReviewMemberTest(string version)
        {
            var review = ReadReviewFile(version, NotSetValueReviewName);
            var members = review.Members;
            Assert.IsNotNull(members, "Review.Membersがnullです");

            // 未設定の1つ目のメンバ
            // なお、Name、Moderator、Reviewee、ReviewerはXML上で値が空になることがないため、本テストではチェックの対象外としている。
            var reviewMember = members.FirstOrDefault();
            Assert.AreEqual(false, reviewMember.CustomRole1);
            Assert.AreEqual(false, reviewMember.CustomRole2);
            Assert.AreEqual(false, reviewMember.CustomRole3);
            Assert.AreEqual(false, reviewMember.CustomRole4);
            Assert.AreEqual(false, reviewMember.CustomRole5);
            Assert.AreEqual("", reviewMember.CustomText1);
            Assert.AreEqual("", reviewMember.CustomText2);
            Assert.AreEqual("", reviewMember.CustomText3);
            Assert.AreEqual("", reviewMember.CustomText4);
            Assert.AreEqual("", reviewMember.CustomText5);
            Assert.AreEqual("", reviewMember.Tag);
        }

        /// <summary>
        /// IReviewMemberのbool型プロパティに対するテスト
        /// </summary>
        /// <remarks>
        /// ・IReviewMemberのModerator、Reviewee、Reviewerは、XML上で "True", "False"の2値をとる。
        /// "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// ・(V20のみ)CustomRole1～5は、XML上で"(空文字)", "True", "False"の3値をとる。
        /// "(空文字)", "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void ReviewMemberTest_BoolTypePropertyShouldBeFalse(string version)
        {
            var review = ReadReviewFile(version, BoolTypePropertyShouldBeFalseName);
            var members = review.Members;
            Assert.IsNotNull(members, "Review.Membersがnullです");

            // XMLの文字列が"False"のときに正しくパースされるか検証する。
            // なお、CustomRole1～5については、V20のみで設定されているが、
            // V10とV18でも期待値は変わらないため、同様にテストしている。
            var reviewMember = members.FirstOrDefault();
            Assert.AreEqual(false, reviewMember.Moderator);
            Assert.AreEqual(false, reviewMember.Reviewee);
            Assert.AreEqual(false, reviewMember.Reviewer);
            Assert.AreEqual(false, reviewMember.CustomRole1);
            Assert.AreEqual(false, reviewMember.CustomRole2);
            Assert.AreEqual(false, reviewMember.CustomRole3);
            Assert.AreEqual(false, reviewMember.CustomRole4);
            Assert.AreEqual(false, reviewMember.CustomRole5);
        }

        #endregion

        #region IOutlineNode

        /// <summary>
        /// IOutlineNodeのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void OutlineNodeTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var documents = review.Documents;
            Assert.IsNotNull(documents, "Review.Documentsがnullです");
            var outlineNodes = review.Documents.FirstOrDefault().OutlineNodes;
            Assert.IsNotNull(outlineNodes, "Document.Membersがnullです");

            // 設定された1つ目のドキュメントの1つ目のアウトラインノード
            var outlineNode = outlineNodes.FirstOrDefault();

            // GIDはテストデータによって異なるため、バージョンごとに期待値を定義する。
            switch (version)
            {
                case "V10":
                    Assert.AreEqual("17bbab7c-b03c-4caa-a52e-efb289e4a12f", outlineNode.GID);
                    break;
                case "V18":
                case "V20":
                    Assert.AreEqual("fecbbe13-ea16-4889-a0a6-4b1cd78819bd", outlineNode.GID);
                    break;
                default:
                    Assert.Fail("想定していないテストパスです。");
                    break;
            }
            Assert.AreEqual("outline1", outlineNode.Name);
            Assert.AreEqual(2, outlineNode.Children.Count());

            // さらに子のアウトラインノード
            var childNode = outlineNode.Children.FirstOrDefault();
            switch (version)
            {
                case "V10":
                    Assert.AreEqual("887a78e9-4872-42e6-bd07-f340fff6c1e2", childNode.GID);
                    break;
                case "V18":
                case "V20":
                    Assert.AreEqual("795e2b7e-5323-4fa1-880f-a2b0e1152cbd", childNode.GID);
                    break;
                default:
                    Assert.Fail("想定していないテストパスです。");
                    break;
            }
            Assert.AreEqual("outline1-1", childNode.Name);
            Assert.AreEqual(0, childNode.Children.Count());
        }

        /// <summary>
        /// IOutlineNodeのフィールドが未設定の場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueOutlineNodeTest(string version)
        {
            var review = ReadReviewFile(version, NotSetValueOutlineNodeName);
            var documents = review.Documents;
            Assert.IsNotNull(documents, "Review.Documentsがnullです");
            var outlineNodes = review.Documents.FirstOrDefault().OutlineNodes;
            Assert.IsNotNull(outlineNodes, "Document.OutlineNodesがnullです");

            // 1つ目のドキュメントの未設定の1つ目のアウトラインノード
            // なお、GIDとNameはXML上で値が空になることがないため、本テストではチェックの対象外としている。
            var outlineNode = outlineNodes.FirstOrDefault();
            Assert.AreEqual(0, outlineNode.Children.Count());
        }

        #endregion

        #region IStatusItem

        /// <summary>
        /// IStatusItemのフィールドが設定された場合のテスト
        /// </summary>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void StatusItemTest(string version)
        {
            var review = ReadReviewFile(version, RevFileName);
            var statusItems = review.ReviewStatusItems;
            Assert.IsNotNull(statusItems, "Review.StatusItemsがnullです");

            // 2つ目のステータスの定義
            Assert.AreEqual(2, statusItems.Count());
            var statusItem = statusItems.ElementAt(1);
            Assert.AreEqual("RevStatus2", statusItem.Name);
            Assert.AreEqual(true, statusItem.IsSelected);

            if (version == "V20")
            {
                // 以下のフィールドはV20のみで設定されている。
                Assert.AreEqual(DateTime.Parse("2022/09/15  0:00:00"), statusItem.SelectedOn);
                Assert.AreEqual("設定者2", statusItem.SelectedBy);
                Assert.AreEqual(true, statusItem.IsClosed);
                Assert.AreEqual("赤", statusItem.Color);
            }
        }

        /// <summary>
        /// IStatusItemのフィールドが未設定の場合のテスト
        /// </summary>
        /// <remarks>
        /// IsSelectedプロパティは、各バージョンで以下のように検証する。
        ///     ・versionがV10とV18の場合は、V20のテストケースに合わせて、Status属性のDefaultプロパティに設定したFalseの値が返ることを検証する。
        ///     ・versionがV20の場合は、何も操作しないとXML上で初期値が空となっているため、明示的にFalseに変えるロジックが必要である。そのため、Falseの値が返ることを検証する。
        /// 設定日, 設定者, IsClosed, Colorに対応するXML属性はV20のテストデータにのみ存在するため、各バージョンで以下のように検証する。
        /// ・設定日
        ///     ・versionがV10とV18の場合は、未定義であるため、初期値のnullが返ることを検証する。
        ///     ・versionがV20の場合は、取得した未設定の値としてnullが返ることを検証する。
        /// ・設定者
        ///     ・versionがV10とV18の場合は、未定義でnullとなるため、初期値の空文字が返ることを検証する。
        ///     ・versionがV20の場合は、取得した未設定の値として空文字が返ることを検証する。
        /// ・IsClosed
        ///     ・versionがV10とV18の場合は、未定義でnullとなるため、初期値のFalseが返ることを検証する。
        ///     ・versionがV20の場合は、何も操作しないとXML上で初期値が空となっているため、明示的にFalseに変えるロジックが必要である。そのため、Falseの値が返ることを検証する。
        /// ・Color
        ///     ・versionがV10とV18の場合は、未定義でnullとなるため、初期値の"なし"が返ることを検証する。
        ///     ・versionがV20の場合は、何も操作しないとXML上で初期値が空となっているため、明示的に"なし"に変えるロジックが必要である。そのため、"なし"の文字列が返ることを検証する。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V10")]
        [DataRow("V18")]
        [DataRow("V20")]
        [DataTestMethod]
        public void NotSetValueStatusItemTest(string version)
        {
            var review = ReadReviewFile(version, NotSetValueStatusItemName);
            var statusItems = review.ReviewStatusItems;
            Assert.IsNotNull(statusItems, "Review.StatusItemsがnullです");

            // 2つ目のステータスの定義
            // V20では必ず1番目のステータスが選択された状態となり、IsSelectedプロパティがTrueとなるため、ここではあえて2番目のステータスの定義をテスト対象としている。
            // なお、NameはXML上で値が空になることがないため、本テストではチェックの対象外としている。
            Assert.AreEqual(2, statusItems.Count());
            var statusItem = statusItems.ElementAt(1);
            Assert.AreEqual(false, statusItem.IsSelected);
            Assert.IsNull(statusItem.SelectedOn);
            Assert.AreEqual("", statusItem.SelectedBy);
            Assert.AreEqual(false, statusItem.IsClosed);
            Assert.AreEqual("なし", statusItem.Color);
        }

        /// <summary>
        /// IStatusItemのbool型プロパティに対するテスト
        /// </summary>
        /// <remarks>
        /// (V20のみ)IStatusItemのIsSelected, IsClosedは、XML上で"(空文字)", "True", "False"の3値をとる。
        /// "(空文字)", "True"の場合は他のテストでカバーされているため、"False"に対する検証を行う。
        /// なお、V10とV18のIsSelectedプロパティに対応するDefault属性は、"True", "False"の2値しかとらず、
        /// 両方とも他のテストでカバーされているため、本テストメソッドでは検証しない。
        /// </remarks>
        /// <param name="version">バージョン</param>
        [DataRow("V20")]
        [DataTestMethod]
        public void IStatusItemTest_BoolTypePropertyShouldBeFalse(string version)
        {
            var review = ReadReviewFile(version, BoolTypePropertyShouldBeFalseName);
            var statusItems = review.ReviewStatusItems;
            Assert.IsNotNull(statusItems, "Review.StatusItemsがnullです");

            // 2つ目のステータスの定義
            Assert.AreEqual(2, statusItems.Count());
            var statusItem = statusItems.ElementAt(1);

            // XMLの文字列が"False"のときに正しくパースされるか検証する。
            Assert.AreEqual(false, statusItem.IsClosed);
            Assert.AreEqual(false, statusItem.IsSelected);
        }

        #endregion
    }
}