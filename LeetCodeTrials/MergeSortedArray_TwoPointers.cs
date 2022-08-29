namespace LeetCodeTrials
{
    internal class MergeSortedArray_TwoPointers
    {
        public MergeSortedArray_TwoPointers()
        {
            Merge(new int[6] { 1, 2, 3, 0, 0, 0 }, 3, new int[3] { 2, 5, 6 }, 3);
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int iterator = nums1.Length - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums2[j] > nums1[i])
                {
                    nums1[iterator] = nums2[j];
                    j--;
                    iterator--;
                }
                else
                {
                    nums1[iterator] = nums1[i];
                    i--;
                    iterator--;
                }
            }
            while (j >= 0)
            {
                nums1[iterator] = nums2[j];
                j--;
                iterator--;
            }
        }
    }
}
