namespace LeetCodeTrials
{
    internal class LongestIncreasingSubsequence
    {
        public LongestIncreasingSubsequence()
        {
            var result1 = LengthOfLIS_Alternative1(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
            var result2 = LengthOfLIS_Alternative2(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
            var result3 = LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
            Console.WriteLine($"Result1: {result1}");
            Console.WriteLine($"Result2: {result2}");
            Console.WriteLine($"Result3: {result3}");
        }

        // O(n^2)
        public int LengthOfLIS_Alternative1(int[] nums)
        {
            int answer = 1;
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    answer = Math.Max(answer, dp[i]);
                }
            }
            return answer;
        }


        // O(n^2)
        public int LengthOfLIS_Alternative2(int[] nums)
        {
            List<int> subsequence = new List<int>();
            subsequence.Add(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                if (subsequence.Last() < nums[i])
                {
                    subsequence.Add(nums[i]);
                }
                else
                {
                    int j = 0;
                    while (nums[i] > subsequence[j]) j++;
                    subsequence[j] = nums[i];
                }
            }
            return subsequence.Count;
        }


        // O(nlogn)
        public int LengthOfLIS(int[] nums)
        {
            List<int> subsequence = new List<int>();
            subsequence.Add(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                if (subsequence.Last() < nums[i])
                {
                    subsequence.Add(nums[i]);
                }
                else
                {
                    int j = BinarySearch(subsequence, nums[i]);
                    subsequence[j] = nums[i];
                }
            }
            return subsequence.Count;
        }

        private int BinarySearch(List<int> subsequence, int num)
        {
            int left = 0;
            int right = subsequence.Count - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (subsequence[mid] == num) return mid;

                if (subsequence[mid] < num) left = mid + 1;
                else right = mid;
            }

            return left;
        }
    }
}
