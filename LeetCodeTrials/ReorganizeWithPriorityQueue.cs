using System.Text;

namespace LeetCodeTrials
{
    internal class ReorganizeWithPriorityQueue
    {
        public string ReorganizeString(string s)
        {
            PriorityQueue<char, int> priorityQueue = new PriorityQueue<char, int>(Comparer<int>.Create((a, b) => b - a));

            int[] charCounts = new int[26];
            foreach (char c in s)
            {
                charCounts[c - 'a']++;
            }

            for (int i = 0; i < charCounts.Length; i++)
            {
                if (charCounts[i] == 0) continue;
                priorityQueue.Enqueue((char)('a' + i), charCounts[i]);
            }
            StringBuilder result = new StringBuilder();
            while (priorityQueue.Count >= 2)
            {
                priorityQueue.TryDequeue(out char c1, out int count1);
                priorityQueue.TryDequeue(out char c2, out int count2);
                if (result.Length != 0 && (result[result.Length - 1] == c1 || result[result.Length - 1] == c2))
                {
                    char lastChar = result[result.Length - 1];
                    result.Append(lastChar == c1 ? c2 : c1).Append(lastChar == c1 ? c1 : c2);
                }
                else
                {
                    result.Append(count1 > count2 ? c1 : c2).Append(count1 > count2 ? c2 : c1);
                }

                count1--;
                count2--;
                if (count1 > 0)
                    priorityQueue.Enqueue(c1, count1);
                if (count2 > 0)
                    priorityQueue.Enqueue(c2, count2);
            }

            if (priorityQueue.Count == 0)
            {
                return result.ToString();
            }

            bool isSuccess = priorityQueue.TryDequeue(out char x, out int priority);
            if (isSuccess && priority == 1 && result[result.Length - 1] != x)
            {
                result.Append(x);
                return result.ToString();
            }
            return String.Empty;
        }
    }
}
