class Part1RpsRoundScoreCalculator : RpsRoundScoreCalculator
{
    public override int GetMyScore(Shape opponentShape, Shape myShape)
    {
        return CalculateScoreByComparingShapes(opponentShape, myShape);
    }
}
