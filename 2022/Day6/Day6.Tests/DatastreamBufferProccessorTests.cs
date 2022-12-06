using Day6.App;

namespace Day6.Tests
{
    [TestFixture]
    public class DatastreamBufferProccessorTests
    {
        [Test]
        public void GetStartOfThePacketMarker_WhenAllUniqueLetters_ShouldReturnTheIndexOfStart()
        {
            var detector = new DatastreamBufferProccessor();

            var firstMarkerIndex = detector.GetStartOfThePacketMarker("abcd");

            Assert.That(firstMarkerIndex, Is.EqualTo(4));
        }

        [Test]
        public void GetStartOfThePacketMarker_WhenAllUniqueLetters_ShouldReturnMinus1()
        {
            var detector = new DatastreamBufferProccessor();

            var firstMarkerIndex = detector.GetStartOfThePacketMarker("abca");

            Assert.That(firstMarkerIndex, Is.EqualTo(-1));
        }

        [Test]
        public void GetStartOfThePacketMarker_WhenUniqueLettersAreNotAtTheStart_ShouldReturnTheIndexOfEndOfUnique()
        {
            var detector = new DatastreamBufferProccessor();

            var firstMarkerIndex = detector.GetStartOfThePacketMarker("aabcd");

            Assert.That(firstMarkerIndex, Is.EqualTo(5));
        }

        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void GetStartOfThePacketMarker_ShouldReturnExpectedResult(string buffer, int expectedIndex)
        {
            var detector = new DatastreamBufferProccessor();

            var firstMarkerIndex = detector.GetStartOfThePacketMarker(buffer);

            Assert.That(firstMarkerIndex, Is.EqualTo(expectedIndex));
        }

        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void GetStartOfMessageMarker_ShouldReturnExpectedResult(string buffer, int expectedIndex)
        {
            var detector = new DatastreamBufferProccessor();

            var firstMarkerIndex = detector.GetStartOfMessageMarker(buffer);

            Assert.That(firstMarkerIndex, Is.EqualTo(expectedIndex));
        }
    }
}
