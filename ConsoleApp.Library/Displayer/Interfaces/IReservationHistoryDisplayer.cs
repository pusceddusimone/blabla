using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Interfaces
{
    public interface IReservationHistoryDisplayer
    {
        void DisplayReservationHistory(List<ReservationViewModel> reservations);
    }
}
