namespace LR5.Models;

public class Client
{
    public string FirstName { get; }
    public string LastName { get; }

    public Room Room { get; private set; }

    public Client(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Имя не может быть пустым");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Фамилия не может быть пустой");

        FirstName = firstName;
        LastName = lastName;
    }

    public bool HasRoom() => Room != null;

    public void AssignRoom(Room room)
    {
        if (room == null)
            throw new ArgumentNullException(nameof(room));

        if (Room != null)
            throw new InvalidOperationException("У клиента уже есть номер");

        room.Occupy();

        Room = room;
    }

    public void LeaveRoom()
    {
        if (Room == null)
            throw new InvalidOperationException("Клиент не заселен");

        Room.Free();

        Room = null;
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName}";
    }
}