using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    class BinaryTree
    {
        private Node root;
        private int count;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }
        public bool isEmpty()
        {
            return null == root;
        }
        public void Insert(int n)
        {
            if (isEmpty())
            {
                root = new Node(n);
            }
            else
            {
                root.InsertData(ref root, n);
            }
            count++;
        }
    }
}
