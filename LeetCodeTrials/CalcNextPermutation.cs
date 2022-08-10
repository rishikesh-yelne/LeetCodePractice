namespace LeetCodeTrials
{
    internal class CalcNextPermutation
    {
        public CalcNextPermutation()
        {
            NextPermutation(new int[] { 2, 1, 2, 2, 2, 2, 2, 1 });
        }

        public void NextPermutation(int[] nums)
        {
            int lowerIndex = nums.Length - 1, i = nums.Length - 1;
            for (i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i - 1] < nums[i])
                {
                    lowerIndex = i - 1;
                    break;
                }
            }
            if (i == 0)
            {
                Reverse(nums, 0, nums.Length - 1);
                return;
            }

            int upperValue = int.MaxValue, upperIndex = lowerIndex;
            for (int j = nums.Length - 1; j > lowerIndex; j--)
            {
                if (nums[j] > nums[lowerIndex])
                {
                    upperIndex = j;
                    upperValue = nums[j];
                    break;
                }
            }

            Swap(nums, lowerIndex, upperIndex);

            if (!string.Join("", nums.Take(new Range(lowerIndex + 1, nums.Length))).Equals(string.Join("", nums.Take(new Range(lowerIndex + 1, nums.Length)).OrderBy(x => x).ToArray())))
            {
                Reverse(nums, lowerIndex + 1, nums.Length - 1);
            }
        }

        private void Reverse(int[] nums, int lowerIndex, int upperIndex)
        {
            while (lowerIndex < upperIndex)
            {
                Swap(nums, lowerIndex, upperIndex);
                lowerIndex++;
                upperIndex--;
            }
        }

        private void Swap(int[] nums, int lowerIndex, int upperIndex)
        {
            int temp = nums[lowerIndex];
            nums[lowerIndex] = nums[upperIndex];
            nums[upperIndex] = temp;
        }
    }
}
