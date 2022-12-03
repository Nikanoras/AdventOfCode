class Scissors : Shape
{
    public override Shape GetWeakerShape()
    {
        return new Paper();
    }

    public override Shape GetStrongerShape()
    {
        return new Rock();
    }
}
