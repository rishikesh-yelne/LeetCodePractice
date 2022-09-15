namespace LeetCodeTrials
{
    internal class ShortestPathToGetFood
    {
        public ShortestPathToGetFood()
        {
            var result = GetFood(new char[4][] { 
                //new char[] { 'X', 'X', 'X', 'X', 'X', 'X' }, 
                //new char[] { 'X', '*', 'O', 'O', 'O', 'X' }, 
                //new char[] { 'X', 'O', 'O', '#', 'O', 'X' }, 
                //new char[] { 'X', 'X', 'X', 'X', 'X', 'X' } 
                new char[] { '*', '#', 'O', 'O' },
                new char[] { 'O', 'O', 'O', 'O' },
                new char[] { 'X', 'O', 'O', 'O' },
                new char[] { 'O', 'O', 'O', 'O' }
            });
            Console.WriteLine($"Result : {result}");

        }
        public int GetFood(char[][] grid)
        {
            int steps = 0;
            bool found = false;
            Tuple<int, int> startPos = null;
            for (int i = 0; i < grid.Length; i++)
            {
                List<int> start = grid[i].Select((s, i) => new { i, s }).Where(x => x.s == '*').Select(x => x.i).ToList();
                if (start.Count == 1) startPos = Tuple.Create(i, start[0]);
            }
            if (startPos != null)
            {
                Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
                queue.Enqueue(startPos);
                grid[startPos.Item1][startPos.Item2] = 'O';
                while (queue.Count > 0)
                {
                    List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();
                    while (queue.Count > 0)
                    {
                        Tuple<int, int> position = queue.Dequeue();
                        int xPos = position.Item1;
                        int yPos = position.Item2;
                        if (grid[xPos][yPos] == '#')
                        {
                            found = true;
                            break;
                        }
                        else if (grid[xPos][yPos] == 'O')
                        {
                            grid[xPos][yPos] = 'X';
                        }
                        if (xPos + 1 < grid.Length && grid[xPos + 1][yPos] != 'X')
                        {
                            neighbors.Add(new Tuple<int, int>(xPos + 1, yPos));
                        }
                        if (yPos + 1 < grid[xPos].Length && grid[xPos][yPos + 1] != 'X')
                        {
                            neighbors.Add(new Tuple<int, int>(xPos, yPos + 1));
                        }
                        if (xPos - 1 >= 0 && grid[xPos - 1][yPos] != 'X')
                        {
                            neighbors.Add(new Tuple<int, int>(xPos - 1, yPos));
                        }
                        if (yPos - 1 >= 0 && grid[xPos][yPos - 1] != 'X')
                        {
                            neighbors.Add(new Tuple<int, int>(xPos, yPos - 1));
                        }
                    }
                    if (found) break;
                    steps++;
                    foreach (var position in neighbors.Distinct())
                    {
                        queue.Enqueue(position);
                    }
                }
            }
            return found ? steps : -1;
        }
    }
}
