using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Library
{
    public interface IUserDAO : IGetAllable<User>, IGetableById<User>
    {
    }
}
