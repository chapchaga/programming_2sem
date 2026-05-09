using System;
using Task_2;

class Program
{
    static void Main()
    {
        while (true)
        {
            double x, y;

            Console.Write("Введите x: ");
            while (true)
            {
                string input = Console.ReadLine();

                if (MyClass.TryReadDouble(input, out x))
                    break;

                Console.WriteLine("Ошибка ввода");
            }

            Console.Write("Введите y: ");
            while (true)
            {
                string input = Console.ReadLine();

                if (MyClass.TryReadDouble(input, out y))
                    break;

                Console.WriteLine("Ошибка ввода");
            }

            int result = MyClass.InArea(x, y);

            if (result == 1)
                Console.WriteLine("Да");
            else if (result == 2)
                Console.WriteLine("На границе");
            else
                Console.WriteLine("Нет");

            Console.WriteLine("1 - Продолжить");
            Console.WriteLine("2 - Закончить");

            int choice;

            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) &&
                    (choice == 1 || choice == 2))
                    break;

                Console.WriteLine("Введите 1 или 2");
            }

            if (choice == 2)
                return;
        }
    }
}