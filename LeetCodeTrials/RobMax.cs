namespace LeetCodeTrials
{
    internal class RobMax
    {
        public int?[] cache;
        public int Rob(int[] nums)
        {
            cache = new int?[nums.Length];
            return Max(nums, 0);
        }

        private int Max(int[] nums, int index)
        {
            if (index >= nums.Length)
                return 0;

            if (cache[index] != null)
                return cache[index].GetValueOrDefault();

            var currentMax = nums[index] + Max(nums, index + 2);
            var skipCurrent = Max(nums, index + 1);
            var maxLoot = Math.Max(currentMax, skipCurrent);
            cache[index] = maxLoot;
            return maxLoot;
        }
    }
}
