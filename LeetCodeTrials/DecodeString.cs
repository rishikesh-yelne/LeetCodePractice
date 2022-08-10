using System.Text;

namespace LeetCodeTrials
{
    internal class DecodeString
    {
        public DecodeString()
        {
            //var result = solution.DecodeString("abc3[cd]xyz");
            //var result = solution.DecodeString("2[abc]3[cd]ef");
            var result = DecodeFinalString("3[z]2[2[y]pq4[2[jk]e1[f]]]ef");
            Console.WriteLine($"Result : {result}");
        }
        public string DecodeFinalString(string s)
        {
            Tuple<string, int> decodedString = Decode(s, 0);
            return decodedString.Item1;
        }

        private Tuple<string, int> Decode(string s, int index)
        {
            if (index >= s.Length) return Tuple.Create(string.Empty, 0);

            StringBuilder result = new StringBuilder();
            int number = 0;
            int repeat = 0;

            for (int i = index; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    while (Char.IsDigit(s[i]) && i < s.Length)
                    {
                        number = number * 10 + int.Parse(s[i].ToString());
                        i++;
                    }
                    i--;
                    repeat = number;
                    number = 0;
                }
                else if (s[i] == '[')
                {
                    Tuple<string, int> innerDecodedString = Decode(s, i + 1);

                    for (int j = 0; j < repeat; j++)
                    {
                        result.Append(innerDecodedString.Item1);
                    }

                    i = innerDecodedString.Item2 - 1;
                }
                else if (s[i] == ']')
                {
                    return Tuple.Create(result.ToString(), i + 1);
                }
                else
                {
                    result.Append(s[i]);
                }
            }
            return Tuple.Create(result.ToString(), s.Length);
        }
    }
}
