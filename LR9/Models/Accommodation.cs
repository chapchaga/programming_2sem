using System;
using LR9.Enums;
using LR9.Interfaces;

namespace LR9.Models
{
    public abstract class Accommodation
    {
        protected string name;
        protected AccommodationType type;
        protected IPayment payment;

        public Accommodation(string name,
                             AccommodationType type,
                             IPayment payment)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be empty");
            }

            if (payment == null)
            {
                throw new Exception("Payment cannot be null");
            }

            this.name = name;
            this.type = type;
            this.payment = payment;
        }

        public string Pay(decimal amount)
        {
            return payment.Pay(amount);
        }

        public abstract string GetInfo();
    }
}