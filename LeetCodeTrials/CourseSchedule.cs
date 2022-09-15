namespace LeetCodeTrials
{
    internal class CourseSchedule
    {
        public CourseSchedule()
        {
            var result = CanFinish(2, new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } });
            Console.WriteLine($"Result : {result}");
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; i++) prereq[i] = new List<int>();
            foreach (int[] ele in prerequisites)
            {
                if (prereq.ContainsKey(ele[1]))
                {
                    prereq[ele[1]].Add(ele[0]);
                }
                else
                {
                    prereq.Add(ele[1], new List<int> { ele[0] });
                }
            }
            int[] dfs = new int[numCourses];
            int[] visited = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] != 1)
                {
                    if (CycleFound(i, prereq, visited, dfs)) return false;
                }
            }
            return true;
        }

        private bool CycleFound(int curr, Dictionary<int, List<int>> adj, int[] visited, int[] dfs)
        {
            dfs[curr] = 1;
            visited[curr] = 1;
            foreach (var ele in adj[curr])
            {
                if (visited[ele] != 1)
                {
                    if (CycleFound(ele, adj, visited, dfs)) return true;
                }
                else if (dfs[ele] == 1) return true;
            }
            dfs[curr] = 0;
            return false;
        }
    }
}
