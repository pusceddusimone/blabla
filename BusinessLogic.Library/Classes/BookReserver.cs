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
    public class BookReserver : IBookReserver
    {
        Repository _repository;
        IIsBookExistingChecker _isBookExistingChecker;
        IReservationHistoryGetter _reservationHistoryGetter;
        IBookSearcherWithAvailabilityInfo _bookSearcherWithAvailabilityInfo;
        public BookReserver(Repository repository, IIsBookExistingChecker isBookExistingChecker, IReservationHistoryGetter reservationHistoryGetter, IBookSearcherWithAvailabilityInfo bookSearcherWithAvailabilityInfo)
        {
            _repository = repository;
            _isBookExistingChecker = isBookExistingChecker;
            _reservationHistoryGetter = reservationHistoryGetter;
            _bookSearcherWithAvailabilityInfo = bookSearcherWithAvailabilityInfo;
        }

        public ReservationResult ReserveBook(int bookId, int userId)
        {
            if (!_isBookExistingChecker.IsBookExisting(bookId)) //Check if book exists
                return new ReservationResult(ReservationResult.ReservationStatus.BookNonexistent);

            List<ReservationViewModel> reservationsAlreadyMade = _reservationHistoryGetter.GetReservationHistory(bookId, userId,
                ReservationViewModel.ReservationStatus.Active);

            if (reservationsAlreadyMade.Count > 0) //Check if user already reserved that book
                return new ReservationResult()
                {
                    ReservationOutcome = ReservationResult.ReservationStatus.AlreadyReservedByHimself,
                    BookTitle = reservationsAlreadyMade.First().BookTitle
                };

            Book filterBook = new Book()
            {
                BookId = bookId,
                Quantity = -1
            };
            BookViewModel bookAvailability = _bookSearcherWithAvailabilityInfo.SearchBookWithAvailabilityInfos(filterBook).Single();
            if (bookAvailability.BookAvaiability == BookViewModel.Availability.Available)
            {
                _repository.AddReservation(new Reservation()
                {
                    BookId = bookId,
                    UserId = userId,
                    StartDate = DateTime.Now,

                });
                return new ReservationResult(bookAvailability.Book.Title, bookAvailability.AvaiabilityDate,
                    ReservationResult.ReservationStatus.Successful);
            }
            else
            {
                return new ReservationResult(bookAvailability.Book.Title
                    , bookAvailability.AvaiabilityDate
                    , ReservationResult.ReservationStatus.NotAvailable);
            }
        }
    }
}
