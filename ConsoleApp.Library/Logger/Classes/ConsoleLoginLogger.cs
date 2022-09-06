using BusinessLogic.Library;
using ConsoleApp.Library.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Library;

namespace ConsoleApp.Library.Logger.Classes
{
    public class ConsoleLoginLogger : ILoginLogger
    {
        public User Login()
        {
            LibraryBusinessLogic libraryBusinessLogic = new LibraryBusinessLogic();
            User user;
            char choiceRepeatLogin;
            Console.WriteLine("************** LOGIN **************");
            do
            {
                choiceRepeatLogin = 'N';
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                user = libraryBusinessLogic.Login(username, password);
                if (user == null)
                {
                    Console.Write("incorrect Login. Do you wish to try again? Y/N");
                    choiceRepeatLogin = Console.ReadLine()[0];
                }
            } while (choiceRepeatLogin.ToString().ToUpper() == "Y");

            if (user == null)
                Environment.Exit(0);
            return user;
        }
    }
}
