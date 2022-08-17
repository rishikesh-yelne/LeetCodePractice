namespace LeetCodeTrials
{
    internal class KthSmallestElementBST
    {
        public KthSmallestElementBST()
        {
            TreeNode t1 = new TreeNode(3);
            TreeNode t2 = new TreeNode(8);
            TreeNode t3 = new TreeNode(4);
            TreeNode t4 = new TreeNode(7, t1, t2);
            TreeNode t5 = new TreeNode(5, t3, t4);

            var result = KthSmallest(t5, 2);
            Console.WriteLine($"Result: {result}");
        }

        public int KthSmallest(TreeNode root, int k)
        {
            List<int> inorder = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;

            while (true)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    if (stack.Count == 0) break;

                    node = stack.Pop();
                    inorder.Add(node.val);
                    node = node.right;
                }
            }

            return inorder[k - 1];
        }
    }
}
