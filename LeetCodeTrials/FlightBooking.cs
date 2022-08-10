namespace LeetCodeTrials
{
    internal class FlightBooking
    {
        public FlightBooking()
        {
            CorpFlightBookings(new int[][] { new int[] { 1, 2, 10 }, new int[] { 2, 3, 20 }, new int[] { 2, 5, 25 } }, 5);
        }

        public int[] CorpFlightBookings(int[][] bookings, int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < bookings.Length; i++)
            {
                var booking = bookings[i];
                for (int j = booking[0] - 1; j < booking[1]; j++)
                {
                    result[j] += booking[2];
                }
            }
            return result;
        }
    }
}
