using System;

class Hotel
{
    private static Hotel instance;

    public string Name;
    public int TotalRooms;
    public int OccupiedRooms;

    private Tariff tariff;
    public double CurrentPrice => tariff.Price;

    private Hotel() { }

    public static Hotel GetInstance()
    {
        if (instance == null)
            instance = new Hotel();

        return instance;
    }

    public void Init(string name, int totalRooms, int occupiedRooms, double price)
    {
        Name = name;
        TotalRooms = totalRooms;
        OccupiedRooms = occupiedRooms;

        tariff = new Tariff(price);
    }

    public double GetRevenue()
    {
        return OccupiedRooms * tariff.Price;
    }

    public void IncreaseTariff(double value)
    {
        tariff.Increase(value);
    }

    public void IncreaseTariffPercent(int percent)
    {
        tariff.Increase(percent);
    }

    public void DecreaseTariff(double value)
    {
        tariff.Decrease(value);
    }

    public void DecreaseTariffPercent(int percent)
    {
        tariff.Decrease(percent);
    }
}
