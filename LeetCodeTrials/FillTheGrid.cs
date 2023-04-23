namespace LeetCodeTrials
{
    internal class FillTheGrid
    {
        public FillTheGrid()
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            string[] input = new string[testCases];
            for (int i = 0; i < testCases; i++)
            {
                input[i] = Console.ReadLine();
            }
            for (int i = 0; i < testCases; i++)
            {
                string[] dimensions = input[i].Split(' ');
                int m = Convert.ToInt32(dimensions[0]);
                int n = Convert.ToInt32(dimensions[1]);

                int m1 = m % 2;
                int n1 = n % 2;

                if (m1 == 0 && n1 == 0) Console.WriteLine("0");
                else if (m1 == 0 && n1 != 0) Console.WriteLine((n % 2) * m);
                else if (n1 == 0 && m1 != 0) Console.WriteLine((m % 2) * n);
                else Console.WriteLine((n % 2) * m + (m % 2) * n - 1);
            }
        }
    }
}
