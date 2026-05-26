using System;

class CharSet
{
    private char[] elements = new char[0];

    public char[] Elements
    {
        get => elements;
        set
        {
            if (value == null)
                throw new ArgumentNullException("Массив не должен быть null");
            
            if (!IsValid(value))
                throw new ArgumentException("Множество содержит повторяющиеся элементы");
            
            elements = new char[value.Length];
            Array.Copy(value, elements, value.Length);
        }
    }

    public CharSet(char[] elements)
    {
        Elements = elements;
    }

    public CharSet()
    {
        elements = new char[0];
    }

    private static bool IsValid(char[] arr) //проверка на повтор
    {
        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[i] == arr[j])
                    return false;
        return true;
    }

    public int Count => elements.Length; //колво элементов

    public override string ToString() //перегрузка
    {
        if (elements.Length == 0)
            return "{ }";
        string result = "{ ";
        for (int i = 0; i < elements.Length; i++)
        {
            result += elements[i];
            if (i < elements.Length - 1)
                result += ", ";
        }
        result += " }";
        return result;
    }

    public char this[int index]
    {
        get
        {
            if (index < 0 || index >= elements.Length)
                throw new IndexOutOfRangeException($"Индекс {index} выходит за пределы (размер: {elements.Length})");
            return elements[index];
        }
    }

    public static CharSet operator +(CharSet a, CharSet b) //объеденение
    {
        char[] temp = new char[a.elements.Length + b.elements.Length];
        int k = 0;
        for (int i = 0; i < a.elements.Length; i++)
            temp[k++] = a.elements[i];
        for (int i = 0; i < b.elements.Length; i++)
        {
            bool exists = false;
            for (int j = 0; j < a.elements.Length; j++)
                if (b.elements[i] == a.elements[j]) { exists = true; break; }
            if (!exists)
                temp[k++] = b.elements[i];
        }
        char[] result = new char[k];
        Array.Copy(temp, result, k);
        return new CharSet(result);
    }

    public static CharSet operator -(CharSet a, CharSet b) //разность
    {
        char[] temp = new char[a.elements.Length];
        int k = 0;
        for (int i = 0; i < a.elements.Length; i++)
        {
            bool exists = false;
            for (int j = 0; j < b.elements.Length; j++)
                if (a.elements[i] == b.elements[j]) { exists = true; break; }
            if (!exists)
                temp[k++] = a.elements[i];
        }
        char[] result = new char[k];
        Array.Copy(temp, result, k);
        return new CharSet(result);
    }

    public static CharSet operator *(CharSet a, CharSet b) //пересечение
    {
        char[] temp = new char[Math.Min(a.elements.Length, b.elements.Length)];
        int k = 0;
        for (int i = 0; i < a.elements.Length; i++)
            for (int j = 0; j < b.elements.Length; j++)
                if (a.elements[i] == b.elements[j]) { temp[k++] = a.elements[i]; break; }
        char[] result = new char[k];
        Array.Copy(temp, result, k);
        return new CharSet(result);
    }

    public static CharSet operator ++(CharSet a) //инкремент
    {
        char[] temp = new char[a.elements.Length];
        int k = 0;
        for (int i = 0; i < a.elements.Length; i++)
        {
            char next = (char)(a.elements[i] + 1);
            bool dup = false;
            for (int j = 0; j < k; j++)
                if (temp[j] == next) { dup = true; break; }
            if (!dup)
                temp[k++] = next;
        }
        char[] result = new char[k];
        Array.Copy(temp, result, k);
        return new CharSet(result);
    }

    public static CharSet operator --(CharSet a) //декремент
    {
        char[] temp = new char[a.elements.Length];
        int k = 0;
        for (int i = 0; i < a.elements.Length; i++)
        {
            char prev = (char)(a.elements[i] - 1);
            bool dup = false;
            for (int j = 0; j < k; j++)
                if (temp[j] == prev) { dup = true; break; }
            if (!dup)
                temp[k++] = prev;
        }
        char[] result = new char[k];
        Array.Copy(temp, result, k);
        return new CharSet(result);
    }

    public static bool operator ==(CharSet a, CharSet b) //равенство
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        if (a.elements.Length != b.elements.Length) return false;
        for (int i = 0; i < a.elements.Length; i++)
        {
            bool found = false;
            for (int j = 0; j < b.elements.Length; j++)
                if (a.elements[i] == b.elements[j]) { found = true; break; }
            if (!found) return false;
        }
        return true;
    }

    public static bool operator !=(CharSet a, CharSet b) => !(a == b);

    public static bool operator <(CharSet a, CharSet b) => a.elements.Length < b.elements.Length; //сравнение
    public static bool operator >(CharSet a, CharSet b) => a.elements.Length > b.elements.Length;


    public static bool operator true(CharSet a) => a.elements.Length > 0; //true — множество не пустое, false — пустое
    public static bool operator false(CharSet a) => a.elements.Length == 0;


    public static implicit operator string(CharSet a) => new string(a.elements); //неявное преобразование CharSet -> string

    public static explicit operator CharSet(string str) //явное преобразование string -> CharSet
    {
        if (str == null)
            throw new ArgumentNullException("Строка не должна быть null");
        if (str.Length == 0)
            return new CharSet();
        char[] chars = str.ToCharArray();
        if (!IsValid(chars))
            throw new ArgumentException($"Строка \"{str}\" содержит повторяющиеся символы");
        return new CharSet(chars);
    }

    public override bool Equals(object? obj)
    {
        if (obj is CharSet other) return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        int hash = 0;
        foreach (char c in elements)
            hash ^= c.GetHashCode();
        return hash;
    }
}
