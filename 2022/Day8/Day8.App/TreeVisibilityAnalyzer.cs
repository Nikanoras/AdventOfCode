namespace Day8.App
{
    public class TreeVisibilityAnalyzer
    {
        public int GetNumberOfVisibleTrees(int[][] treeHeightGrid)
        {
            var visibleTreeCount = 0;

            for (int i = 0; i < treeHeightGrid.Length; i++)
            {
                if (i == 0 || i == treeHeightGrid.Length - 1)
                {
                    visibleTreeCount += treeHeightGrid[i].Length;
                    continue;
                }
                for (int j = 0; j < treeHeightGrid[i].Length; j++)
                {
                    if (j == 0 || j == treeHeightGrid[i].Length - 1)
                    {
                        visibleTreeCount++;
                        continue;
                    }

                    var currentTreeHeight = treeHeightGrid[i][j];
                    int highestTopTreeHeight = treeHeightGrid.Take(i).Select(x => x[j]).Max();
                    int highestRightTreeHeight = treeHeightGrid[i].Skip(j + 1).Max();
                    int highestBottomTreeHeight = treeHeightGrid.Skip(i + 1).Select(x => x[j]).Max();
                    int highestLeftTreeHeight = treeHeightGrid[i].Take(j).Max();
                    if (currentTreeHeight > highestTopTreeHeight || currentTreeHeight > highestRightTreeHeight || currentTreeHeight > highestBottomTreeHeight || currentTreeHeight > highestLeftTreeHeight)
                    {
                        visibleTreeCount++;
                    }
                }
            }
            return visibleTreeCount;
        }

        public int GetHighestScenicScore(int[][] treeHeightGrid)
        {
            var highestScenicScore = 0;

            for (int i = 0; i < treeHeightGrid.Length; i++)
            {
                if (i == 0 || i == treeHeightGrid.Length - 1)
                {
                    continue;
                }
                for (int j = 0; j < treeHeightGrid[i].Length; j++)
                {
                    if (j == 0 || j == treeHeightGrid[i].Length - 1)
                    {
                        continue;
                    }

                    var currentTreeHeight = treeHeightGrid[i][j];

                    var topTreeHeights = treeHeightGrid.Take(i).Select(x => x[j]).Reverse().ToArray();
                    var visibleTopTreeCount = GetFromTreeVisibleTreeCount(currentTreeHeight, topTreeHeights);

                    var rightTreeHeight = treeHeightGrid[i].Skip(j + 1).ToArray();
                    var visibleRightTreeTree = GetFromTreeVisibleTreeCount(currentTreeHeight, rightTreeHeight);

                    var bottomTreeHeight = treeHeightGrid.Skip(i + 1).Select(x => x[j]).ToArray();
                    var visibleBottomTreeCount = GetFromTreeVisibleTreeCount(currentTreeHeight, bottomTreeHeight);

                    var leftTreeHeight = treeHeightGrid[i].Take(j).Reverse().ToArray();
                    var visibleLeftTreeCount = GetFromTreeVisibleTreeCount(currentTreeHeight, leftTreeHeight);

                    var scenicScore = visibleTopTreeCount * visibleRightTreeTree * visibleBottomTreeCount * visibleLeftTreeCount;
                    if (scenicScore > highestScenicScore)
                    {
                        highestScenicScore = scenicScore;
                    }
                }
            }
            return highestScenicScore;
        }

        private static int GetFromTreeVisibleTreeCount(int currentTreeHeight, int[] treeHeights)
        {
            var count = 0;
            for (int i = 0; i < treeHeights.Length; i++)
            {
                if (currentTreeHeight > treeHeights[i])
                {
                    count++;
                }
                else
                {
                    count++;
                    break;
                }
            }

            return count;
        }
    }
}
