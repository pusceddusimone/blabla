using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Library.Interfaces;
using DataAccessLayer.Library;
using Model.Library;

namespace BusinessLogic.Library
{
    public interface ILibraryBusinessLogic : IBookGettableByProperties, IBookAdder, IBookSearcher
        ,IBookUpdater, IReservationHistoryGetter, IUserGetterByUsername, IBookSearcherWithAvailabilityInfo
        , ILogger, IBookDeleter, IBookReserver, IBookReturner
    {
    }
}
