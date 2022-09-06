﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public interface IGetableById<T> where T: IEntity
    {
        T GetElementById(int id);
    }
}
