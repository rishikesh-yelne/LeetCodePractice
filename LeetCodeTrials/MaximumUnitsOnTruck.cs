namespace LeetCodeTrials
{
    internal class MaximumUnitsOnTruck
    {
        public MaximumUnitsOnTruck()
        {
            //var result = MaximumUnits(new int[][] { new int[] { 1, 3 }, new int[] { 2, 2 }, new int[] { 3, 1 } }, 4);
            var result = MaximumUnits(new int[][] { new int[] { 5, 10 }, new int[] { 2, 5 }, new int[] { 4, 7 }, new int[] { 3, 9 } }, 10);
            Console.WriteLine($"Result : {result}");
        }
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            var sortedBoxes = boxTypes.OrderByDescending(x => x[1]).ToList();
            int totalSize = 0;
            int answer = 0;
            foreach (var box in sortedBoxes)
            {
                if (totalSize + box[0] < truckSize)
                {
                    totalSize += box[0];
                    answer += box[0] * box[1];
                }
                else
                {
                    answer += (truckSize - totalSize) * box[1];
                    break;
                }
            }
            return answer;
        }
    }
}
