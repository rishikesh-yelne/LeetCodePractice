namespace LeetCodeTrials
{
    internal class BfsDfsGraph
    {
        public BfsDfsGraph()
        {
            List<List<int>> adj1 = new List<List<int>>();
            adj1.Add(new List<int>() { 2, 5 });
            adj1.Add(new List<int>() { 5, 6, 8 });
            adj1.Add(new List<int>() { });
            adj1.Add(new List<int>() { 4, 5 });
            adj1.Add(new List<int>() { 4, 7 });
            adj1.Add(new List<int>() { 5, 7 });
            adj1.Add(new List<int>() { });
            adj1.Add(new List<int>() { });
            adj1.Add(new List<int>() { });

            List<List<int>> adj2 = new List<List<int>>();
            adj2.Add(new List<int>() { 1, 2, 3 });
            adj2.Add(new List<int>() { });
            adj2.Add(new List<int>() { 4 });
            adj2.Add(new List<int>() { });
            adj2.Add(new List<int>() { });

            var result1 = bfsOfGraph(9, adj1);
            var result2 = dfsOfGraph(5, adj2);
            Console.WriteLine($"BFS Result : {result1.ListToString()}");
            Console.WriteLine($"DFS Result : {result2.ListToString()}");
        }

        public List<int> bfsOfGraph(int V, List<List<int>> adj)
        {
            // Code here
            bool[] visited = new bool[V + 1];
            List<int> bfs = new List<int>();
            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(i);
                    visited[i] = true;

                    while (queue.Count > 0)
                    {
                        int node = queue.Dequeue();
                        bfs.Add(node);

                        foreach (var connected in adj[node])
                        {
                            if (!visited[connected])
                            {
                                queue.Enqueue(connected);
                                visited[connected] = true;
                            }
                        }
                    }
                }
            }
            return bfs;
        }

        public List<int> dfsOfGraph(int V, List<List<int>> adj)
        {
            // Code here
            List<int> dfs = new List<int>();
            bool[] visited = new bool[V + 1];
            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    CalcDfs(dfs, adj, visited, i);
                }
            }
            return dfs;
        }

        private void CalcDfs(List<int> dfs, List<List<int>> adj, bool[] visited, int currentNode)
        {
            visited[currentNode] = true;
            dfs.Add(currentNode);
            List<int> edges = adj[currentNode];
            for (int j = 0; j < edges.Count; j++)
            {
                if (!visited[edges[j]])
                {
                    CalcDfs(dfs, adj, visited, edges[j]);
                }
            }
        }
    }
}
