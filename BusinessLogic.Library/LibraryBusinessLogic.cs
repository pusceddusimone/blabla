using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Library.Classes;
using BusinessLogic.Library.Exceptions;
using BusinessLogic.Library.Interfaces;
using DataAccessLayer.Library;
using Model.Library;

namespace BusinessLogic.Library
{
    public class LibraryBusinessLogic : ILibraryBusinessLogic
    {
        Repository _repository;
        IBookGettableByProperties _bookGettableByProperties;
        IFirstIndexFinder _firstIndexFinder;
        IBookAdder _bookAdder;
        IBookSearcher _bookSearcher;
        IIsBookExistingChecker _isBookExistingChecker;
        IIsUpdatedBookDuplicateChecker _isUpdatedBookDuplicateChecker;
        IBookUpdater _bookUpdater;
        IReservationHistoryGetter _reservationHistoryGetter;
        IUserGetterByUsername _userGetterByUsername;
        IBookSearcherWithAvailabilityInfo _bookSearcherWithAvailabilityInfo;
        ILogger _logger;
        IBookDeleter _bookDeleter;
        IBookReserver _bookReserver;
        IBookReturner _bookReturner;
        public LibraryBusinessLogic()
        {
            _repository = new Repository(new UserDAOForXML(),
                new BookDAOForXML(),
                new ReservationDAOForXML());
            _bookGettableByProperties = new BookGettableByProperties(_repository);
            _firstIndexFinder = new FirstIndexFinder(_repository);
            _bookAdder = new BookAdder(_repository, _firstIndexFinder, _bookGettableByProperties);
            _bookSearcher = new BookSearcher(_repository);
            _isBookExistingChecker = new IsBookExistingChecker(_bookSearcher);
            _isUpdatedBookDuplicateChecker = new IsUpdatedBookDuplicateChecker(_bookSearcher, _bookGettableByProperties);
            _bookUpdater = new BookUpdater(_repository, _isBookExistingChecker, _isUpdatedBookDuplicateChecker);
            _reservationHistoryGetter = new ReservationHistoryGetter(_repository);
            _userGetterByUsername = new UserGetterByUsername(_repository);
            _bookSearcherWithAvailabilityInfo = new BookSearcherWithAvailabilityInfo(_bookSearcher, _reservationHistoryGetter);
            _logger = new Logger(_repository);
            _bookDeleter = new BookDeleter(_repository, _isBookExistingChecker, _reservationHistoryGetter);
            _bookReserver = new BookReserver(_repository, _isBookExistingChecker, _reservationHistoryGetter, _bookSearcherWithAvailabilityInfo);
            _bookReturner = new BookReturner(_repository, _isBookExistingChecker, _reservationHistoryGetter, _bookSearcher);
        }

        public Book GetBookByProperties(Book book) => _bookGettableByProperties.GetBookByProperties(book);

        public void AddBook(Book book) => _bookAdder.AddBook(book);

        public User Login(string username = null, string password = null) => _logger.Login(username, password);

        public List<Book> SearchBook(Book book) => _bookSearcher.SearchBook(book);

        public void UpdateBook(int bookId, Book bookWithNewValues) => _bookUpdater.UpdateBook(bookId, bookWithNewValues);

        public List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationViewModel.ReservationStatus? reservationStatus) => _reservationHistoryGetter.GetReservationHistory(bookId, userId, reservationStatus);

        public User GetUserByUserName(string userName) => _userGetterByUsername.GetUserByUserName(userName);

        public List<BookViewModel> SearchBookWithAvailabilityInfos(Book book) => _bookSearcherWithAvailabilityInfo.SearchBookWithAvailabilityInfos(book);

        public ReservationResult ReserveBook(int bookId, int userId) => _bookReserver.ReserveBook(bookId, userId);

        public ReservationResult BookReturn(int bookId, int userId) => _bookReturner.BookReturn(bookId, userId);

        public void DeleteBook(int bookId) => _bookDeleter.DeleteBook(bookId);

    }
}
