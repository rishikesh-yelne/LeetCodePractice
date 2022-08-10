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

    internal class BinaryTreeWidth
    {
        public BinaryTreeWidth()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = WidthOfBinaryTree(t7);
            Console.WriteLine($"Result : {result}");
        }

        public int WidthOfBinaryTree(TreeNode root)
        {
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 0));
            int max = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                int left = 0, right = 0;

                for (int i = 0; i < size; i++)
                {
                    Tuple<TreeNode, int> item = queue.Dequeue();
                    if (i == 0)
                    {
                        left = item.Item2;
                        right = item.Item2;
                    }
                    else if (i == size - 1)
                    {
                        right = item.Item2;
                    }

                    if (item.Item1.left != null) queue.Enqueue(new Tuple<TreeNode, int>(item.Item1.left, 2 * item.Item2 + 1));
                    if (item.Item1.right != null) queue.Enqueue(new Tuple<TreeNode, int>(item.Item1.right, 2 * item.Item2 + 2));
                }

                max = Math.Max(max, right - left + 1);
            }

            return max;
        }
    }
}
