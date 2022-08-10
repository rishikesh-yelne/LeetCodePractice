namespace LeetCodeTrials
{
    internal class ColorSorting
    {
        public ColorSorting()
        {
            SortColors(new int[] { 2, 0, 2, 1, 1, 0 });
        }

        public void SortColors(int[] nums)
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();
            counter.Add(0, 0);
            counter.Add(1, 0);
            counter.Add(2, 0);
            for (int i = 0; i < nums.Length; i++)
            {
                counter[nums[i]]++;
            }

            int iterator = 0;
            foreach (var item in counter)
            {
                int innerCounter = 0;
                while (innerCounter < item.Value)
                {
                    nums[iterator] = item.Key;
                    iterator++;
                    innerCounter++;
                }
            }
        }
    }
}
