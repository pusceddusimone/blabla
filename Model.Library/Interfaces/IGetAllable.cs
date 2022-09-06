﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Library
{
    public interface IGetAllable<T> where T: IEntity
    {
        List<T> Read();
    }
}
