namespace LeetCodeTrials
{
    internal class PreorderInorderToBinaryTree
    {
        int preorderIndex;
        Dictionary<int, int> inorderMapping = new Dictionary<int, int>();

        public PreorderInorderToBinaryTree()
        {
            var result = BuildTree(new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });
            Console.WriteLine($"Result : {result}");
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            preorderIndex = 0;
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderMapping.Add(inorder[i], i);
            }

            return ArrayToTree(preorder, 0, preorder.Length - 1);
        }

        private TreeNode ArrayToTree(int[] preorder, int start, int end)
        {
            if (start > end) return null;

            int rootVal = preorder[preorderIndex];
            preorderIndex++;
            TreeNode rootNode = new TreeNode(rootVal);

            rootNode.left = ArrayToTree(preorder, start, inorderMapping[rootVal] - 1);
            rootNode.right = ArrayToTree(preorder, inorderMapping[rootVal] + 1, end);
            return rootNode;
        }
    }
}
