using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelSystem
{
    class Hotel
    {
        private List<Room> rooms = new List<Room>();

        public void AddRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            if (rooms.Any(existingRoom => existingRoom.Number == room.Number))
            {
                throw new InvalidOperationException(
                    "Номер с таким номером комнаты уже существует");
            }

            rooms.Add(room);
        }

        public decimal GetAveragePrice()
        {
            if (rooms.Count == 0)
            {
                throw new InvalidOperationException(
                    "В гостинице нет номеров");
            }

            decimal sum = 0;

            foreach (Room room in rooms)
            {
                sum += room.FinalPrice;
            }

            return sum / rooms.Count;
        }

        public void ShowAllRooms()
        {
            if (rooms.Count == 0)
            {
                Console.WriteLine("Список номеров пуст");
                return;
            }

            foreach (Room room in rooms)
            {
                Console.WriteLine(room.GetInfo());
            }
        }
    }
}
