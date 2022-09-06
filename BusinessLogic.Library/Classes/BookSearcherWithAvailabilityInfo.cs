using BusinessLogic.Library.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.Classes
{
    public class BookSearcherWithAvailabilityInfo : IBookSearcherWithAvailabilityInfo
    {
        IBookSearcher _bookSearcher;
        IReservationHistoryGetter _reservationHistoryGetter;
        public BookSearcherWithAvailabilityInfo(IBookSearcher bookSearcher, IReservationHistoryGetter reservationHistoryGetter)
        {
            _bookSearcher = bookSearcher;
            _reservationHistoryGetter = reservationHistoryGetter;
        }

        public List<BookViewModel> SearchBookWithAvailabilityInfos(Book book)
        {
            List<Book> books = _bookSearcher.SearchBook(book);
            List<BookViewModel> viewBooks = new List<BookViewModel>();
            BookViewModel.Availability bookAvaiability;
            DateTime firstAvaiabilityDate;
            foreach (Book loopBook in books)
            {
                List<ReservationViewModel> activeReservations = _reservationHistoryGetter.GetReservationHistory(loopBook.BookId, null, null)
                    .Where(r => r.Status == ReservationViewModel.ReservationStatus.Active).ToList();
                bookAvaiability = loopBook.Quantity > activeReservations.Count ?
                    BookViewModel.Availability.Available : BookViewModel.Availability.Unavailable;
                if (activeReservations.Count > 0)
                    firstAvaiabilityDate = activeReservations.Min(r => r.EndDate);
                else
                    firstAvaiabilityDate = DateTime.Now;
                viewBooks.Add(new BookViewModel(loopBook, bookAvaiability, firstAvaiabilityDate));
            }
            return viewBooks;
        }
    }
}
