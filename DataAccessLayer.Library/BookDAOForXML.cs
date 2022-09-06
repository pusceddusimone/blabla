using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccessLayer.Library
{
    public class BookDAOForXML : IBookDAO
    {
        public string FileName { get; private set; }
        public BookDAOForXML(string fileName = "Database.xml")
        {
            FileName = fileName;
        }
        private int FindFirstAvaibleIndex()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNodeList nodes = xmlDoc.SelectNodes("/Library/Books/Book");
            int i;
            for (i = 0; i < nodes.Count; i++)
            {
                if (xmlDoc.SelectNodes($"/Library/Books/Book[@BookId={i}]").Count == 0)
                    break;
            }
            return i;
        }
        private Book FillBookFromXmlNode(XmlNode node)
        {
            if (node == null)
                return null;

            int.TryParse(node.Attributes["BookId"].Value, out int bookId);
            int.TryParse(node.Attributes["Quantity"].Value, out int quantity);
            return new Book(
                bookId,
                node.Attributes["Title"].Value,
                node.Attributes["AuthorName"].Value,
                node.Attributes["AuthorSurname"].Value,
                node.Attributes["Publisher"].Value,
                quantity);
        }

        private void UpdateNodeFromBook(XmlNode node, Book book)
        {
            if (book.Title != null && book.Title.Length > 0)
                node.Attributes["Title"].Value = book.Title;
            if (book.AuthorName != null && book.AuthorName.Length > 0)
                node.Attributes["AuthorName"].Value = book.AuthorName;
            if (book.AuthorSurname != null && book.AuthorSurname.Length > 0)
                node.Attributes["AuthorSurname"].Value = book.AuthorSurname;
            if (book.Publisher != null && book.Publisher.Length > 0)
                node.Attributes["Publisher"].Value = book.Publisher;

            node.Attributes["Quantity"].Value = book.Quantity == 0 ? node.Attributes["Quantity"].Value : book.Quantity.ToString();
        }

        public void Create(Book book)
        {
            int index = FindFirstAvaibleIndex();
            book.BookId = index;
            XmlAttribute attribute;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode rootNode = xmlDoc.SelectSingleNode("//Library/Books");

            XmlNode bookNode = xmlDoc.CreateElement("Book");

            foreach(PropertyInfo prop in book.GetType().GetProperties())
            {
                attribute = xmlDoc.CreateAttribute(prop.Name);
                if(prop.GetValue(book) != null)
                    attribute.Value = prop.GetValue(book).ToString();

                bookNode.Attributes.Append(attribute);
            }
            rootNode.AppendChild(bookNode);
            xmlDoc.Save(FileName);

        }

        public List<Book> Read()
        {
            List<Book> booksList = new List<Book>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNodeList nodeList = xmlDoc.SelectNodes("//Library/Books/Book");
            foreach (XmlNode node in nodeList)
            {
                booksList.Add(FillBookFromXmlNode(node));
            }
            return booksList;
        }

        public void Update(int id, Book book)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNodeList nodeList = xmlDoc.SelectNodes($"/Library/Books/Book[@BookId='{id}']");
            XmlNode node = nodeList.Item(0);
            UpdateNodeFromBook(node, book);
            xmlDoc.Save(FileName);
        }

        public Book GetElementById(int id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode node = xmlDoc.SelectSingleNode($"/Library/Books/Book[@BookId={id}]");
            return FillBookFromXmlNode(node);
        }

        public void Delete(int id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode node = xmlDoc.SelectSingleNode($"/Library/Books/Book[@BookId={id}]");
            node.ParentNode.RemoveChild(node);
            xmlDoc.Save(FileName);
        }
    }
}
