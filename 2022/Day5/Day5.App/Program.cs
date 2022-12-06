using System.Text.RegularExpressions;

var instructions = await GetInstructionsFromATextFile();
var initialStacksOfBoxes = GetInitialStacksOfBoxes();

var part1Solution = GetPart1Solution(instructions, initialStacksOfBoxes);
Console.WriteLine(
    $"Part1: After the rearrangement procedure completes, what crate ends up on top of each stack?: {part1Solution}");

var part2Solution = GetPart2Solution(instructions, initialStacksOfBoxes);
Console.WriteLine(
    $"Part2: After the rearrangement procedure completes, what crate ends up on top of each stack?: {part2Solution}");

static string GetPart1Solution(List<string> instructions, IReadOnlyList<Stack<string>> stacksOfBoxes)
{
    foreach (var instruction in instructions)
    {
        var parsedInstruction = GetParsedInstructions(instruction);

        var moveFromStack = stacksOfBoxes[parsedInstruction.moveFromStackIndex];
        var moveToStack = stacksOfBoxes[parsedInstruction.moveToStackIndex];
        MoveBoxesBetweenStacks(moveFromStack, moveToStack, parsedInstruction.numberOfBoxes);
    }

    return GetStacksFirstItemCombinedValue(stacksOfBoxes);
}

static string GetPart2Solution(List<string> instructions, IReadOnlyList<Stack<string>> stacksOfBoxes)
{
    foreach (var instruction in instructions)
    {
        var parsedInstruction = GetParsedInstructions(instruction);

        var takeFromStack = stacksOfBoxes[parsedInstruction.moveFromStackIndex];
        var moveToStack = stacksOfBoxes[parsedInstruction.moveToStackIndex];
        var boxesToMoveStack = new Stack<string>();

        MoveBoxesBetweenStacks(takeFromStack, boxesToMoveStack, parsedInstruction.numberOfBoxes);
        MoveBoxesBetweenStacks(boxesToMoveStack, moveToStack, parsedInstruction.numberOfBoxes);
    }

    return GetStacksFirstItemCombinedValue(stacksOfBoxes);
}

static (int numberOfBoxes, int moveFromStackIndex, int moveToStackIndex) GetParsedInstructions(string instructions)
{
    var matches = Regex.Matches(instructions, @"\d+");
    var numberOfBoxes = int.Parse(matches[0].Value);
    var moveFromConvertedToIndex = int.Parse(matches[1].Value) - 1;
    var moveToConvertedToIndex = int.Parse(matches[2].Value) - 1;
    return (numberOfBoxes, moveFromConvertedToIndex, moveToConvertedToIndex);
}

static void MoveBoxesBetweenStacks(Stack<string> from, Stack<string> to, int numberOfItems)
{
    for (var i = 0; i < numberOfItems; i++)
        if (from.TryPop(out var box))
            to.Push(box);
}

static string GetStacksFirstItemCombinedValue(IEnumerable<Stack<string>> list)
{
    var enumerable = list.Select(c => c.ToList()).Where(c => c.Any()).SelectMany(c => c.First());

    return string.Join("", enumerable);
}

static List<Stack<string>> GetInitialStacksOfBoxes()
{
    return new List<Stack<string>>
    {
        new(new[] { "N", "B", "D", "T", "V", "G", "Z", "J" }),
        new(new[] { "S", "R", "M", "D", "W", "P", "F" }),
        new(new[] { "V", "C", "R", "S", "Z" }),
        new(new[] { "R", "T", "J", "Z", "P", "H", "G" }),
        new(new[] { "T", "C", "J", "N", "D", "Z", "Q", "F" }),
        new(new[] { "N", "V", "P", "W", "G", "S", "F", "M" }),
        new(new[] { "G", "C", "V", "B", "P", "Q" }),
        new(new[] { "Z", "B", "P", "N" }),
        new(new[] { "W", "P", "J" })
    };
}

static async Task<List<string>> GetInstructionsFromATextFile()
{
    var instructions = new List<string>();
    var isNotNeeded = true;
    await foreach (var instruction in File.ReadLinesAsync("input.txt"))
    {
        // Empty line separates stack information from instructions in the text file
        if (string.IsNullOrEmpty(instruction))
        {
            isNotNeeded = false;
            continue;
        }

        if (isNotNeeded) continue;
        instructions.Add(instruction);
    }

    return instructions;
}