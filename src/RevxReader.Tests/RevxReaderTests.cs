using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightningReview.RevxReader.Tests
{
    [TestClass]
    public class RevxReaderTests : TestBase
    {
        [TestMethod]
        public void LoadTest()
        {
            // ファイルをロード
            var filepath = GetTestDataPath("RevFile1.revx");
            var reader = new RevxReader();
            var review = reader.Load(filepath);

            // フィールド値の検証
            Assert.AreEqual("RevTitle",review.Name);
        }
    }
}
