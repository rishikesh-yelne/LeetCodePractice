namespace LeetCodeTrials
{
    internal class PermutationSequence
    {
        public PermutationSequence()
        {
            var result = GetPermutation(3, 3);
            Console.WriteLine($"Result: {result}");
        }

        public string GetPermutation(int n, int k)
        {
            List<int> numbers = new List<int>();
            List<int> result = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            int blockIndex = k - 1;
            int blockSize = Factorial(n);
            for (int i = n; i > 0; i--)
            {
                blockSize = blockSize / i;
                int blockNumber = blockSize == 0 ? 0 : blockIndex / blockSize;
                blockIndex = blockSize == 0 ? 0 : blockIndex % blockSize;
                result.Add(numbers[blockNumber]);
                numbers.RemoveAt(blockNumber);
            }
            return string.Join("", result);
        }

        private int Factorial(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * Factorial(n - 1);
        }
    }
}
