using System;

namespace Task_1
{
    public class WorkWithDigits
    {
        public static int WorkWithNumber(int number)
        {
            if (number % 2 == 0)
            {
                return number / 2;
            }
            else
            {
                return number + 3;
            }
        }

        public static bool IsNumber(string input)
        {
            return int.TryParse(input, out _);
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