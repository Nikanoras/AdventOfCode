using Day2.App;
using NUnit.Framework;

namespace Day2.Tests
{
    internal class BiDirectionalCourseCalculationStrategyTests
    {
        private SubmarineCoursePlanner submarine = null!;

        [SetUp]
        public void SetUp()
        {
            submarine = new SubmarineCoursePlanner(new BiDirectionalCourseCalculationStrategy());
        }

        [Test]
        public void ShouldHaveInitialPosition0()
        {

            Assert.That(submarine.Position, Is.EqualTo(0));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5_ShouldReturnPosition0()
        {
            submarine.CalculateFinalPosition(new[] { "forward 5" });

            Assert.That(submarine.Position, Is.EqualTo(0));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5Down5_ShouldReturnPosition0()
        {
            submarine.CalculateFinalPosition(new[] { "forward 5", "down 5" });

            Assert.That(submarine.Position, Is.EqualTo(0));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5Down5Forward8_ShouldReturnPosition520()
        {
            submarine.CalculateFinalPosition(new[] { "forward 5", "down 5", "forward 8" });

            Assert.That(submarine.Position, Is.EqualTo(520));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5Down5Forward8Up3_ShouldReturnPosition520()
        {
            submarine.CalculateFinalPosition(new[] { "forward 5", "down 5", "forward 8", "up 3" });

            Assert.That(submarine.Position, Is.EqualTo(520));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5Down5Forward8Up3Down8_ShouldReturnPosition520()
        {
            submarine.CalculateFinalPosition(new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8" });

            Assert.That(submarine.Position, Is.EqualTo(520));
        }

        [Test]
        public void TakeDirections_WhenUsingMixedCommands_ShouldReturnTheCorrectPosition()
        {
            submarine.CalculateFinalPosition(new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" });

            Assert.That(submarine.Position, Is.EqualTo(900));
        }
    }
}
