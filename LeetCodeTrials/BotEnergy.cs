namespace LeetCodeTrials
{
    internal class BotEnergy
    {
        public BotEnergy()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine();
            int[] arr = input!.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            Console.WriteLine(chiefHopper(arr));
        }

        public int chiefHopper(int[] arr)
        {
            int low = 0;
            int high = int.MaxValue; // can be sum of all elements of arr
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                bool check = checkIfEnergySuffices(arr, mid);
                if (check)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low;
        }

        private bool checkIfEnergySuffices(int[] arr, int botEnergy)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                if (botEnergy > arr[i]) botEnergy = botEnergy + (botEnergy - arr[i]);
                else botEnergy = botEnergy - (arr[i] - botEnergy);
                if (botEnergy < 0) return false;
            }
            return true;
        }
    }
}
