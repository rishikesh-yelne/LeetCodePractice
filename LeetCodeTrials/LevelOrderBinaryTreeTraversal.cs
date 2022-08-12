namespace LeetCodeTrials
{
    internal class LevelOrderBinaryTreeTraversal
    {
        public LevelOrderBinaryTreeTraversal()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = LevelOrder(t7);
            Console.WriteLine($"Result : {result}");
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            List<int> level;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                level = new List<int>();
                while (levelSize > 0)
                {
                    TreeNode node = queue.Dequeue();
                    level.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                    levelSize--;
                }
                result.Add(level);
            }
            return result;
        }
    }
}
