using ConsoleApp.Library.Displayer.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Displayer.Classes
{
    public class MenuDisplayer : IMenuDisplayer
    {
        IOptionDisplayer _optionDisplayer;
        IMenuValidator _menuValidator;
        IOptionManager _optionManager;
        public MenuDisplayer(IOptionDisplayer optionDisplayer, 
            IMenuValidator menuValidator, IOptionManager optionManager)
        {
            _optionDisplayer = optionDisplayer;
            _menuValidator = menuValidator;
            _optionManager = optionManager;
        }
        public void ShowMenu(User user)
        {
            string choiceInMenu;
            int returnCode = 1;
            bool menuFlag = false;
            Console.WriteLine($"Welcome {user.Username}");
            do
            {
                Console.Clear();
                if (menuFlag)
                    Console.WriteLine("Select a vaid option...");

                _optionDisplayer.DisplayMenu();
                choiceInMenu = Console.ReadLine();
                menuFlag = true;
                if (_menuValidator.IsMenuOptionValid(choiceInMenu))
                    returnCode = _optionManager.ManageOptionChosen(int.Parse(choiceInMenu));
            } while (true && returnCode == 1);
        }
    }
}
