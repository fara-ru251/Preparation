using JustFun.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Facade
{
    public class LoginFacade
    {
        private IAutenticateService _authenticate;
        private IAuthorizationService _authorize;

        public LoginFacade(IAutenticateService autenticate, IAuthorizationService authorization)
        {
            _authenticate = autenticate;
            _authorize = authorization;
        }


        public bool IsValid(string username, string password)
        {
            //simulation
            if(_authenticate.IsValidated(username, password) && _authorize.IsValidated(username, password))
            {
                return true;
            }

            return false;
        }
    }
}
