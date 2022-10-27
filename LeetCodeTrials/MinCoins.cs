namespace LeetCodeTrials
{
    internal class MinCoins
    {
        public MinCoins()
        {
            Solve_Recursive(17);
            Console.WriteLine(count);
            var result = Solve_ConstantTime(17);
            Console.WriteLine($"Result : {result}");
            var result1 = Solve_DP(new int[] { 1, 6, 10 }, 12);//(new int[] { 1, 5, 10, 25, 50 }, 17);
            Console.WriteLine($"Result : {result1}");
        }

        int[] denominations = new int[5] { 50, 25, 10, 5, 1 };
        public int count = 0;
        public void Solve_Recursive(int value)
        {
            int index = FindMaxDenomination(value);
            if (index != -1)
            {
                Console.WriteLine(denominations[index]);
                count++;
                Solve_Recursive(value - denominations[index]);
            }
        }

        int FindMaxDenomination(int value)
        {
            for (int i = 0; i < denominations.Length; i++)
            {
                if (denominations[i] <= value)
                    return i;
            }
            return -1;
        }

        public int Solve_ConstantTime(int value)
        {
            int count = 0;
            if (value >= 50)
            {
                count += value / 50;
                value %= 50;
            }
            if (value >= 25)
            {
                count += value / 25;
                value %= 25;
            }
            if (value >= 10)
            {
                count += value / 10;
                value %= 10;
            }
            if (value >= 5)
            {
                count += value / 5;
                value %= 5;
            }
            if (value >= 1)
            {
                count += value / 1;
                value %= 1;
            }
            return count;
        }

        public int Solve_DP(int[] denom, int value)
        {
            int[] dp = new int[value + 1];
            dp[0] = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                int minimum = int.MaxValue;
                for (int j = 0; j < denom.Length; j++)
                {
                    if (denom[j] <= i)
                    {
                        minimum = Math.Min(minimum, dp[i - denom[j]] + 1);
                    }
                }
                dp[i] = minimum;
            }
            return dp[value];
        }

    }
}
