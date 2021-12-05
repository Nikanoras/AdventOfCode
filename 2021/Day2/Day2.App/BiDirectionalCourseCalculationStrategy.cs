namespace Day2.App
{
    public class BiDirectionalCourseCalculationStrategy : CourseCalculationStrategy
    {
        public override int CalculateFinalPosition(string[] directions)
        {
            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;
            foreach (string? direction in directions)
            {
                (var command, var position) = ParseDirection(direction);
                if (command == "forward")
                {
                    horizontalPosition += position;
                    depth += aim * position;
                }
                else if (command == "down")
                {
                    aim += position;
                }
                else
                {
                    aim -= position;
                }

            }
            return depth * horizontalPosition;
        }
    }
}
