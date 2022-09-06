using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public interface ICreatable<T> where T : IEntity
    {
        void Create(T entity);
    }
}
