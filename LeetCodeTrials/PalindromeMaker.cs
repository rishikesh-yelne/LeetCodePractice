namespace LeetCodeTrials
{
    internal class PalindromeMaker
    {
        public PalindromeMaker()
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            string[] input = new string[testCases];

            for (int i = 0; i < testCases; i++)
            {
                Console.ReadLine();
                input[i] = Console.ReadLine();
            }

            for (int i = 0; i < testCases; i++)
            {
                int length = minDeletions(input[i]);
                if (input[i].Length - length == 1)
                    Console.WriteLine("-1");
                else if (input[i].Length - length > 2)
                    Console.WriteLine(length + (input[i].Length - length - 2));
                else Console.WriteLine(length);
            }
        }

        private static int minDeletions(string s)
        {
            int[][] dp = new int[s.Length][];
            for (int i = s.Length - 1; i >= 0; i--)
            {
                dp[i] = new int[s.Length];
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        dp[i][j] = dp[i + 1][j - 1];
                    }
                    else
                    {
                        dp[i][j] = 1 + Math.Min(dp[i + 1][j], dp[i][j - 1]);
                    }
                }
            }
            return dp[0][s.Length - 1];
        }
    }
}
