using System;

namespace DateApp
{
    public class DateService
    {
        public string GetDay(int day, int month, int year)
        {
            DateTime date = new DateTime(year, month, day);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                default: return "";
            }
        }

        public int GetDaysSpan(int day, int month, int year)
        {
            DateTime target = new DateTime(year, month, day);
            DateTime today = DateTime.Today;

            return (target - today).Days;
        }

        public bool IsValidDate(int day, int month, int year)
        {
            if (year < 1 || year > 9999) return false;
            if (month < 1 || month > 12) return false;

            int daysInMonth = DateTime.DaysInMonth(year, month);

            return day >= 1 && day <= daysInMonth;
        }
    }
}
