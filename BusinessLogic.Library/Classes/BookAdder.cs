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
    public class BookAdder : IBookAdder
    {
        Repository _repository;
        IFirstIndexFinder _firstIndexFinder;
        IBookGettableByProperties _bookGettableByProperties;
        public BookAdder(Repository repository, IFirstIndexFinder firstIndexFinder,
            IBookGettableByProperties bookGettableByProperties)
        {
            _repository = repository;
            _firstIndexFinder = firstIndexFinder;
            _bookGettableByProperties = bookGettableByProperties;
        }
        public void AddBook(Book book)
        {
            book.BookId = _firstIndexFinder.FindFirstAvaibleIndex();
            Book duplicatedBook = _bookGettableByProperties.GetBookByProperties(book);
            if (duplicatedBook != null)
            {
                duplicatedBook.Quantity++;
                _repository.UpdateBookByiD(duplicatedBook.BookId, duplicatedBook);
            }
            else
            {
                _repository.AddBook(book);
            }
        }
    }
}
