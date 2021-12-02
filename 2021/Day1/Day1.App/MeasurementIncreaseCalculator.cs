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
                if (depthMeasurements.Skip(i).Take(numberOfMeasurements).Count() != numberOfMeasurements)
                {
                    return timesIncreased;
                }

                int currentSum = depthMeasurements.Skip(i).Take(numberOfMeasurements).ToArray().Sum();

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
