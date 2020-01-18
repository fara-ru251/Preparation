using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class BinarySearchTree
    {
        Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        internal class Node
        {
            public int key { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int item)
            {
                this.key = item;
                this.left = this.right = null;
            }
        }


        public void deleteKey(int key)
        {
            root = deleteNode(root, key);
        }

        Node deleteNode(Node root, int key)
        {
            if (root == null)
            {
                return null;
            }


            if (key < root.key)
            {
                root.left = deleteNode(root.left, key);
            }
            else if (key > root.key)
            {
                root.right = deleteNode(root.right, key);
            }
            else
            {
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }

                root.key = minValue(root.right);

                root.right = deleteNode(root.right, root.key);

            }

            return root;
        }
     
        private int minValue(Node root)
        {
            int minv = root.key;

            while (root.left != null)
            {
                minv = root.left.key;
                root = root.left;
            }

            return minv;
        }


        public void insert(int key)
        {
            root = insertRec(root, key);
        }


        Node insertRec(Node root, int key)
        {

            /* If the tree is empty, return a new node */
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            /* Otherwise, recur down the tree */
            if (key < root.key)
            {
                root.left = insertRec(root.left, key);
            }
            else if (key > root.key)
            {
                root.right = insertRec(root.right, key);
            }

            /* return the (unchanged) node pointer */
            return root;
        }


        // A utility function to do inorder traversal of BST  
        private void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Console.Write(root.key + " ");
                inorderRec(root.right);
            }
        }


        public void inorder()
        {
            inorderRec(root);
        }

    }
}
