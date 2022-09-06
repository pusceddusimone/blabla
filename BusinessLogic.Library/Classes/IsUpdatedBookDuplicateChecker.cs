using BusinessLogic.Library.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.Classes
{
    public class IsUpdatedBookDuplicateChecker : IIsUpdatedBookDuplicateChecker
    {
        IBookSearcher _bookSearcher;
        IBookGettableByProperties _bookGettableByProperties;
        public IsUpdatedBookDuplicateChecker(IBookSearcher bookSearcher, IBookGettableByProperties bookGettableByProperties)
        {
            _bookSearcher = bookSearcher;
            _bookGettableByProperties = bookGettableByProperties;
        }

        private Book JoinBookProperties(Book source, Book destination)
        {
            source.Title = destination.Title ?? source.Title;
            source.AuthorName = destination.AuthorName ?? source.AuthorName;
            source.AuthorSurname = destination.AuthorSurname ?? source.AuthorSurname;
            source.Publisher = destination.Publisher ?? source.Publisher;
            source.Quantity = destination.Quantity;
            source.BookId = destination.BookId;

            return source;
        }

        public bool IsUpdatedBookDuplicate(int idOfBookToUpdate, Book newBook)
        {
            Book bookToUpdate = _bookSearcher.SearchBook(new Book
            {
                BookId = idOfBookToUpdate,
                Quantity = -1
            }).First();
            Book resultantBook = JoinBookProperties(bookToUpdate, newBook);
            return _bookGettableByProperties.GetBookByProperties(resultantBook) != null;
        }
    }
}
