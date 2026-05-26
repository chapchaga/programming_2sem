using LR9.Interfaces;
using LR9.Models;

namespace LR9.Factories
{
    public class HostelFactory : IAccommodationFactory
    {
        public Accommodation Create(string name,
                                    IPayment payment)
        {
            return new Hostel(name, payment);
        }
    }
}