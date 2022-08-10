namespace LeetCodeTrials
{
    internal class TaskScheduler
    {
        char[] example1 = new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        char[] example2 = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
        char[] example3 = new char[] { 'A', 'B', 'A' };
        public TaskScheduler()
        {
            LeastInterval(example1, 2);
            LeastInterval(example2, 2);
            LeastInterval(example2, 0);
            LeastInterval(example3, 2);
        }

        public int LeastInterval(char[] tasks, int n)
        {
            if (n == 0) return tasks.Length;

            PriorityQueue<char, int> queue = new PriorityQueue<char, int>(Comparer<int>.Create((a, b) => b - a));

            int[] charCounts = new int[26];
            foreach (char task in tasks)
            {
                charCounts[task - 'A']++;
            }

            for (int i = 0; i < charCounts.Length; i++)
            {
                if (charCounts[i] == 0) continue;
                queue.Enqueue((char)(i + 'A'), charCounts[i]);
            }

            Dictionary<char, int> ongoingTask = new Dictionary<char, int>();
            int result = 0;
            while (queue.Count > 0)
            {
                for (int i = 0; i < n + 1; i++)
                {
                    if (queue.Count > 0)
                    {
                        queue.TryDequeue(out char task, out int time);
                        ongoingTask.Add(task, time);
                    }
                }
                foreach (var task in ongoingTask)
                {
                    int time = task.Value - 1;
                    if (time > 0)
                    {
                        queue.Enqueue(task.Key, time);
                    }
                }
                result += queue.Count == 0 ? ongoingTask.Count : n + 1;
                ongoingTask.Clear();
            }
            return result;
        }
    }
}
