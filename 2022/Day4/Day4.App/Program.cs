string[] elfPairs = File.ReadAllLines("input.txt");
var firstCount = 0;
var secondCount = 0;
foreach (var elfPair in elfPairs)
{
    string[] assignments = elfPair.Split(",");
    var firstElfAssignment = GetAssignmentStartAndEndSectionIds(assignments[0]);
    var secondElfAssignment = GetAssignmentStartAndEndSectionIds(assignments[1]);

    var smallestSectionId = Math.Min(firstElfAssignment.startSectionId, secondElfAssignment.startSectionId);
    var largestSectionId = Math.Max(firstElfAssignment.endSectionId, secondElfAssignment.endSectionId);

    var hasFirstLowestSectionId = smallestSectionId == firstElfAssignment.startSectionId;
    var hasSecondLowestSectionId = smallestSectionId == secondElfAssignment.startSectionId;

    if (hasFirstLowestSectionId && largestSectionId == firstElfAssignment.endSectionId)
    {
        firstCount++;
    }
    else if (hasSecondLowestSectionId && largestSectionId == secondElfAssignment.endSectionId)
    {
        firstCount++;
    }

    if (hasFirstLowestSectionId && secondElfAssignment.startSectionId <= firstElfAssignment.endSectionId)
    {
        secondCount++;
    }
    else if (hasSecondLowestSectionId && firstElfAssignment.startSectionId <= secondElfAssignment.endSectionId)
    {
        secondCount++;
    }
}

Console.WriteLine($"In how many assignment pairs does one range fully contain the other?: {firstCount}");
Console.WriteLine($"In how many assignment pairs do the ranges overlap?: {secondCount}");


static (int startSectionId, int endSectionId) GetAssignmentStartAndEndSectionIds(string assignment)
{
    var splitRange = assignment.Split("-");

    return (int.Parse(splitRange[0]), int.Parse(splitRange[1]));
}