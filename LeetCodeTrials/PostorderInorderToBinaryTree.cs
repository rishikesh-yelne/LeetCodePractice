namespace LeetCodeTrials
{
    internal class PostorderInorderToBinaryTree
    {
        int postorderIndex;
        Dictionary<int, int> inorderMapping = new Dictionary<int, int>();

        public PostorderInorderToBinaryTree()
        {
            var result = BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
            Console.WriteLine($"Result : {result}");
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            postorderIndex = postorder.Length - 1;
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderMapping.Add(inorder[i], i);
            }

            return ArrayToTree(postorder, 0, postorder.Length - 1);
        }

        private TreeNode ArrayToTree(int[] postorder, int start, int end)
        {
            if (start > end) return null;

            int rootVal = postorder[postorderIndex];
            postorderIndex--;
            TreeNode rootNode = new TreeNode(rootVal);

            rootNode.right = ArrayToTree(postorder, inorderMapping[rootVal] + 1, end);
            rootNode.left = ArrayToTree(postorder, start, inorderMapping[rootVal] - 1);
            return rootNode;
        }
    }
}
