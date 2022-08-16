namespace LeetCodeTrials
{
    internal class ValidBST
    {
        public ValidBST()
        {
            TreeNode t1 = new TreeNode(3);
            TreeNode t2 = new TreeNode(8);
            TreeNode t3 = new TreeNode(4);
            TreeNode t4 = new TreeNode(7, t1, t2);
            TreeNode t5 = new TreeNode(5, t3, t4);

            var result = IsValidBST(t5);
            Console.WriteLine($"Result : {result}");
        }
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            return CheckIfValidBST(root, long.MinValue, long.MaxValue);
        }

        private bool CheckIfValidBST(TreeNode node, long lowerBound, long upperBound)
        {
            if (node.val > lowerBound && node.val < upperBound)
            {
                bool leftTree = true, rightTree = true;
                if (node.left != null) leftTree = CheckIfValidBST(node.left, lowerBound, node.val);
                if (node.right != null) rightTree = CheckIfValidBST(node.right, node.val, upperBound);
                return leftTree && rightTree;
            }
            else return false;
        }
    }
}
