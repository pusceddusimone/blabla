using ConsoleApp.Library.ObjectComposer.Interfaces;
using ConsoleApp.Library.ParametersRequester.Classes;
using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ObjectComposer.Classes
{
    public class ConsoleBookComposerForReservation : IObjectComposer<Book>
    {
        IMandatoryParameterRequester _mandatoryParameterRequester;
        public ConsoleBookComposerForReservation()
        {
            _mandatoryParameterRequester = new ConsoleMandatoryParameterRequester();
        }
        public Book RequestObject()
        {
            Book book = new Book();

            book.Title = _mandatoryParameterRequester.RequestMandatoryParameter("Insert title: ");
            book.AuthorName = _mandatoryParameterRequester.RequestMandatoryParameter("Insert the author's name: ");
            book.AuthorSurname = _mandatoryParameterRequester.RequestMandatoryParameter("Insert the author's surname: ");
            book.Publisher = _mandatoryParameterRequester.RequestMandatoryParameter("Insert the book's publisher: ");
            book.Quantity = -1;
            return book;
        }
    }
}
