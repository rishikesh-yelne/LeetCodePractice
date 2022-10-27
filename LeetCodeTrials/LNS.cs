namespace LeetCodeTrials
{
    internal class LNS
    {
        public LNS()
        {
            var result = LongestNondecreasingSubsequence(new int[] { 2, 3, 5, 1, 7 });
            Console.WriteLine(result);
            var result1 = LongestNondecreasingSubsequence(new int[] { 3, 45, 23, 9, 3, 99, 108, 76, 12, 77, 16, 18, 4 });
            Console.WriteLine(result1);
        }

        public int LongestNondecreasingSubsequence(int[] S)
        {
            int[] dp = new int[S.Length];
            dp[0] = 1;
            int max = 0;
            for (int i = 1; i < S.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (S[j] <= S[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                    max = Math.Max(max, dp[i]);
                }
                if (dp[i] == 0) dp[i] = 1;
            }
            return max;
        }

    }
}
