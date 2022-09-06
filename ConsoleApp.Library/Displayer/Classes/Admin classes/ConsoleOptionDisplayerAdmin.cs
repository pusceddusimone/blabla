using ConsoleApp.Library.Displayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class ConsoleOptionDisplayerAdmin : IOptionDisplayer
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Select the operation that you wish to execute");
            Console.WriteLine("[1] Create a book");
            Console.WriteLine("[2] Edit a book");
            Console.WriteLine("[3] Delete a book");
            Console.WriteLine("[4] Find a book");
            Console.WriteLine("[5] Reserve a book");
            Console.WriteLine("[6] Return a book");
            Console.WriteLine("[7] Show booking history");
            Console.WriteLine("[8] Exit");
            Console.Write("Insert a number: ");
        }
    }
}
