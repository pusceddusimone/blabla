using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ParametersRequester.Classes
{
    public class FilterRequesterUser : IFilterRequester
    {
        IBookFilter _bookFilter;
        IStatusFilter _statusFilter;
        int _userId;
        public FilterRequesterUser(IBookFilter bookFilter, IStatusFilter statusFilter,int userId)
        {
            _bookFilter = bookFilter;
            _statusFilter = statusFilter;
            _userId = userId;
        }
        public (int? bookId, int? userId, ReservationViewModel.ReservationStatus? reservationStatus) RequestFilters()
        {
            int? bookId = null;
            ReservationViewModel.ReservationStatus? reservationStatus = null;
            Console.WriteLine("Choose the filters you wish to apply:");

            Console.Write("Do you wish to filter by book properties?[Y/N]: ");
            if (Console.ReadLine().ToLower()[0] == 'y')
                bookId = _bookFilter.FilterForBook();

            Console.Write("Do you wish to filter by status?[Y/N]: ");
            if (Console.ReadLine().ToLower()[0] == 'y')
                reservationStatus = _statusFilter.FilterForStatus();

            return (bookId, _userId, reservationStatus);
        }
    }
}
