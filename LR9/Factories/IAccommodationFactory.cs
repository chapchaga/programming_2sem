using LR9.Interfaces;
using LR9.Models;

namespace LR9.Factories
{
    public interface IAccommodationFactory
    {
        Accommodation Create(string name,
                             IPayment payment);
    }
}