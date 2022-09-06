using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ParametersRequester.Interfaces
{
    public interface IFilterRequester
    {
        (int? bookId, int? userId, ReservationViewModel.ReservationStatus? reservationStatus) RequestFilters();
    }
}
