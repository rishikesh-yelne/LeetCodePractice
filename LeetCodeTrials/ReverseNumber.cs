using System.Text;

namespace LeetCodeTrials
{
    internal class ReverseNumber
    {
        public ReverseNumber()
        {
            Reverse(321);
            Reverse(-321);
        }
        public int Reverse(int x)
        {
            StringBuilder s = new StringBuilder();
            bool negativeFlag = true;
            if (x >= 0) negativeFlag = false;
            if (negativeFlag) x = x * -1;
            while (x != 0)
            {
                int val = x % 10;
                s.Append(val.ToString());
                x = x / 10;
            }
            int result = 0;
            try
            {
                result = Convert.ToInt32(s.ToString());
            }
            catch (Exception e)
            {
                result = 0;
            }
            result = negativeFlag ? result * -1 : result;
            return result;
        }
    }
}
