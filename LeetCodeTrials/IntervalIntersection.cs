namespace LeetCodeTrials
{
    class IntervalIntersection
    {
        public IntervalIntersection()
        {
            List<Tuple<int, int>> first = new List<Tuple<int, int>>()
            {
                Tuple.Create<int, int>(0, 2),
                Tuple.Create<int, int>(5, 10),
                Tuple.Create<int, int>(13, 23),
                Tuple.Create<int, int>(24, 25)
            };
            List<Tuple<int, int>> second = new List<Tuple<int, int>>()
            {
                Tuple.Create<int, int>(1, 5),
                Tuple.Create<int, int>(8, 12),
                Tuple.Create<int, int>(15, 24),
                Tuple.Create<int, int>(25, 26)
            };
            int[][] firstList = first.Select(x => new int[2] { x.Item1, x.Item2 }).ToArray();
            int[][] secondList = second.Select(x => new int[2] { x.Item1, x.Item2 }).ToArray();
            var result = CalcIntervalIntersection(firstList, secondList);
            Console.WriteLine($"Result : {result}");
        }
        public int[][] CalcIntervalIntersection(int[][] firstList, int[][] secondList)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            if (firstList.Length == 0 || secondList.Length == 0) return new int[0][] { };
            int min = firstList[0][0] > secondList[0][0] ? secondList[0][0] : firstList[0][0];
            int max = firstList[firstList.Length - 1][1] > secondList[secondList.Length - 1][1] ? firstList[firstList.Length - 1][1] : secondList[secondList.Length - 1][1];
            int? start = null;
            int? end = null;
            int firstIndex = 0;
            int secondIndex = 0;
            for (int i = min; i <= max; i++)
            {
                int isPresentInFirstList = isPresent(firstList, i, ref firstIndex);
                int isPresentInSecondList = isPresent(secondList, i, ref secondIndex);
                if (isPresentInFirstList > -1 && isPresentInSecondList > -1)
                {
                    if (isPresentInFirstList != 0 && isPresentInSecondList != 0 && isPresentInFirstList != isPresentInSecondList) // both extremes
                    {
                        start = i;
                        end = i;
                        result.Add(Tuple.Create<int, int>(start.Value, end.Value));
                        start = null;
                        end = null;
                    }
                    else
                    {
                        if (start == null)
                        {
                            start = i;
                        }
                        else
                        {
                            end = i;
                        }
                        if (end == null)
                        {
                            end = i;
                        }
                        if (isPresentInFirstList == 2 || isPresentInSecondList == 2)
                        {
                            result.Add(Tuple.Create<int, int>(start.Value, end.Value));
                            start = null;
                            end = null;
                        }
                    }
                }
                else
                {
                    if (start != null && end != null)
                    {
                        result.Add(Tuple.Create<int, int>(start.Value, end.Value));
                        start = null;
                        end = null;
                    }
                }
            }
            return result.Select(x => new int[2] { x.Item1, x.Item2 }).ToArray();
        }

        private int isPresent(int[][] list, int number, ref int index)
        {
            for (int i = index; i < list.Length; i++)
            {
                int returnValue = -1;
                if (list[i][0] <= number && number <= list[i][1])
                {
                    returnValue = 0; // found
                    if (number == list[i][0]) returnValue = 1; //left most
                    if (number == list[i][1]) returnValue = 2; //right most
                    index = i;
                }
                if (returnValue > -1) return returnValue;
            }
            return -1;
        }
    }
}
