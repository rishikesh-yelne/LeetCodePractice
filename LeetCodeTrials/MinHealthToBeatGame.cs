namespace LeetCodeTrials
{
    internal class MinHealthToBeatGame
    {
        public MinHealthToBeatGame()
        {
            var result = MinimumHealth(new int[] { 2, 7, 4, 3 }, 4);
            Console.WriteLine($"Result : {result}");
        }

        public long MinimumHealth(int[] damage, int armor)
        {
            long health = 0, maxDamage = 0;
            for (int i = 0; i < damage.Length; i++)
            {
                maxDamage = Math.Max(maxDamage, (long)damage[i]);
                health += (long)damage[i];
            }
            return health + 1 - Math.Min(armor, maxDamage);
        }
    }
}
