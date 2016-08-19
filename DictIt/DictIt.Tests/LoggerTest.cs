namespace DictIt.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DictIt.Model;

    [TestClass]
    public class LoggerTest
    {

        [TestMethod]
        public void ItemSaved_ShouldReturnRightMassage()
        {
            var item = "Term";

            var expected = "Term saved!";
            var result = Logger.ItemSaved(item);

            Assert.AreEqual(expected, result);
        }
    }
}
