namespace LeetCodeTrials
{
    internal class InorderPredecessorSuccessorBST
    {
        public InorderPredecessorSuccessorBST()
        {
            TreeNode t1 = new TreeNode(6);
            TreeNode t2 = new TreeNode(8);
            TreeNode t3 = new TreeNode(4);
            TreeNode t4 = new TreeNode(7, t1, t2);
            TreeNode t5 = new TreeNode(5, t3, t4);

            var p = InorderPredecessor(t5, t4);
            var q = InorderSuccessor(t5, t4);
            Console.WriteLine($"Predecessor Result: {p}");
            Console.WriteLine($"Successor Result: {q}");
        }
        public TreeNode InorderPredecessor(TreeNode root, TreeNode p)
        {
            TreeNode predecessor = null;

            while (root != null)
            {
                if (p.val <= root.val)
                {
                    root = root.left;
                }
                else
                {
                    predecessor = root;
                    root = root.right;
                }
            }

            return predecessor;
        }

        public TreeNode InorderSuccessor(TreeNode root, TreeNode s)
        {
            TreeNode successor = null;

            while (root != null)
            {
                if (s.val >= root.val)
                {
                    root = root.right;
                }
                else
                {
                    successor = root;
                    root = root.left;
                }
            }

            return successor;
        }
    }
}
