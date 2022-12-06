using Day6.App;

var buffer = File.ReadAllText("input.txt");

var detector = new DatastreamBufferProccessor();

var startOfThePacketMarker = detector.GetStartOfThePacketMarker(buffer);
var startOfMessageMarker = detector.GetStartOfMessageMarker(buffer);

Console.WriteLine($"How many characters need to be processed before the first start-of-packet marker is detected?: {startOfThePacketMarker}");
Console.WriteLine($"How many characters need to be processed before the first start-of-message marker is detected?: {startOfMessageMarker}");
