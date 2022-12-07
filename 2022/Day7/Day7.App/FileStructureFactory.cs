namespace Day7.App
{
    public class FileStructureFactory
    {
        public DeviceDirectory CreateFromCommands(string[] inputs)
        {
            var toplevelDirectory = new DeviceDirectory("/", null);
            DeviceDirectory currentDirectory = toplevelDirectory;
            foreach (var input in inputs)
            {
                var parameters = input.Split(" ");
                if ("$ ls".Equals(input))
                {
                    continue;
                }
                else if (input.Contains("$ cd"))
                {
                    var directoryName = parameters[2];
                    if (directoryName == "/")
                    {
                        currentDirectory = toplevelDirectory;
                    }
                    else if (directoryName == "..")
                    {
                        currentDirectory = (DeviceDirectory)currentDirectory!.Parent!;
                    }
                    else
                    {
                        currentDirectory = currentDirectory.GetChildren().OfType<DeviceDirectory>().Single(c => c.Name == directoryName);
                    }
                }
                else
                {
                    string name = parameters[1];

                    if (input.StartsWith("dir"))
                    {
                        currentDirectory.AddChild(new DeviceDirectory(name, currentDirectory));
                    }
                    else
                    {
                        var file = new DeviceFile(name, long.Parse(parameters[0]), currentDirectory);
                        currentDirectory.AddChild(file);
                    }
                }
            }

            return toplevelDirectory;
        }
    }
}
