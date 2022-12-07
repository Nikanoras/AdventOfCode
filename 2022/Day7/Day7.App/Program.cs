using Day7.App;

string[] commandsAndOutputs = File.ReadAllLines("input.txt");

var factory = new FileStructureFactory();

DeviceDirectory deviceDirectory = factory.CreateFromCommands(commandsAndOutputs);

var belowThresholdDirectorySizes = new List<long>();
GetBelowThresholdDirectorySizes(deviceDirectory, belowThresholdDirectorySizes, 100000);

Console.WriteLine($"Find all of the directories with a total size of at most 100000. What is the sum of the total sizes of those directories?: {belowThresholdDirectorySizes.Sum()}");

var aboveThresholdDirectorySizes = new List<long>();
var neededSpace = 30000000 - (70000000 - deviceDirectory.GetSize());
GetAboveThresholdDirectorySizes(deviceDirectory, aboveThresholdDirectorySizes, neededSpace);

Console.WriteLine($"Find the smallest directory that, if deleted, would free up enough space on the filesystem to run the update. What is the total size of that directory?: {aboveThresholdDirectorySizes.Order().First()}");

static void GetBelowThresholdDirectorySizes(DeviceDirectory currentDirectory, List<long> result, long threshold)
{
    var directorysize = currentDirectory.GetSize();
    if (directorysize <= threshold)
    {
        result.Add(directorysize);
    }
    foreach (var children in currentDirectory.GetChildren())
    {
        if (children is DeviceDirectory directory)
        {
            GetBelowThresholdDirectorySizes(directory, result, threshold);
        }
    }
}

static void GetAboveThresholdDirectorySizes(DeviceDirectory currentDirectory, List<long> result, long threshold)
{
    var directorysize = currentDirectory.GetSize();
    if (directorysize >= threshold)
    {
        result.Add(directorysize);
    }
    foreach (var children in currentDirectory.GetChildren())
    {
        if (children is DeviceDirectory directory)
        {
            GetAboveThresholdDirectorySizes(directory, result, threshold);
        }
    }
}
