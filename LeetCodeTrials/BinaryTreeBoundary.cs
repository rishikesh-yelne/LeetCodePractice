namespace LeetCodeTrials
{
    internal class BinaryTreeBoundary
    {
        public BinaryTreeBoundary()
        {
            TreeNode n1 = new TreeNode(3, null, null);
            TreeNode n2 = new TreeNode(4, null, null);
            TreeNode n3 = new TreeNode(2, n1, n2);
            TreeNode n4 = new TreeNode(1, null, n3);

            var result = BoundaryOfBinaryTree(n4);
            Console.WriteLine($"Result: {result.ListToString()}");
        }

        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            if (!IsLeafNode(root)) result.Add(root.val);
            TreeNode left = root.left;
            while (left != null)
            {
                if (!IsLeafNode(left))
                {
                    result.Add(left.val);
                }
                if (left.left != null)
                {
                    left = left.left;
                }
                else
                {
                    left = left.right;
                }
            }
            AddLeaves(result, root);
            Stack<int> stack = new Stack<int>();
            TreeNode right = root.right;
            while (right != null)
            {
                if (!IsLeafNode(right))
                {
                    stack.Push(right.val);
                }
                if (right.right != null)
                {
                    right = right.right;
                }
                else
                {
                    right = right.left;
                }
            }
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result;
        }

        private void AddLeaves(List<int> result, TreeNode root)
        {
            if (IsLeafNode(root)) result.Add(root.val);
            else
            {
                if (root.left != null) AddLeaves(result, root.left);
                if (root.right != null) AddLeaves(result, root.right);
            }
        }

        private bool IsLeafNode(TreeNode node)
        {
            return node.left == null && node.right == null;
        }
    }
}
