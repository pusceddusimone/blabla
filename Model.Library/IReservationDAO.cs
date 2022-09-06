using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Library;

namespace DataAccessLayer.Library
{
    public interface IReservationDAO : IGetAllable<Reservation>, IGetableById<Reservation>
        , ICreatable<Reservation>, IUpdatable<Reservation>, IDeletable
    {
    }
}
