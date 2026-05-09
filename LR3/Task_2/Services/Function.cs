using System;

namespace Task_2.Services
{
    public class Function
    {
        public static void Calculate(double z)
        {
            double x;

            if (z < -1)
            {
                x = -z / 3;
                Console.WriteLine("Случай 1 : z < -1");
            }
            else
            {
                x = Math.Abs(z);
                Console.WriteLine("Случай 2 : z >= -1");
            }
            if (x<= 0.5)
            {
                Console.WriteLine("Ошибка, x должен быть больше 0.5");
                return;
            }
        
        double y = Math.Log(x+0.5) + (Math.Exp(x) - Math.Exp(-x));
        Console.WriteLine("x = " + x);
        Console.WriteLine("y = " + y);
        }
        public static bool AskToContinue()
        {
            Console.Write("Продолжить ? (y/n) : ");                            //ToLower() - из большой буквы делает маленькую
            string answer = Console.ReadLine().Trim().ToLower();               //Trim() - исключает пробелы
                                                                                           
            while (answer != "y" && answer != "n")
            {
                Console.Write("Введите y или n : ");
                answer = Console.ReadLine().Trim().ToLower();
            }

            return answer == "y";                                
        }                                                                       
        
    }
}