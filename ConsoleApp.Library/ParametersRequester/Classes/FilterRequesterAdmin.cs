using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ParametersRequester.Classes
{
    public class FilterRequesterAdmin : IFilterRequester
    {
        IBookFilter _bookFilter;
        IUsernameFilter _usernameFilter;
        IStatusFilter _statusFilter;
        public FilterRequesterAdmin(IBookFilter bookFilter,IUsernameFilter usernameFilter
            , IStatusFilter statusFilter)
        {
            _bookFilter = bookFilter;
            _usernameFilter = usernameFilter;
            _statusFilter = statusFilter;
        }
        public (int? bookId, int? userId, ReservationViewModel.ReservationStatus? reservationStatus) RequestFilters()
        {
            int? bookId = null, userId = null;
            ReservationViewModel.ReservationStatus? reservationStatus = null;
            Console.WriteLine("Choose the filters you wish to apply:");


            Console.Write("Do you wish to filter by book properties?[Y/N]: ");
            if (Console.ReadLine().ToLower()[0] == 'y')
                bookId = _bookFilter.FilterForBook();

            Console.Write("Do you wish to filter by username?[Y/N]: ");
            if (Console.ReadLine().ToLower()[0] == 'y')
                userId = _usernameFilter.FilterForUsername();

            Console.Write("Do you wish to filter by status?[Y/N]: ");
            if (Console.ReadLine().ToLower()[0] == 'y')
                reservationStatus = _statusFilter.FilterForStatus();

            return (bookId, userId, reservationStatus);
        }
    }
}
