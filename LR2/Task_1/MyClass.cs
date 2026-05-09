namespace Task_1
{
    public class MyClass
    {
        public static bool TryNumber(string s, out int number) //проверка ввода
        {
            if (int.TryParse(s, out number))
            {
                if ((number >= 10 && number <= 99) ||
                    (number <= -10 && number >= -99))
                    return true;
            }

            number = 0;
            return false;
        }

        public static int SumDigits(int number) //сумма
        {
            number = Math.Abs(number);

            int first = number / 10;
            int second = number % 10;

            return first + second;
        }

        public static bool IsEven(int sum) //четность
        {
            return sum % 2 == 0;
        }
    }
}