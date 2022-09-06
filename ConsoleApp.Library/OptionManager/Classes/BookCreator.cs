using BusinessLogic.Library;
using ConsoleApp.Library.Logger.Interfaces;
using ConsoleApp.Library.ObjectComposer.Classes;
using ConsoleApp.Library.ObjectComposer.Interfaces;
using ConsoleApp.Library.ObjectValidator.Classes;
using ConsoleApp.Library.ObjectValidator.Interfaces;
using ConsoleApp.Library.OptionManager.Interfaces;
using ConsoleApp.Library.ParametersRequester.Classes;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.OptionManager.Classes
{
    public class BookCreator : IBookCreator
    {
        IObjectComposer<Book> _bookComposer;
        IMessageLogger _messageLogger;
        public BookCreator(IObjectComposer<Book> bookComposer, IMessageLogger messageLogger)
        {
            _bookComposer = bookComposer;
            _messageLogger = messageLogger;
        }

        public void CreateBook()
        {
            ILibraryBusinessLogic libraryBusinessLogic = new LibraryBusinessLogic();
            Book book = _bookComposer.RequestObject();
            IObjectValidator<Book> objectValidator = new BookValidator();
            if (objectValidator.IsObjectValid(book))
            {
                libraryBusinessLogic.AddBook(book);
                _messageLogger.DisplayMessage("Book added.");
            }
            else
            {
                _messageLogger.DisplayMessage("Some of the parameters inserted are not valid");
            }
        }
    }
}
