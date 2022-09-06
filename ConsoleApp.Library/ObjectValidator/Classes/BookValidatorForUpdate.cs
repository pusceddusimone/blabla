using ConsoleApp.Library.ObjectValidator.Interfaces;
using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ObjectValidator.Classes
{
    public class BookValidatorForUpdate : IObjectValidator<Book>
    {
        public bool IsObjectValid(Book entity)
        {
            return entity.BookId >= 0;
        }
    }
}
