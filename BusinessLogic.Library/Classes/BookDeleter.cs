using BusinessLogic.Library.Exceptions;
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
    public class BookDeleter : IBookDeleter
    {
        Repository _repository;
        IIsBookExistingChecker _isBookExistingChecker;
        IReservationHistoryGetter _reservationHistoryGetter;
        public BookDeleter(Repository repository, IIsBookExistingChecker isBookExistingChecker, IReservationHistoryGetter reservationHistoryGetter)
        {
            _repository = repository;
            _isBookExistingChecker = isBookExistingChecker;
            _reservationHistoryGetter = reservationHistoryGetter;
        }

        public void DeleteBook(int bookId)
        {
            if (!_isBookExistingChecker.IsBookExisting(bookId))
                throw new ArgumentException("This book does not exist");

            CheckIfAllReservationsAreInactive(bookId); //Throws exception if some res. are active

            _repository.DeleteBook(bookId);
            RemoveAllInactiveReservations(bookId);
        }

        private void CheckIfAllReservationsAreInactive(int bookId)
        {
            List<ReservationViewModel> reservations =
                _reservationHistoryGetter.GetReservationHistory(bookId, null, ReservationViewModel.ReservationStatus.Active);
            if (reservations != null && reservations.Count > 0)
                throw new ReservationsStillActiveException(reservations);
        }
        private void RemoveAllInactiveReservations(int bookId)
        {
            List<Reservation> inactiveReservations = FindAllInactiveReservationsWithBookId(bookId);
            foreach (Reservation reservation in inactiveReservations)
            {
                _repository.DeleteReservation(reservation.ReservationId);
            }
        }
        private List<Reservation> FindAllInactiveReservationsWithBookId(int bookId) => _repository.GetAllReservations()
        .Where(r => !ReservationViewModel.IsReservationActive(r.EndDate))
        .Where(r => r.BookId == bookId)
        .ToList();
    }
}
