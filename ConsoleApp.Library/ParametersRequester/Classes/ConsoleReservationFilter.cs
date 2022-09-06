using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Library;
using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;

namespace ConsoleApp.Library.ParametersRequester.Classes
{
    public class ConsoleReservationFilter : IReservationFilter
    {
        IBookFilter _bookFilter;
        ILibraryBusinessLogic _libraryBusinessLogic;
        IFilterRequester _filterRequester;
        public ConsoleReservationFilter(ILibraryBusinessLogic libraryBusinessLogic
            , IBookFilter bookFilter, IFilterRequester filterRequester)
        {
            _libraryBusinessLogic = libraryBusinessLogic;
            _bookFilter = bookFilter;
            _filterRequester = filterRequester;
        }
        public (int? bookId, int? userId, ReservationViewModel.ReservationStatus? reservationStatus) RequestFilters() => _filterRequester.RequestFilters();
    }
}
