using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayer.Library;
using Model.Library;
using System.Xml;
using System.Collections.Generic;

namespace LibraryTests
{
    [TestClass]
    public class BookDAOForXMLTests
    {
        XmlDocument xmlDoc, xmlBackup;
        BookDAOForXML bookDAOForXML;
        private readonly string fileNameForTest = @"C:\Users\simone.pusceddu\source\repos\Solution.Library\ConsoleApp.Library\bin\Debug\Test.xml";
        [TestInitialize]
        public void SetUp()
        {
            xmlDoc = new XmlDocument();
            xmlBackup = new XmlDocument();
            xmlDoc.Load(fileNameForTest);
            xmlBackup.Load(fileNameForTest);
            bookDAOForXML = new BookDAOForXML(fileNameForTest);
        }      
        [TestMethod]
        public void ReadShouldReturnListOfLengthFive()
        {
            List<Book> books = bookDAOForXML.Read();
            Assert.AreEqual(5, books.Count);
        }
        [TestMethod]
        public void ReadShouldReturnListWithBookWithAuthorNamedGiuseppeAtPosition4()
        {
            Book book = new Book(4, "Franco", "Giuseppe", "Mirto", "Esempio", 6);
            List<Book> books = bookDAOForXML.Read();
            Assert.IsTrue(AreBooksEqual(book, books[4]));
        }
        [TestMethod]
        public void GetElementByIdShouldGiveNullWhenElementIsNotFound()
        {
            Assert.IsNull(bookDAOForXML.GetElementById(10));
        }
        [TestMethod]
        public void GetElementByIdShouldReturnBookWithIdValue4()
        {
            Book foundBook = bookDAOForXML.GetElementById(4);
            Book expectedBook = new Book()
            {
                BookId = 4,
                Title = "Franco",
                AuthorName = "Giuseppe",
                AuthorSurname = "Mirto",
                Publisher = "Esempio",
                Quantity = 6
            };
            Assert.IsTrue(AreBooksEqual(foundBook, expectedBook));
        }
        [TestMethod]
        public void CreateShouldInsertBook()
        {
            try
            {
                Book book = new Book()
                {
                    AuthorName = "TestName",
                    AuthorSurname = "TestSurname",
                    Quantity = 7,
                    Publisher = "TestPublisher"
                };
                bookDAOForXML.Create(book);
                xmlDoc.Load(fileNameForTest);
                XmlNode node = xmlDoc.SelectSingleNode("/Library/Books/Book[@BookId=5]");
                if (node != null)
                {
                    node.ParentNode.RemoveChild(node);
                    xmlDoc.Save(fileNameForTest);
                }
                Assert.IsNotNull(node);
            }
            finally
            {
                xmlBackup.Save(fileNameForTest);
            }
        }
        [TestMethod]
        public void UpdateShouldUpdateABook()
        {
            try
            {
                Book book = new Book()
                {
                    AuthorName = "TestName",
                    AuthorSurname = "TestSurname",
                    Quantity = 7,
                    Publisher = "TestPublisher"
                };
                bookDAOForXML.Create(book);
                Book updatedBook = new Book()
                {
                    BookId = 5,
                    AuthorName = "UpdatedName",
                    AuthorSurname = "UpdatedSurname",
                    Quantity = 9,
                    Publisher = "UpdatedPublisher"
                };
                bookDAOForXML.Update(book.BookId, updatedBook);
                xmlDoc.Load(fileNameForTest);
                Book foundBook = bookDAOForXML.GetElementById(book.BookId);
                Assert.IsTrue(AreBooksEqual(foundBook, updatedBook));
            }
            finally
            {
                xmlBackup.Save(fileNameForTest);
            }

        }

        [TestMethod]
        public void DeleteShouldRemoveGivenElement()
        {
            try
            {
                bookDAOForXML.Delete(0);
                Assert.IsNull(bookDAOForXML.GetElementById(0));
            } 
            finally
            {
                xmlBackup.Save(fileNameForTest);
            }
        }


        [TestCleanup]
        public void TearDown()
        {
            xmlBackup.Save(fileNameForTest);
        }


        private bool AreBooksEqual(Book book1, Book book2)
        {
            if (book1 == null || book2 == null)
                return false;

            return book1.BookId == book2.BookId
                && book1.Publisher == book2.Publisher
                && book1.AuthorName == book2.AuthorName
                && book1.AuthorSurname == book2.AuthorSurname
                && book1.Quantity == book2.Quantity;
        }
    }
}
