namespace LeetCodeTrials
{
    internal class TriangularSumOfArray
    {
        public TriangularSumOfArray()
        {
            var result = TriangularSum(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Result : {result}");
        }

        public int TriangularSum(int[] nums)
        {
            int sum = 0;
            Queue<int> q = new Queue<int>();
            foreach (int val in nums)
            {
                q.Enqueue(val);
            }

            int n = nums.Length;
            if (n == 0) return 0;
            if (n == 1) return nums[0];
            while (q.Count > 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    int val1 = q.Dequeue();
                    int val2 = (q.Count > 0) ? q.Peek() : 0;
                    q.Enqueue((val1 + val2) % 10);
                }
                if (q.Count > 0)
                {
                    int val = q.Peek();
                    if (q.Count == 1) sum = val;
                    q.Dequeue();
                }
                n--;
            }
            return sum;
        }
    }
}
