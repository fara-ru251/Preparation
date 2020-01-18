using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.TestInterfacesApp
{
    public class Employee
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Position { get; private set; }
        public int BeginDate { get; private set; }

        public Employee(int _ID, string _firstName, string _lastName, string _position, int _beginDate)
        {
            ID = _ID;
            FirstName = _firstName;
            LastName = _lastName;
            Position = _position;
            BeginDate = _beginDate;
        }


    }
}
