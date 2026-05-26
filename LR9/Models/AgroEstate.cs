using LR9.Enums;
using LR9.Interfaces;

namespace LR9.Models
{
    public class AgroEstate : Accommodation, IPool, ITransfer
    {
        public AgroEstate(string name,
                          IPayment payment)
            : base(name, AccommodationType.AgroEstate, payment)
        {

        }

        public override string GetInfo()
        {
            return $"AgroEstate: {name}";
        }

        public string UsePool()
        {
            return $"{name} uses pool";
        }

        public string OrderTransfer()
        {
            return $"{name} ordered transfer";
        }
    }
}