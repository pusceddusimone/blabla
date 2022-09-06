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
    public class BookReturner : IBookReturner
    {
        Repository _repository;
        IIsBookExistingChecker _isBookExistingChecker;
        IReservationHistoryGetter _reservationHistoryGetter;
        IBookSearcher _bookSearcher;
        public BookReturner(Repository repository, IIsBookExistingChecker isBookExistingChecker, 
            IReservationHistoryGetter reservationHistoryGetter, IBookSearcher bookSearcher)
        {
            _repository = repository;
            _isBookExistingChecker = isBookExistingChecker;
            _reservationHistoryGetter = reservationHistoryGetter;
            _bookSearcher = bookSearcher;
        }

        public ReservationResult BookReturn(int bookId, int userId)
        {
            if (!_isBookExistingChecker.IsBookExisting(bookId))
                return new ReservationResult(ReservationResult.ReturnStatus.BookNonexistent);
            ReservationViewModel activeReservation = _reservationHistoryGetter.GetReservationHistory(bookId, userId,
                ReservationViewModel.ReservationStatus.Active).SingleOrDefault();
            Book reservedBook = _bookSearcher.SearchBook(new Book()
            {
                BookId = bookId,
                Quantity = -1
            }).Single();
            if (activeReservation == null)
                return new ReservationResult(ReservationResult.ReturnStatus.NoReservationsActive)
                {
                    BookTitle = reservedBook.Title
                };
            else
            {
                Reservation reservation = FindReservationWithUserAndBook(bookId, userId);
                _repository.UpdateReservation(reservation.ReservationId, UpdateEndDateOfReservation(reservation, DateTime.Now));
                return new ReservationResult(ReservationResult.ReturnStatus.Successful)
                {
                    BookTitle = reservedBook.Title
                };
            }
        }
        private Reservation FindReservationWithUserAndBook(int bookId, int userId) => _repository.GetAllReservations()
                .Where(r => r.UserId == userId)
                .Where(r => r.BookId == bookId)
                .FirstOrDefault();
        private Reservation UpdateEndDateOfReservation(Reservation reservationToUpdate, DateTime newEndDate)
        {
            reservationToUpdate.EndDate = newEndDate;
            return reservationToUpdate;
        }
    }
}
