﻿namespace LeetCodeTrials
{
    internal class ZigZagTraversalBinaryTree
    {
        public ZigZagTraversalBinaryTree()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            var result = ZigzagLevelOrder(t7);
            Console.WriteLine($"Result : {result}");
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root == null) return result;
            queue.Enqueue(root);
            bool flag = true;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<int> level = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    level.Add(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                if (!flag) level.Reverse();
                result.Add(level);
                flag = !flag;
            }

            return result;
        }
    }
}
