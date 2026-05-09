namespace Task_2
{
    public class MyClass
    {
        public static bool TryReadDouble(string s, out double value)
        {
            return double.TryParse(s, out value);
        }

        public static int InArea(double x, double y)
{
    double r = 15;
    double eps = 0.0001;

    bool onCircle = Math.Abs(x * x + y * y - r * r) < eps;
    bool onLine = Math.Abs(y - Math.Abs(x)) < eps;

    bool inside =
        (y > Math.Abs(x)) &&
        (x * x + y * y < r * r);

    bool border =
        (onCircle && y >= Math.Abs(x)) ||
        (onLine && x * x + y * y <= r * r);

    if (inside)
        return 1;
    else if (border)
        return 2;
    else
        return 3;
}
    }
}