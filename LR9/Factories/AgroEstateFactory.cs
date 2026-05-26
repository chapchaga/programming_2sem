using LR9.Interfaces;
using LR9.Models;

namespace LR9.Factories
{
    public class AgroEstateFactory : IAccommodationFactory
    {
        public Accommodation Create(string name,
                                    IPayment payment)
        {
            return new AgroEstate(name, payment);
        }
    }
}