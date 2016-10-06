namespace DictIt.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using DictIt.Model;

    [TestFixture]
    public class TextManagerTest
    {
        private IList<string> SampleList()
        {
            return new List<string>()
            {
                "kopche",
                "Shimpanze",
                "JQuery",
                "anGular",
                "zdrasti"
            };
        }

        [Test]
        public void MatchedWord_ShouldReturnNull_IfCheckedListDoesNotContainSearchedWord()
        {
            var sampleList = SampleList();
            var searchWord = "agne";

            var expected = null as string;
            var result = TextManager.MatchedWord(searchWord, sampleList);

            Assert.AreEqual(expected, result);

        }

        [Test]
        public void MatchedWord_ShouldReturnSearchedWord_IfCheckedListContainsIt()
        {
            var sampleList = SampleList();
            var searchWord = "Ang";

            var expected = "anGular";
            var result = TextManager.MatchedWord(searchWord, sampleList);

            Assert.AreEqual(expected, result);
        }
    }
}
