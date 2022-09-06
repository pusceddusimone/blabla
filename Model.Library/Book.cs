using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public class Book : IEntity
    {
        public int BookId { get; set; }
		public string Title { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
		public string Publisher { get; set; }
        public int Quantity { get; set; } = 1;

		public Book(int bookId, string title, string authorName,
            string authorSurname, string publisher, int quantity)
        {
            BookId = bookId;
            Title = title;
            AuthorName = authorName;
            AuthorSurname = authorSurname;
            Publisher = publisher;
            Quantity = quantity;
        }

        public Book() { }
    }
}
