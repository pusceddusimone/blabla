using ConsoleApp.Library.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Logger.Classes
{
    public class ConsoleMessageLogger : IMessageLogger
    {
        public void DisplayMessage(string message, bool showHint = true)
        {
            Console.WriteLine(message);
            if (showHint)
                Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
