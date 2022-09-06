using ConsoleApp.Library.ParametersRequester.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ParametersRequester.Classes
{
    internal class ConsoleMandatoryParameterRequester : IMandatoryParameterRequester
    {
        public string RequestMandatoryParameter(string message)
        {
            int i = 0;
            string parameter;
            bool messageFlag = false;
            do
            {
                if (messageFlag)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1 - i);
                    Console.WriteLine("This parameter is mandatory");
                    i = 1;
                }

                Console.Write(message);
                parameter = Console.ReadLine();
                messageFlag = true;
            } while (parameter == null || parameter.Length == 0);

            return parameter;
        }
    }
}
