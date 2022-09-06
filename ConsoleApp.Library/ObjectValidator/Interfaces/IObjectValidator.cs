using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ObjectValidator.Interfaces
{
    public interface IObjectValidator<T> where T : IEntity
    {
        bool IsObjectValid(T entity);
    }
}
