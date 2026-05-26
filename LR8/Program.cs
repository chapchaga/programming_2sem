using System;
using HotelSystem;
using HotelSystem.Interfaces;
using HotelSystem.Strategies;

class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new Hotel();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine("1. Добавить номер");
            Console.WriteLine("2. Показать все номера");
            Console.WriteLine("3. Показать среднюю цену");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRoomMenu(hotel);
                    break;
                case "2":
                    hotel.ShowAllRooms();
                    break;
                case "3":
                    ShowAveragePrice(hotel);
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }
    }

    static void AddRoomMenu(Hotel hotel)
    {
        int number = ReadPositiveInt("Введите номер комнаты: ");
        decimal basePrice = ReadPositiveDecimal("Введите базовую цену: ");

        Console.Write("Введите скидку в процентах (0, если скидки нет): ");
        decimal percent = ReadPercent();

        IDiscount discountStrategy = percent == 0
            ? new NoDiscountStrategy()
            : new PercentDiscountStrategy(percent);

        Room room = new Room(number, basePrice, discountStrategy);
        try
        {
            hotel.AddRoom(room);
            Console.WriteLine("Номер добавлен");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ShowAveragePrice(Hotel hotel)
    {
        try
        {
            Console.WriteLine($"Средняя цена: {hotel.GetAveragePrice():F2}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static int ReadPositiveInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Введите положительное целое число");
        }
    }

    static decimal ReadPositiveDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (decimal.TryParse(Console.ReadLine(), out decimal value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Введите число больше нуля");
        }
    }

    static decimal ReadPercent()
    {
        while (true)
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal percent)
                && percent >= 0
                && percent <= 100)
            {
                return percent;
            }

            Console.Write("Введите число от 0 до 100: ");
        }
    }
}
