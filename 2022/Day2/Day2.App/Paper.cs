class Paper : Shape
{
    public override Shape GetWeakerShape()
    {
        return new Rock();
    }

    public override Shape GetStrongerShape()
    {
        return new Scissors();
    }
}
