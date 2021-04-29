using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Facade.Interfaces
{
    public interface IAutenticateService
    {
        bool IsValidated(string username, string password);
    }
}
