namespace DictIt.Tests
{
    using NUnit.Framework;
    using DictIt.Model;

    [TestFixture]
    public class TermTest
    {
        [Test]
        public void Test_ShouldReturnTrue_IfTermHasCorrectValues()
        {
            var term = new Term("term", "description");

            var isCorrectTerm = (term.Name == "term" && term.Description == "description");

            Assert.IsTrue(isCorrectTerm);
        }
    }
}
