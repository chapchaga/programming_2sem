namespace LR5.Utils;

public static class InputHelper
{
    public static string ReadString(string message)
    {
        while (true)
        {
            try
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Ввод не может быть пустым");

                return input.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    public static int ReadPositiveInt(string message)
    {
        while (true)
        {
            try
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int result))
                    throw new FormatException("Введите целое число");

                if (result <= 0)
                    throw new ArgumentException("Число должно быть больше 0");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    public static double ReadPositiveDouble(string message)
    {
        while (true)
        {
            try
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!double.TryParse(input, out double result))
                    throw new FormatException("Введите число");

                if (result <= 0)
                    throw new ArgumentException("Число должно быть больше 0");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    public static int ReadChoice(string message, int min, int max)
    {
        while (true)
        {
            try
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int result))
                    throw new FormatException("Введите число");

                if (result < min || result > max)
                    throw new ArgumentOutOfRangeException($"Введите число от {min} до {max}");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}