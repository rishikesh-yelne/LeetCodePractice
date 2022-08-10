using System.Text;

namespace LeetCodeTrials
{
    public static class ListExtension
    {
        public static string ListToString(this IList<int> list)
        {
            StringBuilder text = new StringBuilder();
            foreach (var item in list)
                text.AppendLine(item.ToString());
            return text.ToString();
        }
    }
}
