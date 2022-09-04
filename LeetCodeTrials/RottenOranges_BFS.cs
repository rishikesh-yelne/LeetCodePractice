namespace LeetCodeTrials
{
    internal class RottenOranges_BFS
    {
        public RottenOranges_BFS()
        {
            var result = OrangesRotting(new int[3][] { new int[] { 2, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 0, 1, 1 } }); ;
            Console.WriteLine($"Result: {result}");
        }
        public int OrangesRotting(int[][] grid)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            int fresh = 0;
            int minutes = -1;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2) queue.Enqueue(new Tuple<int, int>(i, j));
                    else if (grid[i][j] == 1) fresh++;
                }
            }

            queue.Enqueue(new Tuple<int, int>(-1, -1));
            while (queue.Count > 0)
            {
                Tuple<int, int> index = queue.Dequeue();
                if (index.Item1 == -1)
                {
                    minutes++;
                    if (queue.Count > 0) queue.Enqueue(new Tuple<int, int>(-1, -1));
                }
                else
                {
                    if (index.Item1 + 1 < grid.Length && grid[index.Item1 + 1][index.Item2] == 1)
                    {
                        grid[index.Item1 + 1][index.Item2] = 2;
                        fresh--;
                        queue.Enqueue(new Tuple<int, int>(index.Item1 + 1, index.Item2));
                    }
                    if (index.Item1 - 1 >= 0 && grid[index.Item1 - 1][index.Item2] == 1)
                    {
                        grid[index.Item1 - 1][index.Item2] = 2;
                        fresh--;
                        queue.Enqueue(new Tuple<int, int>(index.Item1 - 1, index.Item2));
                    }
                    if (index.Item2 + 1 < grid.Length && grid[index.Item1][index.Item2 + 1] == 1)
                    {
                        grid[index.Item1][index.Item2 + 1] = 2;
                        fresh--;
                        queue.Enqueue(new Tuple<int, int>(index.Item1, index.Item2 + 1));
                    }
                    if (index.Item2 - 1 > 0 && grid[index.Item1][index.Item2 - 1] == 1)
                    {
                        grid[index.Item1][index.Item2 - 1] = 2;
                        fresh--;
                        queue.Enqueue(new Tuple<int, int>(index.Item1, index.Item2 - 1));
                    }
                }
            }
            return fresh == 0 ? minutes : -1;
        }

    }
}
