namespace LeetCodeTrials
{
    internal class MaxPathSumBinaryTree
    {
        int Max = int.MinValue;

        public MaxPathSumBinaryTree()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = MaxPathSum(t7);
            Console.WriteLine($"Result : {result}");
        }

        public int MaxPathSum(TreeNode root)
        {
            CalcMaxPathSum(root);
            return Max;
        }

        private int CalcMaxPathSum(TreeNode node)
        {
            if (node == null) return 0;

            int leftSum = Math.Max(0, CalcMaxPathSum(node.left));
            int rightSum = Math.Max(0, CalcMaxPathSum(node.right));

            Max = Math.Max(Max, leftSum + rightSum + node.val);

            return Math.Max(leftSum, rightSum) + node.val;
        }
    }
}
