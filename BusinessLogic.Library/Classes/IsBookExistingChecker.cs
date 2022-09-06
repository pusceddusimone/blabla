using BusinessLogic.Library.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.Classes
{
    public class IsBookExistingChecker : IIsBookExistingChecker
    {
        IBookSearcher _bookSearcher;
        public IsBookExistingChecker(IBookSearcher bookSearcher)
        {
            _bookSearcher = bookSearcher;
        }

        public bool IsBookExisting(int id)
        {
            return _bookSearcher.SearchBook(new Book
            {
                BookId = id,
                Quantity = -1
            }).Any();
        }
    }
}
