namespace LeetCodeTrials
{
    internal class LastWordLength
    {
        public LastWordLength()
        {
            LengthOfLastWord("luffy is still joyboy");
        }

        public int LengthOfLastWord(string s)
        {
            List<string> words = s.Split(' ').ToList<string>();
            return words.Where(x => x.Length > 0).Last().Length;
        }
    }
}
