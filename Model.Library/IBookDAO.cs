using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Library;

namespace DataAccessLayer.Library
{
    public interface IBookDAO : IGetableById<Book>, IGetAllable<Book>, 
        IUpdatable<Book>, ICreatable<Book>, IDeletable
    { 
    }
}
