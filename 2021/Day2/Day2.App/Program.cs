using Day2.App;
var depthMeasurements = await File.ReadAllLinesAsync("./input.txt");

Console.WriteLine("What do you get if you multiply your final horizontal position by your final depth?");
var submarine = new Submarine();
submarine.TakeDirections(depthMeasurements);
Console.WriteLine($"Answer: {submarine.Position}");

Console.WriteLine("What do you get if you multiply your final horizontal position by your final depth?");
var differentSubmarine = new DifferentTypeOfSteeringSubmarine();
differentSubmarine.TakeDirections(depthMeasurements);
Console.WriteLine($"Answer: {differentSubmarine.Position}");