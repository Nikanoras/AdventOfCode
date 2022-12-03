abstract class RpsRoundScoreCalculator
{
    public abstract int GetMyScore(Shape opponentShape, Shape myShape);

    protected static int CalculateScoreByComparingShapes(Shape shape1, Shape shape2)
    {
        return GetShapeTypeComparisonScore(shape1, shape2) + GetShapeScore(shape2);
    }

    private static int GetShapeTypeComparisonScore(Shape shape1, Shape shape2)
    {
        var score = 0;
        var shape2Type = shape2.GetType();
        if (shape1.GetType() == shape2Type)
        {
            score = 3;
        }
        else if (shape1.GetStrongerShape().GetType() == shape2Type)
        {
            score = 6;
        }

        return score;
    }

    private static int GetShapeScore(Shape shape)
    {
        return shape switch
        {
            Rock => 1,
            Paper => 2,
            Scissors => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), "Invalid shape type")
        };
    }
}
