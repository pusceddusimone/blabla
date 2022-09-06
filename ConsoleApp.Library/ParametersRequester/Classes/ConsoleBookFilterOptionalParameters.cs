using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ParametersRequester.Classes
{
    public class ConsoleBookFilterOptionalParameters : IBookFilterOptionalParameters
    {
        public Book FilterForBook()
        {
            string input;
            Book book = new Book();
            Console.Clear();
            Console.WriteLine("Leave field empty if you don't want to apply that filter");
            Console.Write("Insert book's title: ");
            input = Console.ReadLine();
            book.Title = input.Length > 0 ? input : null;
            Console.Write("Insert the author's name: ");
            input = Console.ReadLine();
            book.AuthorName = input.Length > 0 ? input : null;
            Console.Write("Insert the author's surname: ");
            input = Console.ReadLine();
            book.AuthorSurname = input.Length > 0 ? input : null;
            Console.Write("Insert the book's publisher: ");
            input = Console.ReadLine();
            book.Publisher = input.Length > 0 ? input : null;


            book.Quantity = -1; //Don't filter for these two
            book.BookId = -1;

            return book;
        }
    }
}
