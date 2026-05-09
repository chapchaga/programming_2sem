using System;
using Task_1;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Введите двухзначное число: ");

            int number;

            while (true)
            {
                string input = Console.ReadLine();

                if (MyClass.TryNumber(input, out number))
                    break;
                else
                    Console.WriteLine("Ошибка ввода. Повторите.");
            }

            int sum = MyClass.SumDigits(number);

            Console.WriteLine($"Сумма цифр: {sum}");

            if (MyClass.IsEven(sum))
                Console.WriteLine("Сумма четная");
            else
                Console.WriteLine("Сумма нечетная");

            Console.WriteLine("1 - Продолжить");
            Console.WriteLine("2 - Закончить");

            int choice;

            while (true)
            {
                string choiceInput = Console.ReadLine();

                if (int.TryParse(choiceInput, out choice) &&
                    (choice == 1 || choice == 2))
                    break;

                Console.WriteLine("Введите 1 или 2.");
            }

            if (choice == 2)
                return;
        }
    }
}