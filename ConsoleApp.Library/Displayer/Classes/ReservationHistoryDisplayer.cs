using ConsoleApp.Library.Displayer.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class ReservationHistoryDisplayer : IReservationHistoryDisplayer
    {
        public void DisplayReservationHistory(List<ReservationViewModel> reservations)
        {
            Console.Clear();
            foreach (ReservationViewModel reservation in reservations)
            {
                Console.WriteLine("**********************************");
                Console.WriteLine($"Title: {reservation.BookTitle}");
                Console.WriteLine($"Username: {reservation.Username}");
                Console.WriteLine($"Reservation's start date: {reservation.StartDate}");
                Console.WriteLine($"Reservation's end date: {reservation.EndDate}");
                Console.WriteLine($"Reservation's status: {reservation.Status}");
            }
            if (reservations.Count == 0)
                Console.WriteLine("No reservations found");

            Console.ReadKey();
        }
    }
}
