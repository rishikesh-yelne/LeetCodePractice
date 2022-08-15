namespace LeetCodeTrials
{
    internal class BSTFromPreorder
    {
        int CurrentIndex = 0;
        public BSTFromPreorder()
        {
            var result = BstFromPreorder(new int[] { 8, 5, 1, 7, 10, 12 });
            Console.WriteLine($"Result : {result}");
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            return GenerateBST(preorder, int.MaxValue);
        }

        private TreeNode GenerateBST(int[] preorder, int bound)
        {
            if (CurrentIndex == preorder.Length || preorder[CurrentIndex] > bound) return null;
            TreeNode node = new TreeNode(preorder[CurrentIndex++]);
            node.left = GenerateBST(preorder, node.val);
            node.right = GenerateBST(preorder, bound);
            return node;
        }
    }
}
