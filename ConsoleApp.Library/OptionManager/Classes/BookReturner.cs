using BusinessLogic.Library;
using ConsoleApp.Library.Displayer.Interfaces;
using ConsoleApp.Library.Logger.Interfaces;
using ConsoleApp.Library.ObjectComposer.Interfaces;
using ConsoleApp.Library.OptionManager.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.OptionManager.Classes
{
    public class BookReturner : IBookReturner
    {
        IObjectComposer<Book> _bookComposer;
        ILibraryBusinessLogic _libraryBusinessLogic;
        IMessageLogger _errorLogger;
        IReservationOutcomeDisplayer _reservationOutcomeDisplayer;
        int _userId;
        public BookReturner(IObjectComposer<Book> bookComposer, IMessageLogger errorLogger
            , IReservationOutcomeDisplayer reservationOutcomeDisplayer, int userId)
        {
            _bookComposer = bookComposer;
            _libraryBusinessLogic = new LibraryBusinessLogic();
            _errorLogger = errorLogger;
            _reservationOutcomeDisplayer = reservationOutcomeDisplayer;
            _userId = userId;
        }
        public void ReturnBook()
        {
            Book book = _bookComposer.RequestObject();
            book = _libraryBusinessLogic.GetBookByProperties(book);
            if (book == null)
            {
                _errorLogger.DisplayMessage("Book not found, try again");
                return;
            }
            ReservationResult result = _libraryBusinessLogic.BookReturn(book.BookId, _userId);
            _reservationOutcomeDisplayer.DisplayResult(result);
        }
    }
}
