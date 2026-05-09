using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Система управления гостиницей :");

        Hotel hotel = Hotel.GetInstance();

        string name = "DoubleTree";
        int totalRooms = 1000;
        double price = 100;

        int occupiedRooms;

        while (true)
        {
            occupiedRooms = ReadInt("Введите количество занятых мест: ");

            if (occupiedRooms <= totalRooms)
                break;

            Console.WriteLine("Ошибка: занятых мест больше, чем всего!");
        }

        hotel.Init(name, totalRooms, occupiedRooms, price);

        do
        {
            Console.WriteLine("\n--- ИНФОРМАЦИЯ ---");
            Console.WriteLine("Гостиница: " + name);
            Console.WriteLine("Всего мест: " + totalRooms);
            Console.WriteLine("Занято: " + occupiedRooms);
            Console.WriteLine("Свободно: " + (totalRooms - occupiedRooms));
            Console.WriteLine("Тариф: " + hotel.CurrentPrice);
            Console.WriteLine("Выручка: " + hotel.GetRevenue());

            Console.WriteLine("\n1 - Увеличить тариф");
            Console.WriteLine("2 - Уменьшить тариф");
            Console.WriteLine("3 - Выход");

            int choice = ReadInt("Ваш выбор: ");

            switch (choice)
            {
                case 1:
                    Console.WriteLine("1 - На число");
                    Console.WriteLine("2 - В процентах");
                    int type = ReadInt("Выбор: ");

                    if (type == 1)
                    {
                        double inc = ReadDouble("Введите значение: ");
                        try
                        {
                            hotel.IncreaseTariff(inc);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                    }
                    else if (type == 2)
                    {
                        try
                        {
                            int percent = ReadInt("Введите процент: ");
                            hotel.IncreaseTariffPercent(percent);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("1 - На число");
                    Console.WriteLine("2 - В процентах");
                    int type2 = ReadInt("Выбор: ");

                    if (type2 == 1)
                    {
                        try
                        {
                            double dec = ReadDouble("Введите значение: ");
                            hotel.DecreaseTariff(dec);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                    }
                    else if (type2 == 2)
                    {
                        try
                        {
                            int percent = ReadInt("Введите процент: ");
                            hotel.DecreaseTariffPercent(percent);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                    }
                    break;
                
                case 3:
                    return;
                
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }

        } while (true);
    }

    static int ReadInt(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                return value;

            Console.WriteLine("Ошибка, попробуйте еще раз");
        }
    }

    static double ReadDouble(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                return value;

            Console.WriteLine("Ошибка, попробуйте еще раз");
        }
    }
}