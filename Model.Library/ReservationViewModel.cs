using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public class ReservationViewModel
    {
        public enum ReservationStatus { Active, Inactive };
        public ReservationStatus Status { get; set; }
        public string BookTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Username { get; set; }

        public ReservationViewModel(Reservation reservation, Book book, User user)
            :this(book.Title, reservation.StartDate, reservation.EndDate, user.Username)
        {
        }
        public ReservationViewModel(string bookTitle, DateTime startDate, DateTime endDate,
            string username)
        {
            BookTitle = bookTitle;
            StartDate = startDate;
            EndDate = endDate;
            Username = username;
            Status = IsReservationActive(endDate)
                ? ReservationStatus.Active : ReservationStatus.Inactive;
        }
        public ReservationViewModel() { }

        public static bool IsReservationActive(DateTime EndDateOfReservation) => EndDateOfReservation >= DateTime.Now;

    }
}
