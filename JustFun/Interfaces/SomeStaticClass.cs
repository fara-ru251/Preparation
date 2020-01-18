using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Interfaces
{
    public static class SomeStaticClass
    {
        public static void SomeExtMethod(this SomeClass someClass)
        {
            someClass.SomeClassMethod();
            Console.WriteLine("It works");
        }
    }
}
