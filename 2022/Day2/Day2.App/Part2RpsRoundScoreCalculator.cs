class Part2RpsRoundScoreCalculator : RpsRoundScoreCalculator
{
    public virtual int GetMyScore(Shape opponentShape, Shape myShape)
    {
        var shapeToCompareInstead = myShape switch
        {
            Rock => opponentShape.GetWeakerShape(),
            Paper => opponentShape,
            Scissors => opponentShape.GetStrongerShape(),
            _ => throw new ArgumentOutOfRangeException(nameof(myShape), "Invalid shape")
        };

        return CalculateScoreByComparingShapes(opponentShape, shapeToCompareInstead);
    }
}
