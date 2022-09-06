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
    public class ReservationHistoryGetter : IReservationHistoryGetter
    {
        Repository _repository;
        public ReservationHistoryGetter(Repository repository)
        {
            _repository = repository;
        }

        public List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationViewModel.ReservationStatus? reservationStatus)
        {
            List<ReservationViewModel> reservationHistory = new List<ReservationViewModel>();
            if (reservationStatus != null && !Enum.IsDefined(typeof(ReservationViewModel.ReservationStatus), reservationStatus)) //Check if enum is valid
                throw new ArgumentOutOfRangeException(nameof(reservationStatus));

            List<Reservation> reservations = _repository.GetAllReservations();
            reservations = reservations
            .Where(r => (bookId == null || bookId == r.BookId)
             && (userId == null || userId == r.UserId)
            && ((reservationStatus == null)
            || (reservationStatus == ReservationViewModel.ReservationStatus.Active && r.EndDate >= DateTime.Now)
            || (reservationStatus == ReservationViewModel.ReservationStatus.Inactive && r.EndDate < DateTime.Now))).ToList();

            foreach (Reservation reservation in reservations)
            {
                User user = _repository.GetUserById(reservation.UserId);
                Book book = _repository.GetBookById(reservation.BookId);
                if (book == null || user == null)
                    continue;
                reservationHistory.Add(new ReservationViewModel(reservation, book, user));
            }
            return reservationHistory;
        }
    }
}
