namespace LeetCodeTrials
{
    internal class PascalTriangle
    {
        public PascalTriangle()
        {
            var result = Generate(5);
        }
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> pascalTriangle = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                List<int> row = new List<int>();
                if (pascalTriangle.Count > 0)
                {
                    IList<int> earlierRow = pascalTriangle[i - 1];
                    row.Add(earlierRow[0]);
                    for (int j = 1; j < earlierRow.Count; j++)
                    {
                        row.Add(earlierRow[j - 1] + earlierRow[j]);
                    }
                    row.Add(earlierRow[earlierRow.Count - 1]);
                    pascalTriangle.Add(row);
                }
                else
                {
                    row.Add(1);
                    pascalTriangle.Add(row);
                }
            }
            return pascalTriangle;

            /*
            if (numRows == 1) return new List<IList<int>>() { new List<int>() { 1 } };
            if (numRows == 2) return new List<IList<int>>() { new List<int>() { 1 }, new List<int>() { 1, 1 } };
            List<IList<int>> result = new List<IList<int>>() { new List<int>() { 1 }, new List<int>() { 1, 1 } };
            int i = 2;
            while (i < numRows)
            {
                List<int> row = new List<int>() { 1 };
                List<int> lastRow = result.Last().ToList();
                for(int j = 1; j < lastRow.Count; j++)
                {
                    row.Add(lastRow[j-1] + lastRow[j]);
                }
                row.Add(1);
                result.Add(row);
                i++;
            }
            return result;
            */
        }
    }
}
