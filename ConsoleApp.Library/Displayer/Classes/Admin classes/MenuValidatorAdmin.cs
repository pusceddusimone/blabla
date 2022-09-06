using ConsoleApp.Library.Displayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class MenuValidatorAdmin : IMenuValidator
    {
        public bool IsMenuOptionValid(string option)
        {
            int.TryParse(option, out int intOption);
            return intOption >= 1 && intOption <= 8;
        }
    }
}
