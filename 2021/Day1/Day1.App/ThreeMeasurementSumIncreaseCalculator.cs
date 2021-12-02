namespace Day1.App
{
    public class ThreeMeasurementSumIncreaseCalculator
    {
        public int Calculate(int[] depthMeasurements)
        {
            var timesIncreased = 0;
            int lastSum = depthMeasurements.Take(3).Sum();
            for (int i = 1; i < depthMeasurements.Length; i++)
            {
                int[]? nextThreeMeasurements = depthMeasurements.Skip(i).Take(3).ToArray();
                
                if(nextThreeMeasurements.Length != 3)
                {
                    return timesIncreased;
                }
                
                int currentSum = nextThreeMeasurements.Sum();
                
                if(currentSum > lastSum)
                {
                    timesIncreased++;
                }

                lastSum = currentSum;
            }

            return timesIncreased;
        }
    }
}
