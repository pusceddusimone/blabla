using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ParametersRequester.Classes
{
    public class StatusFilter : IStatusFilter
    {
        public ReservationViewModel.ReservationStatus? FilterForStatus()
        {
            {
                bool invalidInputFlag = false;
                int integerStatus;
                do
                {
                    if (invalidInputFlag)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input, retry");
                    }
                    Console.WriteLine($"Insert reservation status:\n" +
                    $"[{((int)ReservationViewModel.ReservationStatus.Active)}] Active\n" +
                    $"[{((int)ReservationViewModel.ReservationStatus.Inactive)}] Inactive");
                    int.TryParse(Console.ReadLine(), out integerStatus);
                    invalidInputFlag = true;
                } while (!Enum.IsDefined(typeof(ReservationViewModel.ReservationStatus), integerStatus));
                return (ReservationViewModel.ReservationStatus)integerStatus;
            }
        }
    }
}
