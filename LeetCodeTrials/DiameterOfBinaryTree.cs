namespace LeetCodeTrials
{
    internal class DiameterOfBinaryTree
    {
        public DiameterOfBinaryTree()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = MaxDiameterOfBinaryTree(t7);
            Console.WriteLine($"Result : {result}");
        }

        public int MaxDiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            int diameter = 0;
            GetMaxDiameter(root, ref diameter);
            return diameter;
        }

        private int GetMaxDiameter(TreeNode node, ref int diameter)
        {
            if (node == null) return 0;
            int left = GetMaxDiameter(node.left, ref diameter);
            int right = GetMaxDiameter(node.right, ref diameter);

            diameter = Math.Max(left + right, diameter);

            return 1 + Math.Max(left, right);
        }
    }
}
