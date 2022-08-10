namespace LeetCodeTrials
{
    internal class SideViewBinaryTree
    {
        public SideViewBinaryTree()
        {
            TreeNode t1 = new TreeNode(8, null, null);
            TreeNode t2 = new TreeNode(4, null, t1);
            TreeNode t3 = new TreeNode(5, null, null);
            TreeNode t4 = new TreeNode(6, null, null);
            TreeNode t5 = new TreeNode(7, null, null);
            TreeNode t6 = new TreeNode(2, t2, t3);
            TreeNode t7 = new TreeNode(3, t4, t5);
            TreeNode t8 = new TreeNode(1, t6, t7);

            var left = LeftView(t8); Console.WriteLine(left.ListToString());
            var right = RightView(t8); Console.WriteLine(right.ListToString());
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public List<int> LeftView(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            GenerateLeftView(root, stack, 0);

            while (stack.Count > 0)
            {
                result.Add(stack.Pop().val);
            }

            result.Reverse();
            return result;
        }

        public List<int> RightView(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            GenerateRightView(root, stack, 0);

            while (stack.Count > 0)
            {
                result.Add(stack.Pop().val);
            }

            result.Reverse();
            return result;
        }

        private void GenerateLeftView(TreeNode currentNode, Stack<TreeNode> stack, int level)
        {
            if (currentNode == null) return;

            if (level == stack.Count) stack.Push(currentNode);

            GenerateLeftView(currentNode.left, stack, level + 1);
            GenerateLeftView(currentNode.right, stack, level + 1);
        }

        private void GenerateRightView(TreeNode currentNode, Stack<TreeNode> stack, int level)
        {
            if (currentNode == null) return;

            if (level == stack.Count) stack.Push(currentNode);

            GenerateRightView(currentNode.right, stack, level + 1);
            GenerateRightView(currentNode.left, stack, level + 1);
        }
    }
}
