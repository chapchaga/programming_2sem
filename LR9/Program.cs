using System;
using System.Collections.Generic;
using LR9.Factories;
using LR9.Interfaces;
using LR9.Models;
using LR9.Payments;

namespace LR9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Accommodation> list =
                    new List<Accommodation>();

                bool isRunning = true;

                while (isRunning)
                {
                    Console.WriteLine("Choose accommodation:");
                    Console.WriteLine("1 - Hotel");
                    Console.WriteLine("2 - Hostel");
                    Console.WriteLine("3 - AgroEstate");
                    Console.WriteLine("0 - Exit");

                    string typeInput = Console.ReadLine();

                    if (!int.TryParse(typeInput, out int typeChoice))
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }

                    if (typeChoice == 0)
                    {
                        isRunning = false;
                        continue;
                    }

                    Console.Write("Enter name: ");

                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty");
                        continue;
                    }

                    Console.WriteLine("Choose payment:");
                    Console.WriteLine("1 - Cash");
                    Console.WriteLine("2 - Card");
                    Console.WriteLine("3 - Bank");

                    string paymentInput = Console.ReadLine();

                    if (!int.TryParse(paymentInput,
                                      out int paymentChoice))
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }

                    IPayment payment;

                    switch (paymentChoice)
                    {
                        case 1:
                            payment = new CashPayment();
                            break;

                        case 2:
                            payment = new CardPayment();
                            break;

                        case 3:
                            payment = new BankPayment();
                            break;

                        default:
                            Console.WriteLine("Invalid payment");
                            continue;
                    }

                    IAccommodationFactory factory;

                    switch (typeChoice)
                    {
                        case 1:
                            factory = new HotelFactory();
                            break;

                        case 2:
                            factory = new HostelFactory();
                            break;

                        case 3:
                            factory = new AgroEstateFactory();
                            break;

                        default:
                            Console.WriteLine("Invalid accommodation");
                            continue;
                    }

                    Accommodation item =
                        factory.Create(name, payment);

                    list.Add(item);

                    Console.WriteLine("Object created");
                    Console.WriteLine();
                }

                Console.WriteLine("All accommodations:");
                Console.WriteLine();

                foreach (Accommodation item in list)
                {
                    Console.WriteLine(item.GetInfo());

                    Console.WriteLine(item.Pay(100));

                    if (item is IWiFi wifi)
                    {
                        Console.WriteLine(
                            wifi.UseWiFi());
                    }

                    if (item is IPool pool)
                    {
                        Console.WriteLine(
                            pool.UsePool());
                    }

                    if (item is ITransfer transfer)
                    {
                        Console.WriteLine(
                            transfer.OrderTransfer());
                    }

                    if (item is IMiniBar minibar)
                    {
                        Console.WriteLine(
                            minibar.UseMiniBar());
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}