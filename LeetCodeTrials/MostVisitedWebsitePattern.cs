namespace LeetCodeTrials
{
    internal class MostVisitedWebsitePattern
    {
        public MostVisitedWebsitePattern()
        {
            var result = MostVisitedPattern(
                new string[] { "h", "eiy", "cq", "h", "cq", "txldsscx", "cq", "txldsscx", "h", "cq", "cq" },
                new int[] { 527896567, 334462937, 517687281, 134127993, 859112386, 159548699, 51100299, 444082139, 926837079, 317455832, 411747930 },
                new string[] { "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "yljmntrclw", "hibympufi", "yljmntrclw" });
            //new string[] { "joe", "joe", "joe", "james", "james", "james", "james", "mary", "mary", "mary" }, 
            //new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 
            //new string[] { "home", "about", "career", "home", "cart", "maps", "home", "home", "about", "career" }); //CanFinish(2, new int[1][] { new int[] { 1, 0 } });
            //var result = solution.MostVisitedPattern(
            //  new string[] { "ua", "ua", "ua", "ub", "ub", "ub" },
            //  new int[] { 1, 2, 3, 4, 5, 6 },
            //  new string[] { "a", "b", "c", "a", "b", "a" });
            Console.WriteLine($"Result: {result}");
        }

        public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        {
            Dictionary<string, PriorityQueue<string, int>> userWebsiteMap = new Dictionary<string, PriorityQueue<string, int>>();
            for (int i = 0; i < username.Length; i++)
            {
                if (!userWebsiteMap.ContainsKey(username[i]))
                    userWebsiteMap.Add(username[i], new PriorityQueue<string, int>());
                userWebsiteMap[username[i]].Enqueue(website[i], timestamp[i]);
            }
            Dictionary<string, int> patternCount = new Dictionary<string, int>();
            foreach (var userMap in userWebsiteMap)
            {
                HashSet<string> patterns = new HashSet<string>();
                List<string> websites = new List<string>();
                while (userMap.Value.Count > 0)
                    websites.Add(userMap.Value.Dequeue());
                FindPatterns(patterns, new List<string>(), websites, 0);
                foreach (var pattern in patterns)
                {
                    if (patternCount.ContainsKey(pattern))
                    {
                        patternCount[pattern]++;
                    }
                    else
                    {
                        patternCount.Add(pattern, 1);
                    }
                }
            }
            return patternCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key).First().Key.Split("_");
        }

        private void FindPatterns(HashSet<string> patterns, List<string> pattern, List<string> websites, int index)
        {
            if (pattern.Count == 3)
            {
                patterns.Add(String.Join("_", pattern));
                return;
            }
            for (int i = index; i < websites.Count; i++)
            {
                pattern.Add(websites[i]);
                FindPatterns(patterns, pattern, websites, i + 1);
                pattern.RemoveAt(pattern.Count - 1);
            }
        }
    }
}
