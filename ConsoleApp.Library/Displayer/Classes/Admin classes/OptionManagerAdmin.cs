using BusinessLogic.Library;
using ConsoleApp.Library.Displayer.Interfaces;
using ConsoleApp.Library.Logger.Interfaces;
using ConsoleApp.Library.ObjectComposer.Classes;
using ConsoleApp.Library.ObjectComposer.Interfaces;
using ConsoleApp.Library.ObjectValidator.Classes;
using ConsoleApp.Library.ObjectValidator.Interfaces;
using ConsoleApp.Library.OptionManager.Interfaces;
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
    public class OptionManagerAdmin : IOptionManager
    {
        ILibraryBusinessLogic _libraryBusinessLogic;
        IMenuValidator _menuValidator;
        IBookCreator _bookCreatorForInsert;
        IReservationHistoryManager _reservationHistoryManager;
        IBookFilterOptionalParameters _bookFilterOptionalParameters;
        IBookViewModelDisplayer _bookViewModelDisplayer;
        IBookReserver _bookReserver;
        IBookReturner _bookReturner;
        IBookDeleter _bookDeleter;
        IBookEditor _bookEditor;   
        public OptionManagerAdmin(IMenuValidator menuValidator, IBookCreator bookCreatorForInsert
            , IReservationHistoryManager reservationHistoryManager,
            IBookFilterOptionalParameters bookFilterOptionalParameters, IBookViewModelDisplayer bookViewModelDisplayer
            , IBookReserver bookReserver, IBookReturner bookReturner, IBookDeleter bookDeleter
, IBookEditor bookEditor)
        {
            _menuValidator = menuValidator;
            _bookCreatorForInsert = bookCreatorForInsert;
            _reservationHistoryManager = reservationHistoryManager;
            _bookFilterOptionalParameters = bookFilterOptionalParameters;
            _libraryBusinessLogic = new LibraryBusinessLogic();
            _bookViewModelDisplayer = bookViewModelDisplayer;
            _bookReserver = bookReserver;
            _bookReturner = bookReturner;
            _bookDeleter = bookDeleter;
            _bookEditor = bookEditor;
        }
        public int ManageOptionChosen(int option)
        {
            if (!_menuValidator.IsMenuOptionValid(option.ToString()))
                throw new ArgumentException("Invalid option");
            Console.Clear();
            switch (option)
            {
                case 1: //Create a book
                    {
                        _bookCreatorForInsert.CreateBook();
                        break;
                    }

                case 2: //Edit a book
                    {
                        _bookEditor.EditBook();
                        break;
                    }

                case 3: //Delete a book
                    {
                        _bookDeleter.DeleteBook();
                        break;
                    }


                case 4: //Search a book
                    {
                        Book book = _bookFilterOptionalParameters.FilterForBook();
                        List<BookViewModel> books = _libraryBusinessLogic.SearchBookWithAvailabilityInfos(book);
                        _bookViewModelDisplayer.DisplayBooksView(books);
                        break;
                    }

                case 5: //Reserve a book
                    {
                        _bookReserver.ReserveBook();
                        break;
                    }

                case 6: //Return a book
                    _bookReturner.ReturnBook();
                    break;

                case 7: //Reservation history
                    {
                        _reservationHistoryManager.ManageReservationHistory();
                        break;
                    }

                case 8: //Logout
                    {
                        return 0;
                    }

                default:
                    throw new ArgumentException("Invalid option");
            }
            return 1;
        }
    }
}
