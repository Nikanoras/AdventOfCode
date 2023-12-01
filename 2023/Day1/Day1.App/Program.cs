var unclearInstructions = File.ReadAllLines("./input.txt");

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
    char? firsDigit = null;
    char? lastDigit = null;

    for (var i = 0; i < instruction.Length; i++)
    {
        var c = instruction[i];
        if (char.IsDigit(c))
        {
            firsDigit = c;
        }
        else
        {
            foreach (var number in numbers)
            {
                if (instruction[i..].StartsWith(number.Key))
                {
                    firsDigit = char.Parse(number.Value);
                    break;
                }
            }
        }

        if (firsDigit.HasValue)
        {
            break;
        }
    }

    for (var i = instruction.Length - 1; i >= 0; i--)
    {
        var c = instruction[i];
        if (char.IsDigit(c))
        {
            lastDigit = c;
        }
        else
        {
            foreach (var number in numbers)
            {
                var range = new Range(0, i + 1);
                if (instruction[range].EndsWith(number.Key))
                {
                    lastDigit = char.Parse(number.Value);
                    break;
                }
            }
        }

        if (lastDigit.HasValue)
        {
            break;
        }
    }

    var calibrationValue = new string(new[] { firsDigit!.Value, lastDigit!.Value });

    result += int.Parse(calibrationValue);
}

Console.WriteLine(result);