using Day8.App;

namespace Day8.Tests
{
    [TestFixture]
    public class TreeVisibilityAnalyzerTests
    {
        [Test]
        public void GetNumberOfVisibleTrees_WhenTreesAreOnTheEdgeOneRow_ShouldReturnAllTrees()
        {
            var analyzer = new TreeVisibilityAnalyzer();

            var treeHeightGrid = new int[][]
            {
                new int[]{ 3, 0, 3, 7, 3 }
            };
            var visibleTrees = analyzer.GetNumberOfVisibleTrees(treeHeightGrid);

            Assert.That(visibleTrees, Is.EqualTo(5));
        }

        [Test]
        public void GetNumberOfVisibleTrees_WhenTreesAreOnTheEdgeTwoRows_ShouldReturnAllTrees()
        {
            var analyzer = new TreeVisibilityAnalyzer();

            var treeHeightGrid = new int[][]
            {
                new int[]{ 3, 0, 3, 7, 3 },
                new int[]{ 2, 5, 5, 1, 2 }
            };
            var visibleTrees = analyzer.GetNumberOfVisibleTrees(treeHeightGrid);

            Assert.That(visibleTrees, Is.EqualTo(10));
        }

        [Test]
        public void GetNumberOfVisibleTrees_WhenSomeTreesAreInsideThreeRows_ShouldReturnOnlyVisibleTress()
        {
            var analyzer = new TreeVisibilityAnalyzer();

            var treeHeightGrid = new int[][]
            {
                new int[]{ 3, 0, 3, 7, 3 },
                new int[]{ 2, 5, 5, 1, 2 },
                new int[]{ 6, 5, 3, 3, 2 }
            };
            var visibleTrees = analyzer.GetNumberOfVisibleTrees(treeHeightGrid);

            Assert.That(visibleTrees, Is.EqualTo(14));
        }

        [Test]
        public void GetNumberOfVisibleTrees_WhenSomeTreesAreInsideFiveRows_ShouldReturnOnlyVisibleTress()
        {
            var analyzer = new TreeVisibilityAnalyzer();

            var treeHeightGrid = new int[][]
            {
                new int[]{ 3, 0, 3, 7, 3 },
                new int[]{ 2, 5, 5, 1, 2 },
                new int[]{ 6, 5, 3, 3, 2 },
                new int[]{ 3, 3, 5, 4, 9 },
                new int[]{ 3, 5, 3, 9, 0 }
            };
            var visibleTrees = analyzer.GetNumberOfVisibleTrees(treeHeightGrid);

            Assert.That(visibleTrees, Is.EqualTo(21));
        }

        [Test]
        public void GetHighestScenicScore_WhenTreesAreOnTheEdgeOneRow_ShouldReturn0()
        {
            var analyzer = new TreeVisibilityAnalyzer();

            var treeHeightGrid = new int[][]
            {
                new int[]{ 3, 0, 3, 7, 3 }
            };
            var visibleTrees = analyzer.GetHighestScenicScore(treeHeightGrid);

            Assert.That(visibleTrees, Is.EqualTo(0));
        }

        [Test]
        public void GetHighestScenicScore_WhenTreesAreOnTheEdgeTwoRows_ShouldReturn0()
        {
            var analyzer = new TreeVisibilityAnalyzer();

            var treeHeightGrid = new int[][]
            {
                new int[]{ 3, 0, 3, 7, 3 },
                new int[]{ 2, 5, 5, 1, 2 }
            };
            var visibleTrees = analyzer.GetHighestScenicScore(treeHeightGrid);

            Assert.That(visibleTrees, Is.EqualTo(0));
        }

        [Test]
        public void GetHighestScenicScore_WhenSomeTreesAreInsideThreeRows_ShouldReturnHighestScore2()
        {
            var analyzer = new TreeVisibilityAnalyzer();

            var treeHeightGrid = new int[][]
            {
                new int[]{ 3, 0, 3, 7, 3 },
                new int[]{ 2, 5, 5, 1, 2 },
                new int[]{ 6, 5, 3, 3, 2 }
            };
            var visibleTrees = analyzer.GetHighestScenicScore(treeHeightGrid);

            Assert.That(visibleTrees, Is.EqualTo(2));
        }

        [Test]
        public void GetHighestScenicScore_WhenSomeTreesAreInsideFiveRows_ShouldReturnHighestScore8()
        {
            var analyzer = new TreeVisibilityAnalyzer();

            var treeHeightGrid = new int[][]
            {
                new int[]{ 3, 0, 3, 7, 3 },
                new int[]{ 2, 5, 5, 1, 2 },
                new int[]{ 6, 5, 3, 3, 2 },
                new int[]{ 3, 3, 5, 4, 9 },
                new int[]{ 3, 5, 3, 9, 0 }
            };
            var visibleTrees = analyzer.GetHighestScenicScore(treeHeightGrid);

            Assert.That(visibleTrees, Is.EqualTo(8));
        }
    }
}