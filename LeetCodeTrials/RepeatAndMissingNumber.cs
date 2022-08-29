namespace LeetCodeTrials
{
    internal class RepeatAndMissingNumber
    {
        public RepeatAndMissingNumber()
        {
            var result = RepeatedNumber(new List<int>() { 3, 1, 2, 5, 3 });
            Console.WriteLine($"Result: {result.ListToString()}");
        }
        public List<int> RepeatedNumber(List<int> A)
        {
            ulong sum = 0;
            ulong seriesSum = (ulong)A.Count * (ulong)(A.Count + 1) / 2;
            ulong sumOfSquares = 0;
            ulong seriesSumOfSquares = (ulong)A.Count * (ulong)(A.Count + 1) * (ulong)(2 * A.Count + 1) / 6;
            for (int i = 0; i < A.Count; i++)
            {
                sum += (ulong)A[i];
                sumOfSquares += (ulong)A[i] * (ulong)A[i];
            }
            bool flag = seriesSum > sum;
            ulong diff = seriesSum > sum ? seriesSum - sum : sum - seriesSum;
            ulong diffOfSquares = seriesSumOfSquares > sumOfSquares ? seriesSumOfSquares - sumOfSquares : sumOfSquares - seriesSumOfSquares;
            ulong sumOfAnswer = diffOfSquares / diff;
            ulong missingElement = (diff + sumOfAnswer) / 2;
            ulong repeatElement = sumOfAnswer - missingElement;
            List<int> answer = new List<int>() { (int)(repeatElement), (int)(missingElement) };
            if (!flag) answer.Reverse();
            return answer;
        }
    }
}
