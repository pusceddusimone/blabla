using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.Interfaces
{
    public interface IReservationHistoryGetter
    {
        List<ReservationViewModel> GetReservationHistory(int? bookId, int? userId, ReservationViewModel.ReservationStatus? reservationStatus);
    }
}
