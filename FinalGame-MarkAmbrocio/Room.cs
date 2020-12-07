/*
 * Escape Hanoi Hilton
 * By: Mark Ambrocio
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Pastel;

namespace FinalGame_MarkAmbrocio
{
    class Room
    {
        private string RoomTitle;
        private string RoomDescription;
        private Player MainPlayer;
        private Room PreviousRoomA;
        private Room PreviousRoomB;
        private Room ActivePrevRoom;
        public List<string> RoomOptions = new List<string>();
        public List<Room> ConnectedRoom = new List<Room>();
        private Random Rando = new Random();

        public Room(Player aPlayer,string title,string desc, string[] inputRoomOptions)
        {
            MainPlayer = aPlayer;
            RoomTitle = title;
            RoomDescription = desc;
            foreach (string R in inputRoomOptions)
            {
                RoomOptions.Add(R);
            } 
        }
        //public Room(Room prevRoomA, Player aPlayer, string title, string desc, string[] inputRoomOptions)
        //{
        //    PreviousRoomA = prevRoomA;
        //    MainPlayer = aPlayer;
        //    RoomTitle = title;
        //    RoomDescription = desc;
        //    foreach (string R in inputRoomOptions)
        //    {
        //        RoomOptions.Add(R);
        //    }
        //}
        //public Room(Room prevRoomA,Room prevRoomB, Player aPlayer, string title, string desc, string[] inputRoomOptions)
        //{
        //    PreviousRoomA = prevRoomA;
        //    PreviousRoomB = prevRoomB;
        //    MainPlayer = aPlayer;
        //    RoomTitle = title;
        //    RoomDescription = desc;
        //    foreach (string R in inputRoomOptions)
        //    {
        //        RoomOptions.Add(R);
        //    }
        //}

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
            RoomActionsManager(); // also holds stats bar
            WriteLine(RoomTitle);
            WriteLine("\n"+RoomDescription.Pastel("#ffffff")+"\n\n");


            MainPlayer.DisplayStatBar();

            ConsoleColor prevColor = ForegroundColor;
            ForegroundColor = ConsoleColor.White;

            WriteLine("\n=== Current Options ===");
            foreach (string rOption in RoomOptions)
            {
                WriteLine(rOption);
            }

            ForegroundColor = prevColor;
            ReadplayerInput();

        }
    
        public void SetPrevRoom(Room prevRoom, string AorB)
        {
            if (AorB.ToLower() == "a")
            {
                PreviousRoomA = prevRoom;
            } else
            {
                PreviousRoomB = prevRoom;
            }
        }

        private void ReadplayerInput()
        {
            WriteLine("\nWhat should you do?".Pastel("#ff0000"));
            string playerChoice = ReadLine().Trim().ToLower();
            if (playerChoice == "1")
            {
                if (ConnectedRoom.Count == 0)
                {
                    // Escape to Main line
                    return;
                }
                ConnectedRoom[0].ActivePrevRoom = this;
                ConnectedRoom[0].RenderRoom();
            } 
            else if (playerChoice == "2")
            {
                if (ConnectedRoom.Count > 1)
                {
                    ConnectedRoom[1].ActivePrevRoom = this;
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
    
        private void RoomActionsManager()
        {
            //c2a30a
            string infoDarkYellow = "#967e06";
            switch (RoomTitle)
            {
                case "A1":
                    MainPlayer.ResetStats();
                    break;
                case "A2":
                    MainPlayer.PickupKey(Player.KEYTYPE.REG);
                    RoomDescription += "\n\nRegular Key++".Pastel(infoDarkYellow);
                    break;
                case "A3":
                    MainPlayer.PickupKey(Player.KEYTYPE.REG);
                    int moral1 = Rando.Next(2, 5);
                    MainPlayer.UpdateMorality(moral1, "sub");
                    RoomDescription += "\n\nMorality--. 0 Americans Rescued.".Pastel(infoDarkYellow);
                    break;
                case "A4":
                    MainPlayer.UseKey(Player.KEYTYPE.REG);
                    break;
                case "B1":
                    MainPlayer.UseKey(Player.KEYTYPE.REG);
                    int dam1 = Rando.Next(1, 3);
                    MainPlayer.TakeDamage(dam1);
                    break;
                case "B2":
                    MainPlayer.TakeDamage(10);
                    break;
                case "B3":
                    MainPlayer.UpdateMorality(2, "sub");
                    break;
                case "B4":
                    MainPlayer.RescuePOW(3);
                    break;
                case "B5":
                    if (ActivePrevRoom != null && ActivePrevRoom.RoomTitle == "B4")
                    {
                        int moral2 = Rando.Next(1, 5);
                        MainPlayer.UpdateMorality(moral2,"add");
                        if (MainPlayer.PlayerHealth <= 4)
                        {
                            MainPlayer.RestoreHealth(5);
                        }
                        else
                        {
                            MainPlayer.RestoreHealth(moral2);
                        }
                        RoomDescription += $"\n\nHP++. Morality++. 3 Americans Rescued. ".Pastel(infoDarkYellow);
                    } 
                    else if (ActivePrevRoom != null && ActivePrevRoom.RoomTitle == "B3")
                    {
                        MainPlayer.RescuePOW(1);
                        MainPlayer.UpdateMorality(3, "add");
                        RoomDescription += "\n\nOnly 1 Inmate left with you.".Pastel(infoDarkYellow);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
