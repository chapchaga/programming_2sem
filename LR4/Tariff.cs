class Tariff
{
    private double price;
    
    public double Price
    {
        get => price;
        private set
        {
            if (value < 0)
                throw new ArgumentException("Цена не может быть отрицательной");

            price = value;
        }
    }

    public Tariff(double price)
    {
        Price = price;
    }

    public void Increase(double value)
    {
        if (value < 0)
            throw new ArgumentException("Увеличение не может быть отрицательным");

        Price += value;
    }

    public void Increase(int percent)
    {
        if (percent < 0)
            throw new ArgumentException("Процент не может быть отрицательным");

        Price += Price * percent / 100;
    }

    public void Decrease(double value)
    {
        if (value < 0)
            throw new ArgumentException("Уменьшение не может быть отрицательным");

        Price -= value;
    }

    public void Decrease(int percent)
    {
        if (percent < 0)
            throw new ArgumentException("Процент не может быть отрицательным");

        double decrease = Price * percent / 100;
        Price -= decrease;
    }
}