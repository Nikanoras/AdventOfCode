var inputs = File.ReadAllLines("input.txt");

var myPart1Score = 0;
var myPart2Score = 0;
var part1RoundScoreCalculator = new Part1RpsRoundScoreCalculator();
var part2RoundScoreCalculator = new Part2RpsRoundScoreCalculator();

foreach (var round in inputs)
{
    var shapes = round.Split();
    var opponentShape = ParseInputAndReturnShape(shapes[0]);
    var myShape = ParseInputAndReturnShape(shapes[1]);

    myPart1Score += part1RoundScoreCalculator.GetMyScore(opponentShape, myShape);
    myPart2Score += part2RoundScoreCalculator.GetMyScore(opponentShape, myShape);
}

Console.WriteLine($"My part 1 score is: {myPart1Score}");
Console.WriteLine($"My part 2 score is: {myPart2Score}");

static Shape ParseInputAndReturnShape(string value)
{
    return value switch
    {
        "A" or "X" => new Rock(),
        "B" or "Y" => new Paper(),
        "C" or "Z" => new Scissors(),
        _ => throw new ArgumentOutOfRangeException(nameof(value), "Invalid shape"),
    };
}
