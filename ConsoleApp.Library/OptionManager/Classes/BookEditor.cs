using BusinessLogic.Library;
using ConsoleApp.Library.Logger.Interfaces;
using ConsoleApp.Library.ObjectComposer.Interfaces;
using ConsoleApp.Library.ObjectValidator.Classes;
using ConsoleApp.Library.ObjectValidator.Interfaces;
using ConsoleApp.Library.OptionManager.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.OptionManager.Classes
{
    public class BookEditor : IBookEditor
    {
        IObjectComposer<Book> _objectComposer;
        ILibraryBusinessLogic _libraryBusinessLogic;
        IMessageLogger _messageLogger;
        public BookEditor(IObjectComposer<Book> objectComposer, IMessageLogger messageLogger)
        {
            _objectComposer = objectComposer;
            _libraryBusinessLogic = new LibraryBusinessLogic();
            _messageLogger = messageLogger;
        }

        public void EditBook()
        {
            Book book = _objectComposer.RequestObject();
            IObjectValidator<Book> objectValidator = new BookValidatorForUpdate();
            if (objectValidator.IsObjectValid(book))
                _libraryBusinessLogic.UpdateBook(book.BookId, book);
            else
                _messageLogger.DisplayMessage($"Book with id {book.BookId} not found");
        }
    }
}
