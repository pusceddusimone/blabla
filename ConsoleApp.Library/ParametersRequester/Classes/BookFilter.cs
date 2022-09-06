using BusinessLogic.Library;
using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ParametersRequester.Classes
{
    public class BookFilter : IBookFilter
    {
        ILibraryBusinessLogic _libraryBusinessLogic;
        IMandatoryParameterRequester _mandatoryParameterRequester;
        public BookFilter(IMandatoryParameterRequester mandatoryParameterRequester,
            ILibraryBusinessLogic libraryBusinessLogic)
        {
            _mandatoryParameterRequester = mandatoryParameterRequester;
            _libraryBusinessLogic = libraryBusinessLogic;
        }
        public int? FilterForBook()
        {
            bool bookNotFoundFlag = false;
            Book bookFound, bookPropertiesToFilter;
            do
            {
                if (bookNotFoundFlag)
                {
                    string answer = _mandatoryParameterRequester.RequestMandatoryParameter
                        ("Book not found, do you wish to try again?[Y/N]");
                    if (answer[0] != 'y')
                        return null;
                }

                bookPropertiesToFilter = FilterByBookProperties();

                if (bookPropertiesToFilter == null)
                    return null;

                bookFound = _libraryBusinessLogic.GetBookByProperties(bookPropertiesToFilter);
                bookNotFoundFlag = true;
            } while (bookFound == null);
            return bookFound.BookId;
        }
        private Book FilterByBookProperties()
        {
            Book book = new Book();
            book.Title = _mandatoryParameterRequester.RequestMandatoryParameter("Insert book's title: ");
            book.AuthorName = _mandatoryParameterRequester.RequestMandatoryParameter("Insert the author's name: ");
            book.AuthorSurname = _mandatoryParameterRequester.RequestMandatoryParameter("Insert the author's surname: ");
            book.Publisher = _mandatoryParameterRequester.RequestMandatoryParameter("Insert the book's publisher: ");
            return book;
        }
    }
}
