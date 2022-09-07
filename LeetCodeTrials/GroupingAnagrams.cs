namespace LeetCodeTrials
{
    internal class GroupingAnagrams
    {
        public GroupingAnagrams()
        {
            var result = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            Console.WriteLine($"Result : {result}");
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            if (strs.Length == 0) return result;
            if (strs.Length == 1)
            {
                result.Add(new List<string>() { strs[0] });
                return result;
            }
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            foreach (var word in strs)
            {
                string sortedWord = string.Join("", word.ToCharArray().OrderBy(x => x).ToList());
                if (dictionary.ContainsKey(sortedWord))
                {
                    dictionary[sortedWord].Add(word);
                }
                else
                {
                    dictionary.Add(sortedWord, new List<string>() { word });
                }
            }

            foreach (var entries in dictionary)
            {
                result.Add(entries.Value);
                Console.WriteLine($"Key:{entries.Key}, Value:{entries.Value}");
            }

            return result;
        }
    }
}
