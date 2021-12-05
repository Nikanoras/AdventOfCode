using Day2.App;
string[]? directions = await File.ReadAllLinesAsync("./input.txt");

Console.WriteLine("What do you get if you multiply your final horizontal position by your final depth?");
var oneDirectionCoursePlanner = new SubmarineCoursePlanner(new OneDirectionCourseCalculationStrategy());
oneDirectionCoursePlanner.CalculateFinalPosition(directions);
Console.WriteLine($"Answer: {oneDirectionCoursePlanner.Position}");

Console.WriteLine("What do you get if you multiply your final horizontal position by your final depth?");
var biDirectionalCoursePlanner = new SubmarineCoursePlanner(new BiDirectionalCourseCalculationStrategy());
biDirectionalCoursePlanner.CalculateFinalPosition(directions);
Console.WriteLine($"Answer: {biDirectionalCoursePlanner.Position}");