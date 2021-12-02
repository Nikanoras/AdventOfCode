using Day1.App;
using NUnit.Framework;

namespace Day1.Tests
{
    internal class ThreeMeasurementSumIncreaseCalculatorTests
    {
        private ThreeMeasurementSumIncreaseCalculator threeMeasurementSumIncreaseCalculator = null!;

        [SetUp]
        public void SetUp()
        {
            threeMeasurementSumIncreaseCalculator = new ThreeMeasurementSumIncreaseCalculator();
        }

        [Test]
        public void Calculate_WhenTheresOnly3Measurements_ShouldReturn0TimesIncreased()
        {
            var depthMeasurements = new[] { 199, 200, 201 };

            int timesIncreased = threeMeasurementSumIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesIncreased, Is.EqualTo(0));
        }

        [Test]
        public void Calculate_WhenTheresAnIncreaseInSumInTheNext3MeasurementsAfterTheFirstOnce_ShouldReturn1TimesIncreased()
        {
            var depthMeasurements = new[] { 199, 200, 201, 202 };

            int timesIncreased = threeMeasurementSumIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesIncreased, Is.EqualTo(1));
        }

        [Test]
        public void Calculate_WhenTheresAnIncreaseInSumInTheNext2SetsOfMeasurementsAfterTheFirstOnce_ShouldReturn2TimesIncreased()
        {
            var depthMeasurements = new[] { 199, 200, 201, 202, 203 };

            int timesIncreased = threeMeasurementSumIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesIncreased, Is.EqualTo(2));
        }

        [Test]
        public void Calculate_WhenTheresAnDecreaseAfterTwoIncrease_ShouldReturn2TimesIncreased()
        {
            var depthMeasurements = new[] { 199, 200, 201, 202, 203, 150 };

            int timesIncreased = threeMeasurementSumIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesIncreased, Is.EqualTo(2));
        }

        [Test]
        public void Calculate_WhenThereWassAnDecreaseBetweenTwoIncrease_ShouldReturn2TimesIncreased()
        {
            var depthMeasurements = new[] { 199, 200, 201, 202, 3, 500 };

            int timesIncreased = threeMeasurementSumIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesIncreased, Is.EqualTo(2));
        }

        [Test]
        public void Calculate_WhenDepthIncreasedNumberOfTimesAndDecreasedBetween_ShouldReturnExpectedNumberOfIncreasements()
        {
            var depthMeasurements = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            int timesIncreased = threeMeasurementSumIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesIncreased, Is.EqualTo(5));
        }
    }
}
