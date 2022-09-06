using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Logger.Interfaces
{
    public interface IMessageLogger
    {
        void DisplayMessage(string message, bool showHint = true);
    }
}
