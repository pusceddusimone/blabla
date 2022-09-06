using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BusinessLogic.Library;
using ConsoleApp.Library.Displayer;
using ConsoleApp.Library.Displayer.Classes;
using ConsoleApp.Library.Displayer.Interfaces;
using ConsoleApp.Library.Logger.Interfaces;
using ConsoleApp.Library.Logger.Classes;
using DataAccessLayer.Library;
using Model.Library;
using ConsoleApp.Library.ParametersRequester.Interfaces;
using ConsoleApp.Library.ParametersRequester.Classes;
using ConsoleApp.Library.ObjectComposer.Classes;
using ConsoleApp.Library.OptionManager.Interfaces;
using ConsoleApp.Library.OptionManager.Classes;
using ConsoleApp.Library.ObjectComposer.Interfaces;

namespace ConsoleApp.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            IDisplayer displayer;
            User user;
            ILoginLogger logger = new ConsoleLoginLogger();
            user = logger.Login();

            ILibraryBusinessLogic libraryBusinessLogic = new LibraryBusinessLogic();
            IOptionDisplayer optionDisplayer;
            IMenuValidator menuValidator;
            IOptionManager optionManager;
            IMenuDisplayer menuDisplayer;
            IBookCreator bookCreator;
            IUsernameFilter usernameFilter;
            IMandatoryParameterRequester mandatoryParameterRequester = new ConsoleMandatoryParameterRequester();
            IObjectComposer<Book> bookComposerForUpdate = new ConsoleBookComposerForUpdate();
            IObjectComposer<Book> bookComposerForInsert = new ConsoleBookComposerForInsert();
            IBookFilter bookFilter = new BookFilter(mandatoryParameterRequester, libraryBusinessLogic);
            IReservationFilter reservationFilter;
            IFilterRequester filterRequester;
            IMessageLogger messageLogger = new ConsoleMessageLogger();
            IBookEditor bookEditor = new BookEditor(bookComposerForUpdate, messageLogger);
            IBookDeleter bookDeleter = new BookDeleter(libraryBusinessLogic, new ConsoleBookComposerForReservation(), messageLogger);
            IReservationHistoryManager reservationHistoryManager;
            IBookReserver bookReserver = new BookReserver(new ConsoleBookComposerForReservation()
                , messageLogger, new ConsoleReservationOutcomeDisplayer(), user.UserId);
            IReservationHistoryDisplayer reservationHistoryDisplayer = new ReservationHistoryDisplayer();
            IBookReturner bookReturner = new BookReturner(new ConsoleBookComposerForReservation()
                , messageLogger, new ConsoleReturnOutcomeDisplayer(), user.UserId);

            if (user.Role == User.UserRole.User)
            {
                filterRequester = new FilterRequesterUser(bookFilter, new StatusFilter(),user.UserId);
                reservationFilter = new ConsoleReservationFilter(libraryBusinessLogic, bookFilter, filterRequester);
                reservationHistoryManager = new ReservationHistoryManager(reservationFilter, reservationHistoryDisplayer);
                optionDisplayer  = new ConsoleOptionDisplayerUser();
                menuValidator = new MenuValidatorUser();
                optionManager = new OptionManagerUser(reservationHistoryManager,new ConsoleBookFilterOptionalParameters()
                    , new ConsoleBookViewModelDisplayer(),bookReserver, bookReturner);
            }
            else
            {
                bookCreator = new BookCreator(bookComposerForInsert, messageLogger);
                optionDisplayer = new ConsoleOptionDisplayerAdmin();
                menuValidator = new MenuValidatorAdmin();
                usernameFilter = new UsernameFilter(mandatoryParameterRequester, libraryBusinessLogic);
                filterRequester = new FilterRequesterAdmin(bookFilter, usernameFilter,new StatusFilter());
                reservationFilter = new ConsoleReservationFilter(libraryBusinessLogic, bookFilter, filterRequester);
                reservationHistoryManager = new ReservationHistoryManager(reservationFilter, reservationHistoryDisplayer);
                optionManager = new OptionManagerAdmin(menuValidator,
                    bookCreator, reservationHistoryManager, new ConsoleBookFilterOptionalParameters()
                    , new ConsoleBookViewModelDisplayer(), bookReserver, bookReturner, bookDeleter
, bookEditor);
            }
            menuDisplayer = new MenuDisplayer(optionDisplayer, menuValidator, optionManager);
            displayer = new ConsoleDisplayer(optionDisplayer, menuValidator
                , optionManager, menuDisplayer, reservationHistoryDisplayer);

            displayer.ShowMenu(user);
        }
    }
}
