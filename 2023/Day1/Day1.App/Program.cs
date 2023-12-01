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
    var index = 0;
    char? firsDigit = null;
    char? lastDigit = null;

    var loop = true;
    while (loop)
    {
        var manipulateIndex = true;
        var c = instruction[index];

        if (char.IsDigit(c) && !firsDigit.HasValue)
        {
            firsDigit = c;
            index = instruction.Length - 1;
            continue;
        }

        if (char.IsDigit(c) && !lastDigit.HasValue)
        {
            lastDigit = c;
            break;
        }

        foreach (var number in numbers)
        {
            if (!char.IsDigit(c))
            {
                var endIndex = index + 1;
                if (!firsDigit.HasValue && instruction[index..].StartsWith(number.Key))
                {
                    firsDigit = char.Parse(number.Value);
                    index = instruction.Length - 1;
                    manipulateIndex = false;
                    break;
                }
                else if (!lastDigit.HasValue && instruction[..endIndex].EndsWith(number.Key))
                {
                    lastDigit = char.Parse(number.Value);
                    loop = false;
                    break;
                }
            }
        }

        if (manipulateIndex)
        {
            if (!firsDigit.HasValue)
            {
                index++;
            }
            else
            {
                index--;
            }
        }
    }

    var calibrationValue = new string(new[] { firsDigit!.Value, lastDigit!.Value });

    result += int.Parse(calibrationValue);
}

Console.WriteLine(result);