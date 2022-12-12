using Day8.App;

var treeHeightLines = File.ReadAllLines("input.txt");

var treeHeightGrid = new int[treeHeightLines.Length][];
for (int i = 0; i < treeHeightLines.Length; i++)
{
    var split = treeHeightLines[i].ToCharArray();
    treeHeightGrid[i] = split.Select(c => int.Parse(c.ToString())).ToArray();
}

var analyzer = new TreeVisibilityAnalyzer();

var numberOfVisibleTrees = analyzer.GetNumberOfVisibleTrees(treeHeightGrid);

Console.WriteLine($"How many trees are visible from outside the grid?: {numberOfVisibleTrees}");

var highestScenicScore = analyzer.GetHighestScenicScore(treeHeightGrid);

Console.WriteLine($"What is the highest scenic score possible for any tree? {highestScenicScore}");
