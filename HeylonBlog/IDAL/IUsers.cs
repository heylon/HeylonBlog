﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDAL
{
    public interface IUsers
    {
        bool Login(string username, string password);
    }
}
