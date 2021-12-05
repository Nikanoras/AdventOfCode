using Day2.App;
using NUnit.Framework;

namespace Day2.Tests
{
    internal class DifferentTypeOfSteeringSubmarineTests
    {
        [Test]
        public void ShouldHaveInitialPosition0()
        {
            var submarine = new DifferentTypeOfSteeringSubmarine();

            Assert.That(submarine.Position, Is.EqualTo(0));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5_ShouldReturnPosition0()
        {
            var submarine = new DifferentTypeOfSteeringSubmarine();

            submarine.TakeDirections(new[] { "forward 5" });

            Assert.That(submarine.Position, Is.EqualTo(0));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5Down5_ShouldReturnPosition0()
        {
            var submarine = new DifferentTypeOfSteeringSubmarine();

            submarine.TakeDirections(new[] { "forward 5", "down 5" });

            Assert.That(submarine.Position, Is.EqualTo(0));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5Down5Forward8_ShouldReturnPosition520()
        {
            var submarine = new DifferentTypeOfSteeringSubmarine();

            submarine.TakeDirections(new[] { "forward 5", "down 5", "forward 8" });

            Assert.That(submarine.Position, Is.EqualTo(520));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5Down5Forward8Up3_ShouldReturnPosition520()
        {
            var submarine = new DifferentTypeOfSteeringSubmarine();

            submarine.TakeDirections(new[] { "forward 5", "down 5", "forward 8", "up 3" });

            Assert.That(submarine.Position, Is.EqualTo(520));
        }

        [Test]
        public void TakeDirections_WhenCommandIsFoward5Down5Forward8Up3Down8_ShouldReturnPosition520()
        {
            var submarine = new DifferentTypeOfSteeringSubmarine();

            submarine.TakeDirections(new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8" });

            Assert.That(submarine.Position, Is.EqualTo(520));
        }

        [Test]
        public void TakeDirections_WhenUsingMixedCommands_ShouldReturnTheCorrectPosition()
        {
            var submarine = new DifferentTypeOfSteeringSubmarine();

            submarine.TakeDirections(new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" });

            Assert.That(submarine.Position, Is.EqualTo(900));
        }
    }
}
