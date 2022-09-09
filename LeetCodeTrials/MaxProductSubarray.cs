namespace LeetCodeTrials
{
    internal class MaxProductSubarray
    {
        public MaxProductSubarray()
        {
            var result = MaxProduct(new int[] { 2, 3, -2, 4 });
            Console.WriteLine($"Result : {result}");
        }

        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int max = nums[0];
            int min = nums[0];
            int answer = max;

            for (int i = 1; i < nums.Length; i++)
            {
                int tempMax = max;
                max = Math.Max(nums[i], Math.Max(max * nums[i], min * nums[i]));
                min = Math.Min(nums[i], Math.Min(tempMax * nums[i], min * nums[i]));
                answer = Math.Max(answer, max);
            }

            return answer;
        }

    }
}
