namespace LeetCodeTrials
{
    internal class CheckIfSameBinaryTree
    {
        public CheckIfSameBinaryTree()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            TreeNode t8 = new TreeNode(4, null, null);
            TreeNode t9 = new TreeNode(5, null, null);
            TreeNode t10 = new TreeNode(6, null, null);
            TreeNode t11 = new TreeNode(7, null, null);
            TreeNode t12 = new TreeNode(2, t8, t9);
            TreeNode t13 = new TreeNode(3, t10, t11);
            TreeNode t14 = new TreeNode(1, t12, t13);

            var result = IsSameTree(t7, t14);
            Console.WriteLine($"Result: {result}");
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            return CheckIfIdentical(p, q);
        }

        private bool CheckIfIdentical(TreeNode p, TreeNode q)
        {
            if (p != null && q != null)
            {
                bool leftSubTree = CheckIfIdentical(p.left, q.left);
                bool rightSubTree = CheckIfIdentical(p.right, q.right);
                return (p.val == q.val && leftSubTree && rightSubTree);
            }
            else if (p == null && q == null)
            {
                return true;
            }
            else return false;
        }
    }
}
