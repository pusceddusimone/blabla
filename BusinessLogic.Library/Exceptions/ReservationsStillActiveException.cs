using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.Exceptions
{
    public class ReservationsStillActiveException : InvalidOperationException
    {
        public List<ReservationViewModel> ActiveReservationsInformation { get; private set; }
        public ReservationsStillActiveException(List<ReservationViewModel> activeReservationsInformation)
        {
            ActiveReservationsInformation = activeReservationsInformation;
        }
    }
}
