using LR6.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Toy> toys = new List<Toy>();

        while (true)
        {
            try
            {
                Console.WriteLine("\n1. Создать игрушку");
                Console.WriteLine("2. Играть с игрушкой");
                Console.WriteLine("3. Починить игрушку");
                Console.WriteLine("4. Показать все игрушки");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                int choice = ReadInt();

                switch (choice)
                {
                    case 1:
                        toys.Add(CreateToy());
                        break;

                    case 2:
                        PlayToy(toys);
                        break;

                    case 3:
                        RepairToy(toys);
                        break;

                    case 4:
                        ShowAll(toys);
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    static Toy CreateToy()
    {
        Console.WriteLine("\nТип игрушки:");
        Console.WriteLine("1. Робот");
        Console.WriteLine("2. Мягкая");
        Console.WriteLine("3. Конструктор");
        Console.Write("Выбор: ");

        int type = ReadInt();

        Console.Write("Имя: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Имя не может быть пустым");

        Console.Write("Прочность: ");
        int durability = ReadDurability();

        if (type == 1)
        {
            Console.Write("Батарея: ");
            return new RobotToy(name, durability, ReadBattery());
        }

        return type switch
        {
            2 => new PlushToy(name, durability),
            3 => new ConstructorToy(name, durability),
            _ => throw new Exception("Неверный тип игрушки")
        };
    }

    static int ChooseToy(List<Toy> toys)
    {
        if (toys.Count == 0)
            throw new Exception("Список игрушек пуст");

        Console.WriteLine("\nСписок игрушек:");

        for (int i = 0; i < toys.Count; i++)
        {
            Console.Write($"{i}: ");
            toys[i].ShowInfo();
        }

        Console.Write("Выберите номер: ");
        int index = ReadInt();

        if (index < 0 || index >= toys.Count)
            throw new Exception("Неверный индекс");

        return index;
    }

    static void PlayToy(List<Toy> toys)
    {
        int i = ChooseToy(toys);
        toys[i].Play();
    }

    static void RepairToy(List<Toy> toys)
    {
        int i = ChooseToy(toys);
        toys[i].Repair();
    }

    static void ShowAll(List<Toy> toys)
    {
        if (toys.Count == 0)
        {
            Console.WriteLine("Нет игрушек");
            return;
        }

        foreach (var toy in toys)
        {
            toy.ShowInfo();
        }
    }

    static int ReadInt()
    {
        while (true)
        {
            string? input = Console.ReadLine();

            if (input is null)
                throw new InvalidOperationException("Ввод недоступен. Запустите программу в терминале.");

            if (int.TryParse(input, out int result))
                return result;

            Console.Write("Ошибка! Введите число: ");
        }
    }

    static int ReadBattery()
    {
        while (true)
        {
            int value = ReadInt();

            if (value >= 0 && value <= 100)
                return value;

            Console.Write("Батарея должна быть от 0 до 100: ");
        }
    }

    static int ReadDurability()
    {
        while (true)
        {
            int value = ReadInt();

            if (value >= 0 && value <= 100)
                return value;

            Console.Write("Прочность должна быть от 0 до 100: ");
        }
    }
}
