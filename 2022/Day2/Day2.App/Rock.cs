class Rock : Shape
{
    public override Shape GetWeakerShape()
    {
        return new Scissors();
    }

    public override Shape GetStrongerShape()
    {
        return new Paper();
    }
}
