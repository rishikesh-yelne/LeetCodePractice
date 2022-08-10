using System.Text;

namespace LeetCodeTrials
{
    internal class GenerateParenthesis
    {
        public GenerateParenthesis()
        {
            var result = Generate(3);
            Console.WriteLine($"Result : {ToString(result.ToList())}");
        }
        public string ToString(List<string> input)
        {
            var inputList = input.Select(x => $"\"{x}\"").ToList();
            return string.Join(",", inputList);
        }

        public IList<string> Generate(int n)
        {
            List<string> result = new List<string>();
            BacktrackSoln(result, new StringBuilder(), 0, 0, n);
            return result;
        }

        private void BacktrackSoln(List<string> result, StringBuilder currentValue, int openCount, int closeCount, int max)
        {
            if (currentValue.Length == 2 * max)
            {
                result.Add(currentValue.ToString());
                return;
            }

            if (openCount < max)
            {
                currentValue.Append("(");
                BacktrackSoln(result, currentValue, openCount + 1, closeCount, max);
                currentValue.Remove(currentValue.Length - 1, 1);
            }

            if (closeCount < openCount)
            {
                currentValue.Append(")");
                BacktrackSoln(result, currentValue, openCount, closeCount + 1, max);
                currentValue.Remove(currentValue.Length - 1, 1);
            }
        }
    }
}
