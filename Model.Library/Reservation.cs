using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public class Reservation : IEntity
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

        DateTime _startDate;
        public DateTime StartDate {
            get => _startDate;
            set
            {
                if (EndDate == default)
                    EndDate = value.AddDays(30);

                if (value <= EndDate)
                    _startDate = value;
            }
        }
        DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if(value >= StartDate)
                    _endDate = value;
            }
        }

        public Reservation(int id, int userId, int bookId, 
            DateTime startDate)
        {
            ReservationId = id;
            UserId = userId;
            BookId = bookId;
            StartDate = startDate;
            EndDate = StartDate.AddDays(30);
        }
        public Reservation() { }
    }
}
