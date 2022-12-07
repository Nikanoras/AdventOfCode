using Day7.App;

namespace Day7.Tests
{
    [TestFixture]
    public class FileStructureFactoryTests
    {
        [Test]
        public void CreateFromCommands_WhenlsReceived_ShouldAddChildDirectoriesAndFilesListedNext()
        {
            var fileStructureFactory = new FileStructureFactory();
            var commands = new string[]
            {
                "$ ls",
                "dir a",
                "14848514 b.txt",
                "8504156 c.dat",
                "dir d"
            };

            var workingDirectory = fileStructureFactory.CreateFromCommands(commands);
            var children = workingDirectory.GetChildren();


            Assert.That(workingDirectory, Is.TypeOf<DeviceDirectory>()); 
            Assert.That(workingDirectory.Name, Is.EqualTo("/"));

            Assert.That(children[0], Is.TypeOf<DeviceDirectory>());
            Assert.That(children[0].Name, Is.EqualTo("a"));

            Assert.That(children[1], Is.TypeOf<DeviceFile>());
            Assert.That(children[1].Name, Is.EqualTo("b.txt"));
            Assert.That(children[1].GetSize(), Is.EqualTo(14848514));

            Assert.That(children[2], Is.TypeOf<DeviceFile>());
            Assert.That(children[2].Name, Is.EqualTo("c.dat"));
            Assert.That(children[2].GetSize(), Is.EqualTo(8504156));

            Assert.That(children[3], Is.TypeOf<DeviceDirectory>());
            Assert.That(children[3].Name, Is.EqualTo("d"));
        }

        [Test]
        public void CreateFromCommands_WhencdIsReceived_ShouldSwitchToChildRectoryAndAddItemsThere()
        {
            var fileStructureFactory = new FileStructureFactory();
            var commands = new string[]
            {
                "$ ls",
                "dir a",
                "14848514 b.txt",
                "8504156 c.dat",
                "dir d",
                "$ cd a",
                "$ ls",
                "dir e"
            };

            var fileStructure = fileStructureFactory.CreateFromCommands(commands);

            DeviceDirectory workingDirectory = fileStructure.GetChildren().OfType<DeviceDirectory>().Single(d => d.Name == "a");
            var workingDirectoryChildren = workingDirectory.GetChildren();
            Assert.That(workingDirectory, Is.TypeOf<DeviceDirectory>());
            Assert.That(workingDirectory.Name, Is.EqualTo("a"));
        }

        [Test]
        public void CreateFromCommands_()
        {
            var fileStructureFactory = new FileStructureFactory();
            var commands = new string[]
            {
                "$ cd /",
                "$ ls",
                "dir a",
                "14848514 b.txt",
                "8504156 c.dat",
                "dir d",
                "$ cd a",
                "$ ls",
                "dir e",
                "29116 f",
                "2557 g",
                "62596 h.lst",
                "$ cd e",
                "$ ls",
                "584 i",
                "$ cd ..",
                "$ cd ..",
                "$ cd d",
                "$ ls",
                "4060174 j",
                "8033020 d.log",
                "5626152 d.ext",
                "7214296 k"
            };

            var fileStructure = fileStructureFactory.CreateFromCommands(commands);
            var size = fileStructure.GetSize();
            DeviceDirectory workingDirectory = fileStructure.GetChildren().OfType<DeviceDirectory>().Single(d => d.Name == "a");
            var workingDirectoryChildren = workingDirectory.GetChildren();
            Assert.That(workingDirectory, Is.TypeOf<DeviceDirectory>());
            Assert.That(workingDirectory.Name, Is.EqualTo("a"));
        }
    }
}
