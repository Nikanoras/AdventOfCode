var calories = File.ReadAllLines("./input.txt");
var eachElfSummedCalories = new SortedSet<int>();
var currentElfCalorieSum = 0;
foreach (var calorie in calories)
{
    if (int.TryParse(calorie, out var parsedCalorie))
    {
        currentElfCalorieSum += parsedCalorie;
    }
    else
    {
        eachElfSummedCalories.Add(currentElfCalorieSum);
        currentElfCalorieSum = 0;
    }
}

Console.WriteLine($"Top 1 sum of calories carried by elf: {eachElfSummedCalories.Last()}");
Console.WriteLine($"Top 3 sum of calories carried by elfs summed: {eachElfSummedCalories.TakeLast(3).Sum()}");
