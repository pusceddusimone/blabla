using ConsoleApp.Library.Displayer.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class ConsoleDisplayer : IDisplayer
    {
        IOptionDisplayer _menuDisplayer;
        IMenuValidator _validator;
        IOptionManager _optionManager;
        IMenuDisplayer _menuShower;
        IReservationHistoryDisplayer _reservationHistoryDisplayer;
        public ConsoleDisplayer(IOptionDisplayer menuDisplayer, IMenuValidator validator,
           IOptionManager optionManager, IMenuDisplayer menuShower, IReservationHistoryDisplayer reservationHistoryDisplayer)
        {
            _menuDisplayer = menuDisplayer;
            _validator = validator;
            _optionManager = optionManager;
            _menuShower = menuShower;
            _reservationHistoryDisplayer = reservationHistoryDisplayer;
        }
        public void DisplayMenu() => _menuDisplayer.DisplayMenu();

        public void DisplayReservationHistory(List<ReservationViewModel> reservations) => _reservationHistoryDisplayer.DisplayReservationHistory(reservations);

        public bool IsMenuOptionValid(string option) => _validator.IsMenuOptionValid(option);

        public int ManageOptionChosen(int option) => _optionManager.ManageOptionChosen(option);

        public void ShowMenu(User user) => _menuShower.ShowMenu(user);

    }
}
