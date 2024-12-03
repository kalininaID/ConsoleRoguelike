using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    internal class SplitRoomHalls
    {
        public List<Room> roomAndHalls;

        public List<Room> halls; 
        public List<Room> rooms;

        public SplitRoomHalls(List<Room> roomAndHalls) 
        { 
            this.roomAndHalls = roomAndHalls;
            this.halls = new List<Room>(); 
            this.rooms = new List<Room>();
        }
        public List<Room> GetRoom()
        {
            foreach (Room room in roomAndHalls)
            {
                if (room.height != 1 && room.width != 1)
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public List<Room> GetHalls()
        {
            foreach (Room hall in roomAndHalls)
            {
                if (hall.height == 1 || hall.width == 1)
                {
                    halls.Add(hall);
                }
            }
            return halls;
        }
    }
}
