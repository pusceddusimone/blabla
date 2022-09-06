using BusinessLogic.Library;
using BusinessLogic.Library.Exceptions;
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
    public class BookDeleter : IBookDeleter
    {
        ILibraryBusinessLogic _libraryBusinessLogic;
        IObjectComposer<Book> _bookComposer;
        IMessageLogger _logger;

        public BookDeleter(ILibraryBusinessLogic libraryBusinessLogic
            , IObjectComposer<Book> bookComposer, IMessageLogger logger)
        {
            _libraryBusinessLogic = libraryBusinessLogic;
            _bookComposer = bookComposer;
            _logger = logger;
        }
        public void DeleteBook()
        {
            Book book = _bookComposer.RequestObject();
            Book foundBook = _libraryBusinessLogic.GetBookByProperties(book);
            if (foundBook == null)
            {
                _logger.DisplayMessage("Book does not exist, try again");
                return;
            }
            try
            {
                _libraryBusinessLogic.DeleteBook(foundBook.BookId);
                _logger.DisplayMessage("Book deleted");
            }
            catch(ReservationsStillActiveException ex)
            {
                DisplayError(ex);
            }
        }
        private void DisplayError(ReservationsStillActiveException ex)
        {
            foreach(ReservationViewModel reservation in ex.ActiveReservationsInformation)
            {
                _logger.DisplayMessage($"Reservation not registered because" +
                    $" the book {reservation.BookTitle} is still reserved by" +
                    $" {reservation.Username} from the date {reservation.StartDate} to {reservation.EndDate}");
            }
        }
    }
}
