using ConsoleApp.Library.Displayer.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class ConsoleReservationOutcomeDisplayer : IReservationOutcomeDisplayer
    {
        public void DisplayResult(ReservationResult result)
        {
            Console.Clear();
            switch (result.ReservationOutcome)
            {
                case ReservationResult.ReservationStatus.Successful:
                    Console.WriteLine($"Reservation registered. Return" +
                        $" {result.BookTitle} in the day {result.NextAvailableDate}");
                    break;

                case ReservationResult.ReservationStatus.NotAvailable:
                    Console.WriteLine($"Reservation not registered because the book" +
                        $" {result.BookTitle} is already reserved, and won't be available" +
                        $" until {result.NextAvailableDate}");
                    break;

                case ReservationResult.ReservationStatus.AlreadyReservedByHimself:
                    Console.WriteLine($"Reservation not registered, you've already" +
                        $" an active reservation for {result.BookTitle}");
                    break;

                case ReservationResult.ReservationStatus.BookNonexistent:
                    Console.WriteLine("Reservation not registered, the book does not exist");
                    break;

                default:
                    Console.WriteLine("Invalid operation, try again");
                    break;
            }
            Console.ReadKey();
        }
    }
}
