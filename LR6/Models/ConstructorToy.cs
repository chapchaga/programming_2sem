namespace LR6.Models;
class ConstructorToy  : Toy
{
    public ConstructorToy(string name, int durability) : base(name, durability)
    {

    }

    public override void Play()
    {
        CheckDurability();
        ChangeDurability(-3);
        Console.WriteLine($"Игрушка {Name} собирается и разбирается");
    }
}
