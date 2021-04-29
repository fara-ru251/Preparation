using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class IncreasingOrderSearchTree
    {
        TreeNode head = null;
        TreeNode prev = null;

        /// <summary>
        /// BST here is Binary Search Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            IncreasingBST(root.left);
            if (prev != null)
            {
                root.left = null; // we no  longer needs the left  side of the node, so set it to null
                prev.right = root;
            }

            if (head == null)
            {
                head = root; // record the most left node as it will be our root
            }

            prev = root; //keep track of the prev node
            IncreasingBST(root.right);
            return head;
        }

        public void TraverseTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine("Element: {0}", root.val);

            TraverseTree(root.left);

            TraverseTree(root.right);
        }

        #region Nested Types
        //public class TreeNode
        //{
        //    public int val;
        //    public TreeNode left;
        //    public TreeNode right;
        //    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        //    {
        //        this.val = val;
        //        this.left = left;
        //        this.right = right;
        //    }
        //}
        #endregion
    }
}
