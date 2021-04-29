using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class InvertBinaryTree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            RecursiveTree(root);

            return root;
        }

        public void RecursiveTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                return;
            }

            //swap
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;


            RecursiveTree(root.left);

            RecursiveTree(root.right);
        }
    }

    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
