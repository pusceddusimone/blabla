using BusinessLogic.Library;
using ConsoleApp.Library.Displayer.Interfaces;
using ConsoleApp.Library.ParametersRequester.Classes;
using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class ReservationHistoryManager : IReservationHistoryManager
    {
        IReservationFilter _reservationFilter;
        IReservationHistoryDisplayer _reservationHistoryDisplayer;
        public ReservationHistoryManager(IReservationFilter reservationFilter, IReservationHistoryDisplayer reservationHistoryDisplayer)
        {
            _reservationFilter = reservationFilter;
            _reservationHistoryDisplayer = reservationHistoryDisplayer;
        }
        public void ManageReservationHistory()
        {
            ILibraryBusinessLogic libraryBusinessLogic = new LibraryBusinessLogic();
            (int? bookId, int? userId, ReservationViewModel.ReservationStatus? status) = _reservationFilter.RequestFilters();
            List<ReservationViewModel> reservationHistory = libraryBusinessLogic.GetReservationHistory(bookId, userId, status);
            _reservationHistoryDisplayer.DisplayReservationHistory(reservationHistory);
        }
    }
}
