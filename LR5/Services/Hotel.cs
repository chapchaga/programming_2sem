using LR5.Models;

namespace LR5.Services;

public class Hotel
{
    private List<Room> rooms = new();
    private List<Client> clients = new();

    public void AddRoom(Room room)
    {
        if (room == null)
            throw new ArgumentNullException(nameof(room));

        if (rooms.Any(r => r.Number == room.Number))
            throw new InvalidOperationException("Номер уже существует");

        rooms.Add(room);
    }

    public void AddClient(Client client)
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client));

        clients.Add(client);
    }

    public Room FindFreeRoomByType(RoomType type)
    {
        var room = rooms.FirstOrDefault(r => !r.IsOccupied && r.Type == type);

        if (room == null)
            throw new Exception($"Нет свободных номеров типа {type}");

        return room;
    }

    public void CheckIn(Client client, RoomType type)
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client));

        var room = FindFreeRoomByType(type);
        client.AssignRoom(room);
    }

    public void CheckOut(Client client)
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client));

        client.LeaveRoom();
    }

    public Client FindClientByLastName(string lastName)
    {
        var client = clients.FirstOrDefault(c =>
            c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

        if (client == null)
            throw new Exception("Клиент не найден");

        return client;
    }

    public void ShowRooms()
    {
        if (rooms.Count == 0)
            throw new Exception("Нет номеров");

        foreach (var room in rooms)
            Console.WriteLine(room);
    }
   public void ShowClients()
    {
        if (clients.Count == 0)
        {
            Console.WriteLine("Нет клиентов");
            return;
        }

        for (int i = 0; i < clients.Count; i++)
        {
            var c = clients[i];

            Console.WriteLine($"{i + 1}. {c}" +
                (c.HasRoom() ? $" -> номер {c.Room.Number}" : " (без номера)"));
        }
    }
}