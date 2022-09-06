using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Library.Interfaces;
using DataAccessLayer.Library;
using Model.Library;

namespace BusinessLogic.Library.Classes
{
    public class FirstIndexFinder : IFirstIndexFinder
    {
        Repository _repository;
        public FirstIndexFinder(Repository repository)
        {
            _repository = repository;
        }
        public int FindFirstAvaibleIndex()
        {
            List<Book> books = _repository.GetAllBooks();
            int i;
            for (i = 0; i < books.Count; i++)
            {
                if (books.Where(b => b.BookId == i).Count() == 0)
                    return i;
            }
            return i;
        }
    }
}
