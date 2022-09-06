using BusinessLogic.Library;
using ConsoleApp.Library.Displayer.Interfaces;
using ConsoleApp.Library.OptionManager.Interfaces;
using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class OptionManagerUser : IOptionManager
    {
        IReservationHistoryManager _reservationHistoryManager;
        IBookFilterOptionalParameters _bookFilterOptionalParameters;
        IBookViewModelDisplayer _bookViewModelDisplayer;
        ILibraryBusinessLogic _libraryBusinessLogic;
        IBookReserver _bookReserver;
        IBookReturner _bookReturner;
        public OptionManagerUser(IReservationHistoryManager reservationHistoryManager
            ,IBookFilterOptionalParameters bookFilterOptionalParameters
            , IBookViewModelDisplayer bookViewModelDisplayer
            , IBookReserver bookReserver, IBookReturner bookReturner)
        {
            _reservationHistoryManager = reservationHistoryManager;
            _bookFilterOptionalParameters = bookFilterOptionalParameters;
            _bookViewModelDisplayer = bookViewModelDisplayer;
            _libraryBusinessLogic = new LibraryBusinessLogic();
            _bookReserver = bookReserver;
            _bookReturner = bookReturner;
        }
        public int ManageOptionChosen(int option)
        {
            switch (option)
            {
                case 1: //Find a book
                    {
                        Book book = _bookFilterOptionalParameters.FilterForBook();
                        List<BookViewModel> books = _libraryBusinessLogic.SearchBookWithAvailabilityInfos(book);
                        _bookViewModelDisplayer.DisplayBooksView(books);
                        break;
                    }
                case 2: //Reserve a book
                    _bookReserver.ReserveBook();
                    break;
                case 3:
                    _bookReturner.ReturnBook();
                    break;
                case 4: //Reservation history
                    _reservationHistoryManager.ManageReservationHistory();
                    break;
                case 5: //Exit
                    return 0;
                default:
                    throw new InvalidOperationException("Invalid choice");
            }
            return 1;
        }
    }
}
