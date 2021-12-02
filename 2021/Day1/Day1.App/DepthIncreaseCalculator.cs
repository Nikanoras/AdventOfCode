namespace Day1.App
{
    public class DepthIncreaseCalculator
    {
        public int CalculateTimesDepthIncreased(int[] depthMeasurements)
        {
            var depth = 0;
            var lastMeasurement = depthMeasurements.FirstOrDefault();
            foreach (var measurement in depthMeasurements.Skip(1))
            {
                if (measurement > lastMeasurement)
                {
                    depth++;
                }

                lastMeasurement = measurement;
            }
            return depth;
        }
    }
}