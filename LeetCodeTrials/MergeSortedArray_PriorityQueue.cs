namespace LeetCodeTrials
{
    internal class MergeSortedArray_PriorityQueue
    {
        public MergeSortedArray_PriorityQueue()
        {
            Merge(new int[6] { 1, 2, 3, 0, 0, 0 }, 3, new int[3] { 2, 5, 6 }, 3);
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a - b));

            for (int i = 0; i < m; i++)
                queue.Enqueue(nums1[i], nums1[i]);
            for (int i = 0; i < n; i++)
                queue.Enqueue(nums2[i], nums2[i]);

            int iterator = 0;
            while (queue.Count > 0)
            {
                queue.TryDequeue(out int num, out int priority);
                nums1[iterator] = num;
                iterator++;
            }
        }
    }
}
