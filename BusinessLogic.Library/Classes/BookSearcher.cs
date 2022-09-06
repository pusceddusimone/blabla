using BusinessLogic.Library.Interfaces;
using DataAccessLayer.Library;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.Classes
{
    public class BookSearcher : IBookSearcher
    {
        Repository _repository;
        public BookSearcher(Repository repository)
        {
            _repository = repository;
        }

        public List<Book> SearchBook(Book book)
        {
            List<Book> books = _repository.GetAllBooks();
            if (book == null)
                return books;
            return books
                .Where(b => book.Title == null || b.Title.ToLower() == book.Title.ToLower())
                .Where(b => (book.Quantity == -1) || (b.Quantity == book.Quantity))
                .Where(b => book.Publisher == null || b.Publisher.ToLower() == book.Publisher.ToLower())
                .Where(b => book.AuthorName == null || b.AuthorName.ToLower() == book.AuthorName.ToLower())
                .Where(b => book.AuthorSurname == null || b.AuthorSurname.ToLower() == book.AuthorSurname.ToLower())
                .Where(b => (book.BookId == -1) || (b.BookId == book.BookId))
                .ToList();
        }
    }
}
