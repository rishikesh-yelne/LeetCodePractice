namespace LeetCodeTrials
{
    //public class TreeNode
    //{
    //    public int val;
    //    public TreeNode left;
    //    public TreeNode right;
    //    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    //    {
    //        this.val = val;
    //        this.left = left;
    //        this.right = right;
    //    }
    //}

    internal class FindPathToNode
    {
        public FindPathToNode()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = PathToNode(t7, 5);
            Console.WriteLine($"Result : {result.ListToString()}");
        }

        public List<int> PathToNode(TreeNode A, int B)
        {
            if (A != null && A.val == B) return new List<int>() { A.val };
            List<int> result = new List<int>();
            bool res = FindPath(A, B, result);
            return res ? result : new List<int>();
        }

        private bool FindPath(TreeNode A, int B, List<int> result)
        {
            if (A != null && A.val == B)
            {
                result.Insert(0, A.val);
                return true;
            }
            else
            {
                if (A.left != null)
                {
                    bool nodeFound = FindPath(A.left, B, result);
                    if (nodeFound)
                    {
                        result.Insert(0, A.val);
                        return true;
                    }
                }

                if (A.right != null)
                {
                    bool nodeFound = FindPath(A.right, B, result);
                    if (nodeFound)
                    {
                        result.Insert(0, A.val);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
