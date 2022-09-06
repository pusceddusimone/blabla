using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Library.Interfaces
{
    public interface IIsUpdatedBookDuplicateChecker
    {
        bool IsUpdatedBookDuplicate(int idOfBookToUpdate, Book newBook);
    }
}
