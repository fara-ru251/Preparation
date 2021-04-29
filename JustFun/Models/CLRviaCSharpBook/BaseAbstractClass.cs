using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook
{
    public abstract class BaseAbstractClass
    {
        private readonly string _name;

        protected string GetName
        {
            get { return this._name; }
        }

        public BaseAbstractClass(string name)
        {
            this._name = name;
        }


        public abstract void AbstractMethod();
    }

    public class DerivedClass : BaseAbstractClass
    {
        private Random _random;
        private Int32 _age;
        public Int32 Counter { get { return _random.Next(0, 100); } }

        public Int32 GetAge()
        {
            return _age;
        }


        //property equals to method (may be calculated at runtime "read-only property")
        public void SetAge(Int32 value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", value.ToString(), "The value must be greater than or equal to 0");
            }

            _age = value;
        }




        public DerivedClass() : base("Fara")
        {
            this._random = new Random();

            var _nestedType = new NestedType();
        }

        public override void AbstractMethod()
        {
            Console.WriteLine(base.GetName);
        }


        class NestedType
        {
            private int _privateField;
            public int NestedProp { get; set; }

            public NestedType()
            {
                _privateField = 0;
                var derivedType = new DerivedClass();
                derivedType._age = 10;
            }
        }
    }
}
