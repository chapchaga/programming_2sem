using LR9.Enums;
using LR9.Interfaces;

namespace LR9.Models
{
    public class Hostel : Accommodation, IWiFi, ITransfer
    {
        public Hostel(string name,
                      IPayment payment)
            : base(name, AccommodationType.Hostel, payment)
        {

        }

        public override string GetInfo()
        {
            return $"Hostel: {name}";
        }

        public string UseWiFi()
        {
            return $"{name} uses WiFi";
        }

        public string OrderTransfer()
        {
            return $"{name} ordered transfer";
        }
    }
}