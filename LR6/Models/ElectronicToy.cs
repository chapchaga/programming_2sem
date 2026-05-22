namespace LR6.Models;

class ElectronicToy : Toy
{
    protected int batteryLevel;
    public ElectronicToy(string name, int durability, int battery) : base(name, durability)
    {
        if (battery < 0 || battery > 100)
            throw new ArgumentException("Значение баттареи должно быть от 0 дл 100");

        batteryLevel = battery;

    }

    public override void Play()
    {
        CheckDurability();

        if (batteryLevel <= 0)
            throw new Exception("Нет заряда!");

        ChangeDurability(-5);
        batteryLevel -= 10;

        if (batteryLevel < 0)
            batteryLevel = 0;

        Console.WriteLine($"Игрушка {Name} играет. Прочность: {durability}, батарея: {batteryLevel}");
    }
}
