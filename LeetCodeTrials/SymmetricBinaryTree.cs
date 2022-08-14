namespace LeetCodeTrials
{
    internal class SymmetricBinaryTree
    {
        public SymmetricBinaryTree()
        {
            TreeNode t1 = new TreeNode(3, null, null);
            TreeNode t2 = new TreeNode(4, null, null);
            TreeNode t3 = new TreeNode(4, null, null);
            TreeNode t4 = new TreeNode(3, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(2, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = IsSymmetric(t7);
            Console.WriteLine($"Result: {result}");
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return CheckIfSymmetric(root.left, root.right);
        }

        private bool CheckIfSymmetric(TreeNode left, TreeNode right)
        {
            if ((left != null && right == null)
               || (left == null && right != null)
               || (left != null && right != null && left.val != right.val))
                return false;

            if (left == null && right == null) return true;

            return CheckIfSymmetric(left.left, right.right) && CheckIfSymmetric(left.right, right.left);
        }
    }
}
