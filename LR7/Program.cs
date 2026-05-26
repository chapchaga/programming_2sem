using System;

class Program
{
    static CharSet ReadSet(string name)
    {
        while (true)
        {
            try
            {
                Console.Write($"Введите символы для множества {name} (например: abcd): ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    throw new Exception("Ввод не может быть пустым");

                // Явное преобразование string -> CharSet
                CharSet set = (CharSet)input;
                return set;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message + " Попробуйте снова.");
            }
        }
    }

    static void Main()
    {
        CharSet empty = new CharSet();


        // Ввод двух множеств с клавиатуры
        Console.WriteLine();
        CharSet A = ReadSet("A");
        CharSet B = ReadSet("B");
        Console.WriteLine();

        // --- Свойства ---
        Console.WriteLine("-- Свойства --");
        Console.WriteLine($"A = {A}  (кол-во элементов: {A.Count})");
        Console.WriteLine($"B = {B}  (кол-во элементов: {B.Count})");

        // --- Индексатор ---
        Console.WriteLine("\n-- Индексатор --");
        if (A.Count > 0) Console.WriteLine($"A[0] = {A[0]}");
        if (A.Count > 1) Console.WriteLine($"A[1] = {A[1]}");
        
        Console.WriteLine("\n-- Математические операции --");
        Console.WriteLine($"A + B (объединение)  = {A + B}");
        Console.WriteLine($"A - B (разность)     = {A - B}");
        Console.WriteLine($"A * B (пересечение)  = {A * B}");
        
        Console.WriteLine("\n-- Инкремент и декремент --");
        CharSet A2 = A;
        Console.WriteLine($"A до ++:    {A2}");
        A2++;
        Console.WriteLine($"A после ++: {A2}");
        A2--;
        Console.WriteLine($"A после --: {A2}");
        
        Console.WriteLine("\n-- Сравнение --");
        Console.WriteLine($"A == B : {A == B}");
        Console.WriteLine($"A != B : {A != B}");
        Console.WriteLine($"A >  B (по кол-ву): {A > B}");
        Console.WriteLine($"A <  B (по кол-ву): {A < B}");
        
        Console.WriteLine("\n-- Операторы true / false --");
        Console.Write("Множество A: ");
        if (A) Console.WriteLine("не пустое (true)");
        else   Console.WriteLine("пустое (false)");

        Console.Write("Пустое множество: ");
        if (empty) Console.WriteLine("не пустое (это ошибка!)");
        else       Console.WriteLine("пустое (false) — верно");
        
        Console.WriteLine("\n-- Преобразования типа --");
        
        string str = A;
        Console.WriteLine($"Неявное CharSet -> string: \"{str}\"");
        
        try
        {
            CharSet fromStr = (CharSet)str;
            Console.WriteLine($"Явное (CharSet)\"{str}\" -> {fromStr}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        
        try
        {
            CharSet bad = (CharSet)"aabb";
            Console.WriteLine("Должна была быть ошибка!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Защита от повторов сработала: {ex.Message}");
        }
    }
}
