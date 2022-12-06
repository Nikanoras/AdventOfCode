namespace Day6.App
{
    public class DatastreamBufferProccessor
    {
        public int GetStartOfMessageMarker(string buffer)
        {
            return GetUniqueSubstringEndIndex(buffer, 14);
        }

        public int GetStartOfThePacketMarker(string buffer)
        {
            return GetUniqueSubstringEndIndex(buffer, 4);
        }

        private static int GetUniqueSubstringEndIndex(string buffer, int substringLength)
        {
            for (int i = 0; i <= buffer.Length - substringLength; i++)
            {
                var endIndex = i + substringLength;
                var substring = buffer[i..endIndex];
                if (substring.Distinct().Count() == substring.Length)
                {
                    return endIndex;
                }
            }
            return -1;
        }
    }
}
