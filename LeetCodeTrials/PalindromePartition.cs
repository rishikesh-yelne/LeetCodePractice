namespace LeetCodeTrials
{
    internal class PalindromePartition
    {
        public PalindromePartition()
        {
            var result = Partition("cdd"); //Partition("aab");
            Console.WriteLine($"Result : {result}");
        }

        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> result = new List<IList<string>>();
            PalindromePartitioning(0, result, new List<string>(), s);
            return result;
        }

        private void PalindromePartitioning(int start, List<IList<string>> result, List<string> currentList, string s)
        {
            if (start >= s.Length)
                result.Add(new List<string>(currentList));

            for (int i = start; i < s.Length; i++)
            {
                if (IsPalindrome(s, start, i))
                {
                    currentList.Add(s.Substring(start, i - start + 1));
                    PalindromePartitioning(i + 1, result, currentList, s);
                    currentList.RemoveAt(currentList.Count - 1);
                }
            }
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start++] != s[end--]) return false;
            }
            return true;
        }
    }
}
