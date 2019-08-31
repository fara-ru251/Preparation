using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class Node
    {
        private int Number { get; set; }
        public Node RightChild;
        public Node LeftChild;

        public Node(int value)
        {
            Number = value;
            RightChild = null;
            LeftChild = null;
        }

        public void InsertData(ref Node node, int data)
        {
            if (node == null)
            {
                node = new Node(data);
            }
            else if (node.Number < data)
            {
                InsertData(ref node.RightChild, data);
            }
            else if (node.Number > data)
            {
                InsertData(ref node.LeftChild, data);
            }
        }

        public bool Search(Node node, int s)
        {
            if(node == null)
            {
                return false;
            }
            if (node.Number == s)
            {
                return true;
            }
            if (node.Number < s)
            {
                return Search(node.RightChild, s);
            }
            if (node.Number > s)
            {
                return Search(node.LeftChild, s);
            }
            return false;
        }

        public void Display(Node node)
        {
            if (node == null)
            {
                return;
            }
            Display(node.LeftChild);
            Console.Write(" " + node.Number);
            Display(node.RightChild);
        }
    }
}
