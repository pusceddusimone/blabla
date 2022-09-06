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
    public class BookUpdater : IBookUpdater
    {
        Repository _repository;
        IIsBookExistingChecker _checker;
        IIsUpdatedBookDuplicateChecker _isUpdatedBookDuplicateChecker;
        public BookUpdater(Repository repository, IIsBookExistingChecker checker, IIsUpdatedBookDuplicateChecker isUpdatedBookDuplicateChecker)
        {
            _repository = repository;
            _checker = checker;
            _isUpdatedBookDuplicateChecker = isUpdatedBookDuplicateChecker;
        }

        public void UpdateBook(int bookId, Book bookWithNewValues)
        {
            if (!_checker.IsBookExisting(bookId))
                throw new ArgumentException($"No book found to update with id: {bookId}");
            if (_isUpdatedBookDuplicateChecker.IsUpdatedBookDuplicate(bookId, bookWithNewValues))
                throw new InvalidOperationException("This book is already in the system");
            bookWithNewValues.Quantity = 0;
            _repository.UpdateBookByiD(bookId, bookWithNewValues);
        }
    }
}
