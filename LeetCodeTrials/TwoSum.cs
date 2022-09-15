namespace LeetCodeTrials
{
    internal class TwoSum
    {
        public TwoSum()
        {
            var result = CalcTwoSum(new int[] { 7, 11, 2, 15 }, 9);
            Console.WriteLine($"Result : {result}");
        }
        public int[] CalcTwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int remaining = target - nums[i];
                if (dict.ContainsKey(remaining))
                {
                    return new int[] { i, dict[remaining] };
                }
                if (dict.ContainsKey(nums[i]))
                    dict[nums[i]] = i;
                else dict.Add(nums[i], i);
            }
            return null;
        }
    }
}
