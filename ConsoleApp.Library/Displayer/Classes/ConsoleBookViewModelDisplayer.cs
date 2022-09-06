using ConsoleApp.Library.Displayer.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class ConsoleBookViewModelDisplayer : IBookViewModelDisplayer
    {
        public void DisplayBooksView(List<BookViewModel> books)
        {
            Console.Clear();
            if (books.Count == 0)
                Console.WriteLine("No books found");

            foreach (BookViewModel book in books)
            {
                Console.WriteLine("*****************************");
                Console.WriteLine($"Book's title: {book.Book.Title}");
                Console.WriteLine($"Book's author: {book.Book.AuthorName} {book.Book.AuthorSurname}");
                Console.WriteLine($"Book's publisher: {book.Book.Publisher}");
                Console.WriteLine($"Availability: {book.BookAvaiability}");
                Console.WriteLine($"date on which the book will be available: {book.AvaiabilityDate}");
            }
            Console.ReadKey();
        }
    }
}
