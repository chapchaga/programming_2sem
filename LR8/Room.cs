using System;
using HotelSystem.Interfaces;

namespace HotelSystem
{
    class Room
    {
        private int number;
        private decimal basePrice;
        private IDiscount discountStrategy;

        public Room(
            int number,
            decimal basePrice,
            IDiscount discountStrategy)
        {
            if (number <= 0)
            {
                throw new ArgumentException(
                    "Номер комнаты должен быть положительным");
            }

            if (basePrice <= 0)
            {
                throw new ArgumentException(
                    "Стоимость должна быть больше нуля");
            }

            this.number = number;
            this.basePrice = basePrice;

            this.discountStrategy =
                discountStrategy
                ?? throw new ArgumentNullException(
                    nameof(discountStrategy));
        }

        public decimal FinalPrice
        {
            get
            {
                return discountStrategy.Apply(basePrice);
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
        }

        public string GetInfo()
        {
            return
                $"Номер: {number} | " +
                $"Базовая цена: {basePrice:F2} | " +
                $"Итоговая цена: {FinalPrice:F2}";
        }
    }
}
