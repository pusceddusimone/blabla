using ConsoleApp.Library.Displayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class ConsoleOptionDisplayerUser : IOptionDisplayer
    {
        public void DisplayMenu()
        {
            Console.WriteLine("[1] Find a book");
            Console.WriteLine("[2] Reserve a book");
            Console.WriteLine("[3] Return a book");
            Console.WriteLine("[4] Show booking history");
            Console.WriteLine("[5] Exit");
            Console.Write("Insert a number: ");
        }
    }
}
