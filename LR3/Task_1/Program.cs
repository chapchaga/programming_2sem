using System;
using System.Text;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                int number;

                while (true)
                {
                    Console.Write("Введите число : ");
                    string input = Console.ReadLine();

                    if (WorkWithDigits.IsNumber(input))
                    {
                        number = int.Parse(input);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода, попробуйте еще раз");
                    }
                }

                int result = WorkWithDigits.WorkWithNumber(number);
                Console.WriteLine("Результат операции : " + result);

                if (!WorkWithDigits.AskToContinue())
                    break;
            }
        }
    }
}
