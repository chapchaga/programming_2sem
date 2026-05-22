namespace LR6.Models;
class PlushToy : Toy
{
    public PlushToy(string name, int durability) : base(name, durability)
    {

    }

    public override void Play()
    {
        CheckDurability();
        ChangeDurability(-2);
        Console.WriteLine($"Игрушка {Name} мягко используется");
    }
}
