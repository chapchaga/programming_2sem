using System;
using Task_2.Services;

namespace Task_2
{
    class Program
    {
        static void Main()
        {
            double z;

            while(true)
            {
                Console.Write("Введите z :");
                if (double.TryParse(Console.ReadLine(), out z))
                {
                    Function.Calculate(z);
                }
                else
                {
                    Console.WriteLine("Ошибка ввода, попробуйте еще раз");
                    continue;
                }

                if (!Function.AskToContinue())
                {
                    break;
                }
            }
        }
    }
}