namespace LR5.Models;

public class Room
{
    public int Number { get; }
    public double Price { get; }
    public bool IsOccupied { get; private set; }
    public RoomType Type { get; }

    public Room(int number, double price, RoomType type)
    {
        if (number <= 0)
            throw new ArgumentException("Номер должен быть положительным");

        if (price <= 0)
            throw new ArgumentException("Цена должна быть больше 0");

        Number = number;
        Price = price;
        Type = type;
        IsOccupied = false;
    }

    public void Occupy()
    {
        if (IsOccupied)
            throw new InvalidOperationException("Номер уже занят");

        IsOccupied = true;
    }

    public void Free()
    {
        if (!IsOccupied)
            throw new InvalidOperationException("Номер уже свободен");

        IsOccupied = false;
    }

    public override string ToString()
    {
        return $"Номер {Number} ({Type}) | Цена: {Price} | " +
               (IsOccupied ? "Занят" : "Свободен");
    }
}