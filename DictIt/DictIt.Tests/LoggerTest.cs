namespace DictIt.Tests
{
    using NUnit.Framework;
    using DictIt.Model;

    [TestFixture]
    public class LoggerTest
    {

        [Test]
        public void ItemSaved_ShouldReturnRightMassage()
        {
            var item = "Term";

            var expected = "Term saved!";
            var result = Logger.ItemSaved(item);

            Assert.AreEqual(expected, result);
        }
    }
}
