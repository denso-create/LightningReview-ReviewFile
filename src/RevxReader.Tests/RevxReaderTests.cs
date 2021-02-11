using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightningReview.RevxReader.Tests
{
    [TestClass]
    public class RevxReaderTests : TestBase
    {
        [TestMethod]
        public void LoadTest()
        {
            // �t�@�C�������[�h
            var filepath = GetTestDataPath("RevFile1.revx");
            var reader = new RevxReader();
            var review = reader.Load(filepath);

            // �t�B�[���h�l�̌���
            Assert.AreEqual("RevTitle",review.Name);
        }
    }
}
