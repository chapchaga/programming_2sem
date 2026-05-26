using System;
using LR9.Interfaces;

namespace LR9.Payments
{
    public class CashPayment : IPayment
    {
        public string Pay(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid amount");
            }

            return $"Cash payment: {amount}";
        }
    }
}