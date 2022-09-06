using ConsoleApp.Library.ObjectComposer.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ObjectComposer.Classes
{
    public class ConsoleBookComposerForUpdate : IObjectComposer<Book>
    {
        public Book RequestObject()
        {
            Book book = new Book();

            Console.Write("Insert the book's id you wish to edit: ");
            int.TryParse(Console.ReadLine(), out int id);
            book.BookId = id;
            Console.Clear();
            Console.WriteLine("Insert new values to update");
            Console.Write("Insert title: ");
            book.Title = Console.ReadLine();
            Console.Write("Insert the author's name: ");
            book.AuthorName = Console.ReadLine();
            Console.Write("Insert the author's surname: ");
            book.AuthorSurname = Console.ReadLine();
            Console.Write("Insert the book's publisher: ");
            book.Publisher = Console.ReadLine();
            return book;
        }
    }
}
