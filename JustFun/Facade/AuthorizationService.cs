using JustFun.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Facade
{
    internal class AuthorizationService : IAuthorizationService
    {
        private const string _username = "Bekarys";

        public bool IsValidated(string username, string password)
        {
            if (_username == username)
            {
                return true;
            }

            return false;
        }
    }
}
