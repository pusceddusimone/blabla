using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public class ReservationResult
    {
        public enum ReservationStatus { Successful , NotAvailable , 
            AlreadyReservedByHimself , BookNonexistent };

        public enum ReturnStatus { Successful, NoReservationsActive
        , BookNonexistent};

        public ReturnStatus ReturnOutcome { get; set; }
        public ReservationStatus ReservationOutcome { get; set; }
        public string BookTitle { get; set; }
        public DateTime NextAvailableDate { get; set; }

        public ReservationResult(string bookTitle, 
            DateTime nextAvailableDate, ReservationStatus outcome)
        {
            BookTitle = bookTitle;

            NextAvailableDate = nextAvailableDate;
            ReservationOutcome = outcome;
        }
        public ReservationResult()
        {

        }

        public ReservationResult(ReservationStatus outcome)
        {
            ReservationOutcome = outcome;
        }
        public ReservationResult(ReturnStatus returnOutcome)
        {
            ReturnOutcome = returnOutcome;
        }
    }
}
