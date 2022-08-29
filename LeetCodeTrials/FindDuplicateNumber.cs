namespace LeetCodeTrials
{
    internal class FindDuplicateNumber
    {
        public FindDuplicateNumber()
        {
            var result = FindDuplicate(new int[] { 3, 1, 3, 2, 4 });
            Console.WriteLine($"Result: {result}");
        }

        public int FindDuplicate(int[] nums)
        {
            int start = 1;
            int end = nums.Length - 1;
            int answer = -1;

            while (start <= end)
            {
                int ele = (start + end) / 2;

                int count = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] <= ele) count++;
                }

                if (count > ele)
                {
                    answer = ele;
                    end = ele - 1;
                }
                else
                {
                    start = ele + 1;
                }
            }

            return answer;
        }
    }
}
