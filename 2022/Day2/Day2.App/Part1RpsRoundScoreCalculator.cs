class Part1RpsRoundScoreCalculator : RpsRoundScoreCalculator
{
    public virtual int GetMyScore(Shape opponentShape, Shape myShape)
    {
        return CalculateScoreByComparingShapes(opponentShape, myShape);
    }
}
