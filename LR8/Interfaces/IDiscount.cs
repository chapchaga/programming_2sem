namespace HotelSystem.Interfaces
{
    interface IDiscount
    {
        decimal Apply(decimal price);
    }
}