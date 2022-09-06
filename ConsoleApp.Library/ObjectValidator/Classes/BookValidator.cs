using ConsoleApp.Library.ObjectValidator.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ObjectValidator.Classes
{
    internal class BookValidator : IObjectValidator<Book>
    {
        public bool IsObjectValid(Book entity)
        {
            return
                entity.Title != null &&
                entity.Publisher != null &&
                entity.Quantity >= 0 &&
                entity.AuthorName != null &&
                entity.AuthorSurname != null;
        }
    }
}
