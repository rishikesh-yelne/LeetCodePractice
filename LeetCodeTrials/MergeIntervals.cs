namespace LeetCodeTrials
{
    internal class MergeIntervals
    {
        public MergeIntervals()
        {
            Merge(new int[4][] { new int[2] { 1, 3 }, new int[2] { 2, 6 }, new int[2] { 5, 10 }, new int[2] { 15, 18 } });
            Merge(new int[2][] { new int[2] { 1, 4 }, new int[2] { 0, 4 } });
        }

        public int[][] Merge(int[][] intervals)
        {
            intervals = intervals.OrderBy(i => i[0]).ToArray();
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            for (int i = 0; i < intervals.Length; i++)
            {
                if (result.Count == 0)
                {
                    result.Add(new Tuple<int, int>(intervals[i][0], intervals[i][1]));
                }
                else
                {
                    Tuple<int, int> lastElement = result.Last();
                    if (CheckIfOverlapping(new int[2] { lastElement.Item1, lastElement.Item2 }, intervals[i]))
                    {
                        result.RemoveAt(result.Count - 1);
                        result.Add(new Tuple<int, int>(Math.Min(lastElement.Item1, intervals[i][0]), Math.Max(lastElement.Item2, intervals[i][1])));
                    }
                    else
                    {
                        result.Add(new Tuple<int, int>(intervals[i][0], intervals[i][1]));
                    }
                }
            }

            return result.Select(x => new int[2] { x.Item1, x.Item2 }).ToArray();
        }

        private bool CheckIfOverlapping(int[] element1, int[] element2)
        {
            return ((element2[1] >= element1[0] && element2[0] <= element1[1]) || (element2[0] <= element1[1] && element2[1] >= element1[0]));
        }
    }
}
