using BusinessLogic.Library;
using ConsoleApp.Library.ParametersRequester.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ParametersRequester.Classes
{
    public class UsernameFilter : IUsernameFilter
    {
        IMandatoryParameterRequester _mandatoryParameterRequester;
        ILibraryBusinessLogic _libraryBusinessLogic;
        public UsernameFilter(IMandatoryParameterRequester mandatoryParameterRequester
            , ILibraryBusinessLogic libraryBusinessLogic)
        {
            _mandatoryParameterRequester = mandatoryParameterRequester;
            _libraryBusinessLogic = libraryBusinessLogic;
        }
        public int? FilterForUsername()
        {
            User foundUser;
            string username = "";
            bool userNotFoundFlag = false;
            do
            {
                if (userNotFoundFlag)
                {
                    Console.Clear();
                    Console.WriteLine($"User with username \"{username}\" not found," +
                        $"do you wish to try again?[Y/N]");
                    if (Console.ReadLine().ToLower()[0] != 'y')
                        return null;
                }
                username = _mandatoryParameterRequester.RequestMandatoryParameter("Insert username: ");
                foundUser = _libraryBusinessLogic.GetUserByUserName(username);
                userNotFoundFlag = true;
            } while (foundUser == null);

            return foundUser.UserId;
        }
    }
}
