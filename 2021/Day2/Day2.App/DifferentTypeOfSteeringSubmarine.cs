namespace Day2.App
{
    public class DifferentTypeOfSteeringSubmarine
    {
        public int Position { get; private set; }

        public void TakeDirections(string[] directions)
        {
            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;
            foreach (var direction in directions)
            {
                string[] instructions = direction.Split(" ");
                int position = int.Parse(instructions[1]);
                string? command = instructions[0];
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
            Position = depth * horizontalPosition;
        }
    }
}
