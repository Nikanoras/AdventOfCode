namespace Day1.App
{
    public abstract class MeasurementIncreaseCalculator
    {
        private readonly int numberOfMeasurements;

        protected MeasurementIncreaseCalculator(int numberOfMeasurements)
        {
            this.numberOfMeasurements = numberOfMeasurements;
        }

        public int Calculate(int[] depthMeasurements)
        {
            var timesIncreased = 0;
            int lastSum = depthMeasurements.Take(numberOfMeasurements).Sum();
            for (int i = 1; i < depthMeasurements.Length; i++)
            {
                int[] currentMeasurements = depthMeasurements.Skip(i).Take(numberOfMeasurements).ToArray();
                
                if (currentMeasurements.Length != numberOfMeasurements)
                {
                    return timesIncreased;
                }

                int currentSum = currentMeasurements.Sum();

                if (currentSum > lastSum)
                {
                    timesIncreased++;
                }

                lastSum = currentSum;
            }

            return timesIncreased;
        }
    }
}
