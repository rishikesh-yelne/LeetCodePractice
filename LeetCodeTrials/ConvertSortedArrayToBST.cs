namespace LeetCodeTrials
{
    internal class ConvertSortedArrayToBST
    {
        public ConvertSortedArrayToBST()
        {
            var result = SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
            Console.WriteLine($"Result : {result}");
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;
            return ArrayToBST(0, nums.Length - 1, nums);
        }

        private TreeNode ArrayToBST(int start, int end, int[] nums)
        {
            if (start > end) return null;

            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(nums[mid]);

            node.left = ArrayToBST(start, mid - 1, nums);
            node.right = ArrayToBST(mid + 1, end, nums);

            return node;
        }
    }
}
