using Day1.App;

var depthMeasurements = File.ReadAllLines("./input.txt").Select(d => int.Parse(d)).ToArray();

var depthIncreaseCalculator = new DepthIncreaseCalculator();

int timesDepthIncreased = depthIncreaseCalculator.CalculateTimesDepthIncreased(depthMeasurements);

Console.WriteLine($"How many measurements are larger than the previous measurement?");
Console.WriteLine($"{timesDepthIncreased} times");
