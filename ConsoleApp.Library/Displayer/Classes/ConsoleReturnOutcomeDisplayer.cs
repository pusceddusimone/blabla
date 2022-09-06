using ConsoleApp.Library.Displayer.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class ConsoleReturnOutcomeDisplayer : IReservationOutcomeDisplayer
    {
        public void DisplayResult(ReservationResult result)
        {
            Console.Clear();
            switch (result.ReturnOutcome)
            {
                case ReservationResult.ReturnStatus.Successful:
                    Console.WriteLine($"Book {result.BookTitle} successfully returned");
                    break;

                case ReservationResult.ReturnStatus.NoReservationsActive:
                    Console.WriteLine($"You didn't reserve the book" +
                        $" named {result.BookTitle}");
                    break;

                case ReservationResult.ReturnStatus.BookNonexistent:
                    Console.WriteLine($"Book not found");
                    break;

                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            Console.ReadKey();
        }
    }
}
