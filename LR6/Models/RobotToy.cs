namespace LR6.Models;

class RobotToy : ElectronicToy
{
    public RobotToy(string name, int durability, int battery) : base(name, durability, battery)
    {

    }

    public override void Repair()
    {
        base.Repair();
        batteryLevel = 100;
        Console.WriteLine($"Игрушка {Name} полностью заряжена");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Робот {Name}. Прочность: {durability}, батарея: {batteryLevel}");
    }
}
