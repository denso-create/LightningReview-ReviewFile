using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightningReview.RevxFile.Tests
{
    [TestClass]
    public class RevxReaderTests : TestBase
    {
        [TestMethod]
        public void LoadTest()
        {
            var filepath = GetTestDataPath("RevFile1.revx");
            var reader = new RevxReader();
            var review = reader.Load(filepath);

            Assert.AreEqual("RevTitle",review.Name);
        }
    }
}
