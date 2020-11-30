using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FinalGame_MarkAmbrocio
{
    class Room
    {
        public string RoomDescription;
        public List<string> RoomOptions = new List<string>();
        public List<Room> ConnectedRoom = new List<Room>();

        public Room(string desc, string[] inputRoomOptions)
        {
            RoomDescription = desc;
            foreach (string R in inputRoomOptions)
            {
                RoomOptions.Add(R);
            }
            
        }
    
        public void AddConnectedRooms(Room[] connectedRooms)
        {
            foreach (Room CR in connectedRooms)
            {
                ConnectedRoom.Add(CR);
            }
        }
        
        public void RenderRoom()
        {
            Clear();
            WriteLine(RoomDescription);
            WriteLine("\n\n=== Current Options ===");
            foreach (string rOption in RoomOptions)
            {
                WriteLine(rOption);
            }
            ReadplayerInput();

        }
    
        private void ReadplayerInput()
        {
            WriteLine("\nWhat should you do?");
            string playerChoice = ReadLine().Trim().ToLower();
            if (playerChoice == "1")
            {
                ConnectedRoom[0].RenderRoom();
            } 
            else if (playerChoice == "2")
            {
                if (ConnectedRoom.Count > 1)
                {
                    ConnectedRoom[1].RenderRoom();
                } else
                {
                    // option doesnt exist render room again
                    RenderRoom();
                }
            } else
            {
                // rerender current room
                RenderRoom();
            }
        }
    }
}
