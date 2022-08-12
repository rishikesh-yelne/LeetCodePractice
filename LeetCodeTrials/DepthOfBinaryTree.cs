namespace LeetCodeTrials
{
    internal class DepthOfBinaryTree
    {
        public DepthOfBinaryTree()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = MaxDepth(t7);
            Console.WriteLine($"Result : {result}");
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return GetMaxDepth(root, 1);
        }

        private int GetMaxDepth(TreeNode node, int level)
        {
            int leftDepth = node.left != null ? GetMaxDepth(node.left, level + 1) : level;
            int rightDepth = node.right != null ? GetMaxDepth(node.right, level + 1) : level;

            return Math.Max(leftDepth, rightDepth);
        }
    }
}
