namespace LeetCodeTrials
{
    internal class SearchBST
    {
        public SearchBST()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = SearchInBST(t7, 4);
            Console.WriteLine($"Result : {result}");
        }

        public TreeNode SearchInBST(TreeNode root, int val)
        {
            while (root != null)
            {
                if (root.val == val) return root;
                if (root.val > val) root = root.left;
                else root = root.right;
            }
            return null;
        }
    }
}
