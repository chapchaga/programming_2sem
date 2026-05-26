using LR9.Enums;
using LR9.Interfaces;

namespace LR9.Models
{
    public class Hotel : Accommodation, IWiFi, IPool, IMiniBar
    {
        public Hotel(string name,
                     IPayment payment)
            : base(name, AccommodationType.Hotel, payment)
        {

        }

        public override string GetInfo()
        {
            return $"Hotel: {name}";
        }

        public string UseWiFi()
        {
            return $"{name} uses WiFi";
        }

        public string UsePool()
        {
            return $"{name} uses pool";
        }

        public string UseMiniBar()
        {
            return $"{name} uses minibar";
        }
    }
}