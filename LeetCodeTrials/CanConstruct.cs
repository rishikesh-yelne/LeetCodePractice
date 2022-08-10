namespace LeetCodeTrials
{
    public class CanConstruct
    {
        public CanConstruct()
        {
            Run();
        }
        void Run()
        {
            CanConstructSolution solution = new CanConstructSolution();
            string ransomNote = "aa";
            string magazine = "aab";
            bool result = solution.CanConstruct(ransomNote, magazine);
            Console.WriteLine($"Result : {result}");
        }
    }

    public class CanConstructSolution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> ransomDictionary = new Dictionary<char, int>();
            Dictionary<char, int> magazineDictionary = new Dictionary<char, int>();

            foreach (var character in ransomNote)
            {
                if (ransomDictionary.ContainsKey(character))
                {
                    ransomDictionary[character] = ransomDictionary[character] + 1;
                }
                else
                {
                    ransomDictionary.Add(character, 1);
                }
            }

            foreach (var character in magazine)
            {
                if (magazineDictionary.ContainsKey(character))
                {
                    magazineDictionary[character] = magazineDictionary[character] + 1;
                }
                else
                {
                    magazineDictionary.Add(character, 1);
                }
            }

            foreach (var ransomChar in ransomDictionary.Keys)
            {
                if (magazineDictionary.ContainsKey(ransomChar))
                {
                    if (magazineDictionary[ransomChar] < ransomDictionary[ransomChar])
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
