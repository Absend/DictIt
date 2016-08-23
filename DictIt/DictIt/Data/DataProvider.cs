namespace DictIt.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Linq;

    using Model;

    public static class DataProvider
    {
        public static void AddToXml(string documentPath, Term term)
        {
            var root = XDocument.Load(documentPath).Root;
            if (root == null) return;
            root.Add(new XElement("term",
                new XElement("name", term.Name),
                new XElement("description", term.Description)));
            if (root.Document != null) root.Document.Save(documentPath);
        }

        public static void RemoveFromXml(string documentPath, string termName)
        {
            var root = XDocument.Load(documentPath).Root;
            if (root == null) return;
            foreach (var termElement in root.Elements("term"))
            {
                if (termElement.Element("name").Value == termName)
                {
                    termElement.Remove();
                }
            }
            if (root.Document != null) root.Document.Save(documentPath);
        }

        public static ObservableCollection<string> TakeNamesFromXml(string documentPath)
        {
            var termsDocumentRoot = XDocument.Load(documentPath).Root;
            if (termsDocumentRoot == null) return null;
            var terms = new ObservableCollection<string>();
            foreach (var termElement in termsDocumentRoot.Elements("term"))
            {
                terms.Add(termElement.Element("name").Value);
            }
            return new ObservableCollection<string>(terms.OrderBy(i => i));
        }

        public static IDictionary<string, string> TakeTermsFromXml(string documentPath)
        {
            var termsDocumentRoot = XDocument.Load(documentPath).Root;
            if (termsDocumentRoot == null) return null;
            var terms = new SortedDictionary<string, string>();
            foreach (var termElement in termsDocumentRoot.Elements("term"))
            {
                terms.Add(termElement.Element("name").Value, termElement.Element("description").Value);
            }
            return terms;
        }
    }
}