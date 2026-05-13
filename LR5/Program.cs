using LR5.Models;
using LR5.Services;
using LR5.Utils;
using System.Text;

namespace LR5;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Hotel hotel = new Hotel();

        while (true)
        {
            Console.WriteLine("\n1. Добавить номер");
            Console.WriteLine("2. Добавить клиента");
            Console.WriteLine("3. Заселить");
            Console.WriteLine("4. Выселить");
            Console.WriteLine("5. Список номеров");
            Console.WriteLine("6. Список клиентов");
            Console.WriteLine("0. Выход");

            int choice = InputHelper.ReadChoice("Выбор: ", 0, 6);

            try
            {
                switch (choice)
                {
                    case 1:
                        int num = InputHelper.ReadPositiveInt("Номер: ");
                        double price = InputHelper.ReadPositiveDouble("Цена: ");
                        int type = InputHelper.ReadChoice("Тип 0 - Econom, 1 - Standard, 2 - Lux, 3 - VIP : ", 0, 3);

                        hotel.AddRoom(new Room(num, price, (RoomType)type));
                        break;

                    case 2:
                        string name = InputHelper.ReadString("Имя: ");
                        string surname = InputHelper.ReadString("Фамилия: ");

                        hotel.AddClient(new Client(name, surname));
                        break;

                    case 3:
                        string lastName = InputHelper.ReadString("Фамилия клиента: ");
                        int t = InputHelper.ReadChoice("Тип 0 - Econom, 1 - Standard, 2 - Lux, 3 - VIP : ", 0, 3);

                        var client = hotel.FindClientByLastName(lastName);
                        hotel.CheckIn(client, (RoomType)t);
                        break;

                    case 4:
                        string ln = InputHelper.ReadString("Фамилия клиента: ");
                        var c = hotel.FindClientByLastName(ln);

                        hotel.CheckOut(c);
                        break;

                    case 5:
                        hotel.ShowRooms();
                        break;

                    case 6:
                        hotel.ShowClients();
                        break;

                    case 0:
                        return;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка ввода: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ошибка операции: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}   