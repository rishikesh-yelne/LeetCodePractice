namespace LeetCodeTrials
{
    internal class ParitySort
    {
        public ParitySort()
        {
            var result = SortArrayByParity(new int[4] { 3, 1, 2, 4 });
            Console.WriteLine($"Result : {result}");
        }

        public int[] SortArrayByParity(int[] nums)
        {
            if (nums.Length <= 1) return nums;
            List<int> parityList = nums.ToList();
            for (int i = 0; i < parityList.Count; i++)
            {
                if (parityList[i] % 2 == 0)
                {
                    int evenNum = parityList[i];
                    parityList.RemoveAt(i);
                    parityList.Insert(0, evenNum);
                }
            }
            return parityList.ToArray();
        }
    }
}
