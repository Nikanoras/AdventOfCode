namespace Day2.App
{
    public class OneDirectionCourseCalculationStrategy : CourseCalculationStrategy
    {
        public override int CalculateFinalPosition(string[] directions)
        {
            int horizontalPosition = 0;
            int depth = 0;
            foreach (string? direction in directions)
            {
                (var command, var position) = ParseDirection(direction);
                if (command == "forward")
                {
                    horizontalPosition += position;

                }
                else if (command == "down")
                {
                    depth += position;
                }
                else
                {
                    depth -= position;
                }

            }
            return depth * horizontalPosition;
        }
    }
}
