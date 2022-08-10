namespace LeetCodeTrials
{
    internal class TelephoneLetters
    {
        public TelephoneLetters()
        {
            LetterCombinations("23");
        }
        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, string> telephone = InitCharAndNumberMapping();
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(digits) || digits.Equals("1")) return result;

            FindBackTrackResult(result, telephone, digits, string.Empty, 0);
            return result;
        }

        private void FindBackTrackResult(List<string> result, Dictionary<char, string> telephone, string digits, string word, int index)
        {
            if (word.Length == digits.Length)
            {
                result.Add(word);
                return;
            }

            char number = digits[index];
            string numberChars = telephone[number];

            foreach (char c in numberChars)
            {
                string newWord = word + c;
                FindBackTrackResult(result, telephone, digits, newWord, index + 1);
            }
        }

        private Dictionary<char, string> InitCharAndNumberMapping()
        {
            Dictionary<char, string> telephone = new Dictionary<char, string>();
            telephone.Add('1', "");
            telephone.Add('2', "abc");
            telephone.Add('3', "def");
            telephone.Add('4', "ghi");
            telephone.Add('5', "jkl");
            telephone.Add('6', "mno");
            telephone.Add('7', "pqrs");
            telephone.Add('8', "tuv");
            telephone.Add('9', "wxyz");
            return telephone;
        }
    }
}
