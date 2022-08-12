namespace LeetCodeTrials
{
    internal class CheckIfBalancedBinaryTree
    {
        public CheckIfBalancedBinaryTree()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = IsBalanced(t7);
            Console.WriteLine($"Result : {result}");
        }

        public bool IsBalanced(TreeNode root)
        {
            return CheckIfBalanced(root) != -1;
        }

        private int CheckIfBalanced(TreeNode node)
        {
            if (node == null) return 0;

            int leftDepth = CheckIfBalanced(node.left);
            if (leftDepth == -1) return -1;
            int rightDepth = CheckIfBalanced(node.right);
            if (rightDepth == -1) return -1;

            if (Math.Abs(leftDepth - rightDepth) > 1) return -1;
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
