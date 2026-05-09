using System;
class Program
{
    static void Main()
    {
       double number1;
       double number2;

       while (true)
        {
            Console.Write("Введите первое число : ");
            string input = Console.ReadLine();

            bool isNumber = double.TryParse(input, out number1);

            if (isNumber)
            {
                break;
            }
            else
            {
                Console.WriteLine("Неправильный ввод, попробуйте еще раз");
            }
        }

        while (true)
        {
            Console.Write("Введите второе число : ");
            string input = Console.ReadLine();

            bool isNumber = double.TryParse(input, out number2);

            if (isNumber && number2 != 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Неправильный ввод, попробуйте еще раз");                
            }
        }

        double result = number1 / number2;
        Console.WriteLine("Результат : " + result);        
    }
}