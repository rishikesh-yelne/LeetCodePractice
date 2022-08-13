namespace LeetCodeTrials
{
    internal class LowestCommonAncestorBinaryTree
    {
        TreeNode result;

        public LowestCommonAncestorBinaryTree()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            TreeNode answer = LowestCommonAncestor(t7, t5, t1);
            Console.WriteLine($"Solution: {answer}");
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            FindLowestAncestor(root, p, q);
            return result;
        }

        private bool FindLowestAncestor(TreeNode currentNode, TreeNode p, TreeNode q)
        {
            if (currentNode == null) return false;

            int leftTree = FindLowestAncestor(currentNode.left, p, q) ? 1 : 0;
            int rightTree = FindLowestAncestor(currentNode.right, p, q) ? 1 : 0;

            int intermediate = currentNode == p || currentNode == q ? 1 : 0;

            if (leftTree + rightTree + intermediate >= 2) result = currentNode;

            return (leftTree + rightTree + intermediate > 0);
        }
    }
}
