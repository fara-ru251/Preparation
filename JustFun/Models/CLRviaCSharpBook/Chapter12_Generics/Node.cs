using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook.Chapter12_Generics
{
    public delegate TReturn CallMe<TReturn, TKey, TValue>(TKey key, TValue value);
    


    internal class Node
    {
        protected Node _next;

        public delegate TResult Func<in T, out TResult>(T arg);
        public Node(Node next)
        {
            this._next = next;

            Func<Object, ArgumentException> func = null;
            Func<String, Exception> func1 = func;

        }

        private static void Swap<T>(ref T o1, ref T o2)
        {
            T temp = o1;
            o1 = o2;
            o2 = temp;
        }
    }

    internal sealed class TypedNode<T> : Node
    {
        public T _data;
        public TypedNode(T data) : this(data, null)
        {
        }

        public TypedNode(T data, Node next) : base(next)
        {
            this._data = data;
        }
        public override string ToString()
        {
            return _data.ToString() + (_next != null ? _next.ToString() : string.Empty);
        }
    }
}
