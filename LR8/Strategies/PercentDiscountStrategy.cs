using System;
using HotelSystem.Interfaces;

namespace HotelSystem.Strategies
{
    class PercentDiscountStrategy : IDiscount
    {
        private decimal percent;

        public PercentDiscountStrategy(decimal percent)
        {
            if (percent < 0 || percent > 100)
            {
                throw new ArgumentException(
                    "Скидка должна быть от 0 до 100%");
            }

            this.percent = percent;
        }

        public decimal Apply(decimal price)
        {
            return price - (price * percent / 100);
        }
    }
}