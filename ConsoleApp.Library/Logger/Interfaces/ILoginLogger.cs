using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Library;

namespace ConsoleApp.Library.Logger.Interfaces
{
    public interface ILoginLogger
    {
        User Login();
    }
}
