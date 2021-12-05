namespace Day2.App
{
    public sealed class SubmarineCoursePlanner
    {
        private readonly CourseCalculationStrategy courseCalculationStrategy;

        public SubmarineCoursePlanner(CourseCalculationStrategy courseCalculationStrategy)
        {
            this.courseCalculationStrategy = courseCalculationStrategy;
        }

        public int Position { get; private set; }

        public void CalculateFinalPosition(string[] directions)
        {
            Position = courseCalculationStrategy.CalculateFinalPosition(directions);
        }
    }
}