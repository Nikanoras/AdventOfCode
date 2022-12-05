var ruckSacks = File.ReadAllLines("input.txt");

var firstResult = 0;
foreach (var ruckSackItems in ruckSacks)
{
    var halfLength = ruckSackItems.Length / 2;
    var firstCompartment = ruckSackItems[0..halfLength].ToCharArray();
    var secondCompartment = ruckSackItems[halfLength..ruckSackItems.Length].ToCharArray();

    var sameChars = GetDistinctCharsBetweenArrays(firstCompartment, secondCompartment);
    firstResult += ConvertCharsToPriorityPoints(sameChars);
}
Console.WriteLine(firstResult);

var secondResult = 0;
for (var i = 2; i < ruckSacks.Length; i += 3)
{
    var firstElfRucksack = ruckSacks[i - 2].ToCharArray();
    var secondElfRucksack = ruckSacks[i - 1].ToCharArray();
    var thirdElfRucksack = ruckSacks[i].ToCharArray();

    var sameChars = GetDistinctCharsBetweenArrays(firstElfRucksack, secondElfRucksack, thirdElfRucksack);
    secondResult += ConvertCharsToPriorityPoints(sameChars);
}
Console.WriteLine(secondResult);

static int ConvertCharsToPriorityPoints(IEnumerable<char> sameChars)
{
    return sameChars.Select(c => char.IsUpper(c) ? c - 38 : c - 96).Sum();
}

static IEnumerable<char> GetDistinctCharsBetweenArrays(params char[][] charArrays)
{
    if (!charArrays.Any())
    {
        throw new ArgumentException("No chars passed");
    }

    var compareTo = charArrays[0].AsEnumerable();

    foreach (var item in charArrays.Skip(1))
    {
        compareTo = compareTo.Where(c => item.Contains(c));
    }

    var result = compareTo.Distinct().ToList();
    return result;
}

