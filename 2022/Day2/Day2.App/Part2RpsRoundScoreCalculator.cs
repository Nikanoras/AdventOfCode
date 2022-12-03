class Part2RpsRoundScoreCalculator : RpsRoundScoreCalculator
{
    public override int GetMyScore(Shape opponentShape, Shape myShape)
    {
        Shape shapeToCompareInstead;
        if (myShape is Rock)
        {
            shapeToCompareInstead = opponentShape.GetWeakerShape();
        }
        else if (myShape is Paper)
        {
            shapeToCompareInstead = opponentShape;
        }
        else if (myShape is Scissors)
        {
            shapeToCompareInstead = opponentShape.GetStrongerShape();
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(myShape), "Invalid shape");
        }

        return CalculateScoreByComparingShapes(opponentShape, shapeToCompareInstead);
    }
}
