var unclearInstructions = File.ReadAllLines("./input.txt");

// var unclearInstructions = new[]
// {
//     "two1nine",
//     "eightwothree",
//     "abcone2threexyz",
//     "xtwone3four",
//     "4nineeightseven2",
//     "zoneight234",
//     "7pqrstsixteen"
// };

var result = 0;
var numbers = new Dictionary<string, string>
{
    { "one", "1" },
    { "two", "2" },
    { "three", "3" },
    { "four", "4" },
    { "five", "5" },
    { "six", "6" },
    { "seven", "7" },
    { "eight", "8" },
    { "nine", "9" }
};

foreach (var instruction in unclearInstructions)
{
    var digitizedInstruction = instruction;

    for (var i = 0; i < digitizedInstruction.Length; i++)
    {
        foreach (var number in numbers)
        {
            if (digitizedInstruction[i..].StartsWith(number.Key))
            {
                digitizedInstruction = digitizedInstruction.Replace(number.Key, number.Value);
            }
        }
    }
    
    char? firsDigit = null;
    char? lastDigit = null;

    foreach (var c in digitizedInstruction)
    {
        if (!char.IsDigit(c))
        {
            continue;
        }

        firsDigit ??= c;

        lastDigit = c;
    }

    var calibrationValue = new string(new[] { firsDigit!.Value, lastDigit!.Value });

    result += int.Parse(calibrationValue);
}

Console.WriteLine(result);