using System.Text;

namespace LeetCodeTrials
{
    internal class ZigZagConversion
    {
        public ZigZagConversion()
        {
            Convert("PAYPALISHIRING", 3);
            Convert("PAYPALISHIRING", 4);
        }
        public string Convert(string s, int numRows)
        {
            StringBuilder result = new StringBuilder();
            int zigzagLength = numRows * 2 - 2;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (j % zigzagLength == i)
                    {
                        result.Append(s[j]);
                    }
                    else if (j % zigzagLength >= numRows && (j + i) % zigzagLength == 0)
                    {
                        result.Append(s[j]);
                    }
                }
            }
            return result.ToString();
        }
    }
}
