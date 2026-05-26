using HotelSystem.Interfaces;

namespace HotelSystem.Strategies
{
    class NoDiscountStrategy : IDiscount
    {
        public decimal Apply(decimal price)
        {
            return price;
        }
    }
}