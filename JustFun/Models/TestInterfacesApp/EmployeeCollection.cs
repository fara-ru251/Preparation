using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.TestInterfacesApp
{
    public class EmployeeCollection : IList<Employee>
    {
        private Employee[] _employees { get; set; }

        public int Count => _employees.Length;

        public bool IsReadOnly => true;

        public Employee this[int index]
        {
            get
            {
                return _employees[index];
            }
            set => throw new NotSupportedException();
        }

        public EmployeeCollection(Employee[] employees)
        {
            _employees = employees;
        }

        public IEnumerator<Employee> Filter(string position)
        {
            foreach (var emp in _employees)
            {
                if (emp.Position.ToLower() == position.ToLower())
                {
                    yield return emp;
                }
            }
        }


        public int IndexOf(Employee item)
        {
            for (int i = 0; i < _employees.Length; i++)
            {
                if (item == _employees[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, Employee item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public void Add(Employee item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(Employee item)
        {
            bool result = false;

            for (int i = 0; i < _employees.Length; i++)
            {
                if (item == _employees[i])
                {
                    result = true;
                }
            }
            return result;
        }

        public void CopyTo(Employee[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        public bool Remove(Employee item)
        {
            throw new NotSupportedException();
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            foreach (Employee emp in _employees)
            {
                yield return emp;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
