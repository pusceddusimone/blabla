using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public enum Availability { Available, Unavailable };

        public Availability BookAvaiability { get; set; }

        public DateTime AvaiabilityDate { get; set; }
        public BookViewModel()
        {

        }
        public BookViewModel(Book book, Availability bookAvaiability, DateTime avaiabilityDate)
        {
            Book = book;
            BookAvaiability = bookAvaiability;
            AvaiabilityDate = avaiabilityDate;
        }
    }
}
