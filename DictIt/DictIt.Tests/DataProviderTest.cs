namespace DictIt.Tests
{
    using System.Linq;
    using System.Xml.XPath;
    using System.Xml.Linq;
    using NUnit.Framework;

    using DictIt.Data;
    using DictIt.Model;

    [TestFixture]
    public class DataProviderTest
    {
        public const string PathToXml = "DictIt.Tests//Test.xml";

        [Test]
        public void AddToXml_ShouldIncreaseNodesCount()
        {
            var term = new Term("newTerm", "description");
            var nodesCount = XDocument.Load(PathToXml).XPathSelectElements("term").Count();

            DataProvider.AddToXml(PathToXml, term);
            var expected = nodesCount++;
            var current = XDocument.Load(PathToXml).XPathSelectElements("term");

            Assert.AreEqual(expected, current);
        }

        [Test]
        public void RemoveFromXml_ShouldDecreaseNodesCount()
        {
            var nodesCount = XDocument.Load(PathToXml).XPathSelectElements("term").Count();

            DataProvider.RemoveFromXml(PathToXml, "newTerm");
            var expected = nodesCount--;
            var current = XDocument.Load(PathToXml).XPathSelectElements("term").Count();

            Assert.AreEqual(expected, current);
        }
    }
}
