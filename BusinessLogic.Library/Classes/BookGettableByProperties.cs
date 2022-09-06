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
    public class BookGettableByProperties : IBookGettableByProperties
    {
        Repository _repository;
        public BookGettableByProperties(Repository repository)
        {
            _repository = repository;
        }
        public Book GetBookByProperties(Book book)
        {
            List<Book> books = _repository.GetAllBooks();
            return books
                .Where(b => b.Title.ToLower() == book.Title.ToLower())
                .Where(b => b.AuthorName.ToLower() == book.AuthorName.ToLower()
                && b.AuthorSurname.ToLower() == book.AuthorSurname.ToLower())
                .Where(b => b.Publisher.ToLower() == book.Publisher.ToLower())
                .Select(b => b).FirstOrDefault();
        }
    }
}
