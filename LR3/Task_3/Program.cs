using System;

namespace DateApp
{
    class Program
    {
        static void Main()
        {
            DateService service = new DateService();
            InputOutput io = new InputOutput();

            bool run = true;

            Console.WriteLine("Сегодня: " + DateTime.Today.ToString("yyyy.MM.dd"));
            Console.WriteLine();

            while (run)
            {
                int choice = io.ShowMenu();

                if (choice == 1)
                {
                    io.ReadDate(service, out int day, out int month, out int year);

                    string result = service.GetDay(day, month, year);

                    io.ShowDay(result);
                }

                else if (choice == 2)
                {
                    io.ReadDate(service, out int day, out int month, out int year);

                    int days = service.GetDaysSpan(day, month, year);

                    io.ShowSpan(days);
                }

                else if (choice == 3)
                {
                    run = false;
                }

                else
                {
                    io.ShowError("Такого пункта меню нет.");
                }

                Console.WriteLine();
            }
        }
    }
}
