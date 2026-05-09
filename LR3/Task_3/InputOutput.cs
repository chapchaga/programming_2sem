using System;

namespace DateApp
{
    public class InputOutput
    {
        public int ShowMenu()
        {
            Console.WriteLine("МЕНЮ");
            Console.WriteLine("1. Узнать день недели");
            Console.WriteLine("2. Разница с сегодняшней датой");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите пункт: ");

            return ReadNumber("");
        }

        public int ReadNumber(string message)
        {
            int number;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out number))
                    return number;

                Console.WriteLine("Ошибка! Введите число.");
            }
        }

        public void ReadDate(DateService service, out int day, out int month, out int year)
        {
            while (true)
            {
                year = ReadNumber("Год: ");
                month = ReadNumber("Месяц: ");
                day = ReadNumber("День: ");

                if (service.IsValidDate(day, month, year))
                    return;

                Console.WriteLine("Ошибка! Такой даты не существует. Введите снова.\n");
            }
        }

        public void ShowDay(string day)
        {
            Console.WriteLine("День недели: " + day);
        }

        public void ShowSpan(int days)
        {
            if (days > 0)
                Console.WriteLine($"До даты осталось {days} дней");
            else if (days < 0)
                Console.WriteLine($"С даты прошло {Math.Abs(days)} дней");
            else
                Console.WriteLine("Эта дата сегодня");
        }

        public void ShowError(string text)
        {
            Console.WriteLine("Ошибка: " + text);
        }
    }
}
