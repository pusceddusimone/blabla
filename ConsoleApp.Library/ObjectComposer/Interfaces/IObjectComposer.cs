using Model.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.ObjectComposer.Interfaces
{
    public interface IObjectComposer<T> where T : IEntity
    {
        T RequestObject();
    }
}
