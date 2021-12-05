namespace Day2.App
{
    public sealed class Submarine
    {
        public int Position { get; private set; }

        public void TakeDirections(string[] directions)
        {
            var horizontalPosition = 0;
            var verticalPosition = 0;
            foreach (var direction in directions)
            {
                string[] instructions = direction.Split(" ");
                int position = int.Parse(instructions[1]);
                string? command = instructions[0];
                if (command == "forward")
                {
                    horizontalPosition += position;

                }
                else if (command == "down")
                {
                    verticalPosition += position;
                }
                else
                {
                    verticalPosition -= position;
                }

            }
            Position = verticalPosition * horizontalPosition;
        }
    }
}