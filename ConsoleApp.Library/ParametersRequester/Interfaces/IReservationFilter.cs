using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Library;

namespace ConsoleApp.Library.ParametersRequester.Interfaces
{
    public interface IReservationFilter
    {
        (int? bookId, int? userId, ReservationViewModel.ReservationStatus? reservationStatus) RequestFilters();
    }
}
