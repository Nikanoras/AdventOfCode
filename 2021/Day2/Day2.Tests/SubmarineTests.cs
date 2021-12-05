using Day2.App;
using NUnit.Framework;

namespace Day2.Tests
{
    public class SubmarineTests
    {
        private Submarine submarine = null!;
        [SetUp]
        public void Setup()
        {
            submarine = new Submarine();
        }

        [Test]
        public void ShouldHaveInitialPositionAt0()
        {
            Assert.That(submarine.Position, Is.EqualTo(0));
        }

        [Test]
        public void TakeDirections_WhenDirectionIsForward5AndDown5_ShouldSetPositionTo25()
        {
            submarine.TakeDirections(new[] { "forward 5", "down 5" });

            Assert.That(submarine.Position, Is.EqualTo(25));
        }

        [Test]
        public void TakeDirections_WhenDirectionIsForward5AndDown10_ShouldSetPositionTo25()
        {
            submarine.TakeDirections(new[] { "forward 5", "down 10" });

            Assert.That(submarine.Position, Is.EqualTo(50));
        }

        [Test]
        public void TakeDirections_WhenDirectionIsForward5AndUp5_ShouldSetPositionToMinus25()
        {
            submarine.TakeDirections(new[] { "forward 5", "up 10" });

            Assert.That(submarine.Position, Is.EqualTo(-50));
        }

        [Test]
        public void TakeDirections_WhenProvidedMixedDirection_ShouldSetCorrectPosition()
        {
            submarine.TakeDirections(new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" });

            Assert.That(submarine.Position, Is.EqualTo(150));
        }
    }
}