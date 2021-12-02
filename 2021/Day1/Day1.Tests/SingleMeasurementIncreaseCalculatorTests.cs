using Day1.App;
using NUnit.Framework;

namespace Day1.Tests
{
    internal class SingleMeasurementIncreaseCalculatorTests
    {
        private SingleMeasurementIncreaseCalculator singleMeasurementIncreaseCalculator = null!;

        [SetUp]
        public void SetUp()
        {
            singleMeasurementIncreaseCalculator = new SingleMeasurementIncreaseCalculator();
        }

        [Test]
        public void Calculate_WhenOnlyOneDepth_ShouldReturn0Increments()
        {
            var depthMeasurements = new[] { 199 };

            int timesDepthIncreased = singleMeasurementIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesDepthIncreased, Is.EqualTo(0));
        }

        [Test]
        public void Calculate_WhenDepthIncreasedOnce_ShouldReturn1Increment()
        {
            var depthMeasurements = new[] { 199, 200 };

            int timesDepthIncreased = singleMeasurementIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesDepthIncreased, Is.EqualTo(1));
        }

        [Test]
        public void Calculate_WhenDepthIncreasedTwice_ShouldReturn2Increments()
        {
            var depthMeasurements = new[] { 199, 200, 201 };

            int timesDepthIncreased = singleMeasurementIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesDepthIncreased, Is.EqualTo(2));
        }

        [Test]
        public void Calculate_WhenDepthIncreasedOnceAndDecreased_ShouldReturn1Increment()
        {
            var depthMeasurements = new[] { 199, 200, 199 };

            int timesDepthIncreased = singleMeasurementIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesDepthIncreased, Is.EqualTo(1));
        }

        [Test]
        public void Calculate_WhenDepthIncreasedNumberOfTimesAndDecreasedBetween_ShouldReturnExpectedNumberOfIncreasements()
        {
            var depthMeasurements = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            int timesDepthIncreased = singleMeasurementIncreaseCalculator.Calculate(depthMeasurements);

            Assert.That(timesDepthIncreased, Is.EqualTo(7));
        }
    }
}