﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Facade.Interfaces
{
    public interface IAuthorizationService
    {
        bool IsValidated(string username, string password);
    }
}
