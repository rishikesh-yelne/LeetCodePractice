namespace LeetCodeTrials
{
    internal class ExcelSheetColumnNumber
    {
        public ExcelSheetColumnNumber()
        {
            Console.WriteLine(TitleToNumber("A"));
            Console.WriteLine(TitleToNumber("AB"));
            Console.WriteLine(TitleToNumber("ZY"));
            Console.WriteLine(TitleToNumber("FXSHRXW"));
        }

        public int TitleToNumber(string columnTitle)
        {
            int column = 0;
            int inc = 0;
            for (int i = columnTitle.Length - 1; i >= 0; i--)
            {
                int asciiValue = Convert.ToInt32(columnTitle[i]) - 64;
                column += ((int)Math.Pow(26, inc) * asciiValue);
                inc++;
            }
            Console.WriteLine(column);
            return column;
        }
    }
}
