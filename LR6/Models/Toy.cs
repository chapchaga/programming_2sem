using System.Globalization;

namespace LR6.Models;

abstract class Toy
{
    public string Name { get; set; }
    protected int durability;

    public Toy(string name, int durability)
    {
        if (durability < 0 || durability > 100)
            throw new ArgumentException("Прочность должна быть 0-100");

        Name = name;
        this.durability = durability;
    }

    protected void ChangeDurability(int delta)
    {
        durability += delta;

        if (durability > 100)
            durability = 100;

        if (durability < 0)
            durability = 0;
    }

    protected void CheckDurability()
    {
        if (durability <= 0)
            throw new Exception($"Игрушка {Name} сломана. Сначала почините игрушку.");
    }

    public abstract void Play();

    public virtual void Repair()
    {
        ChangeDurability(+10);
        Console.WriteLine($"Игрушка {Name} отремонтирована. Прочность: {durability}");
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Игрушка {Name}. Прочность: {durability}");
    }
}
