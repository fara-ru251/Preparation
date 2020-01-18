using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Interfaces
{
    public class SomeInterfaceImplementation : ISomeInterface
    {
        public SomeClass GetSomeClass()
        {
            return new SomeClass();
        }
    }
}
