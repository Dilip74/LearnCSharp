using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.ReadLine();
        }

        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int depth = 1;
            if(root.left != null && root.right != null)
            {
                int leftDepth = MaxDepth(root.left);
                int rightDepth = MaxDepth(root.right);
                depth += leftDepth > rightDepth ? leftDepth : rightDepth;
            }

            if (root.left != null && root.right == null)
            {
                depth += MaxDepth(root.left);
            }

            if (root.right != null && root.left == null)
            {
                depth += MaxDepth(root.right);
            }

            return depth;
        }
    }

    public class TreeNode
    {
        public int val;
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