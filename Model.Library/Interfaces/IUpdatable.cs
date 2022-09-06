using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public interface IUpdatable<T> where T : IEntity
    {
        void Update(int id, T entity);
    }
}
