namespace Day2.App
{
    public abstract class CourseCalculationStrategy
    {
        public abstract int CalculateFinalPosition(string[] directions);

        protected static (string command, int position) ParseDirection(string direction)
        {
            string[] instructions = direction.Split(" ");
            return (instructions[0], int.Parse(instructions[1]));
        }
    }
}
