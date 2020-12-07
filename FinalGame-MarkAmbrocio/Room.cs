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
        public List<string> RoomOptions = new List<string>();
        public List<Room> ConnectedRoom = new List<Room>();
        // for Room Actions
        private Random Rando = new Random();
        private Room ActivePrevRoom;
        private string ActivePrevChoice;
        private string RoomActionsTakenText;
        private bool HasVisited = false;

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
            RoomActionsManager();
            WriteLine(RoomTitle);
            WriteLine("\n" +
                RoomDescription.Pastel("#ffffff") +
                $"{RoomActionsTakenText}");

            if (this.RoomTitle != "S1" || this.RoomTitle != "X1" || this.RoomTitle != "Credits")
            {
                // only display if not in rooms: S1,X1 or Credits
                MainPlayer.DisplayStatBar();
            }

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
                ConnectedRoom[0].ActivePrevChoice = "1";
                ConnectedRoom[0].ActivePrevRoom = this;
                ConnectedRoom[0].RenderRoom();
            } 
            else if (playerChoice == "2")
            {
                if (ConnectedRoom.Count > 1)
                {
                    ConnectedRoom[1].ActivePrevChoice = "2";
                    ConnectedRoom[1].ActivePrevRoom = this;
                    ConnectedRoom[1].RenderRoom();
                }
                else
                {
                    // option doesnt exist render room again
                    HasVisited = true;
                    RenderRoom();
                }
            }
            else
            {
                // rerender current room
                HasVisited = true;
                RenderRoom();
            }
        }
    
        private void RoomActionsManager()
        {
            //c2a30a
            string infoDarkYellow = "#967e06";
            string infoDarkRed = "#6b120c";
            switch (RoomTitle)
            {
                case "A1":
                    MainPlayer.ResetStats();
                    break;
                case "A2":
                    MainPlayer.PickupKey(Player.KEYTYPE.REG);
                    RoomActionsTakenText = "\n\nRegular Key++".Pastel(infoDarkYellow);
                    break;
                case "A3":
                    MainPlayer.PickupKey(Player.KEYTYPE.REG);
                    int moral1 = Rando.Next(2, 5);
                    MainPlayer.UpdateMorality(moral1, "sub");
                    RoomActionsTakenText = "\n\nMorality--. 0 Americans Rescued.".Pastel(infoDarkYellow);
                    break;
                case "A4":
                    MainPlayer.UseKey(Player.KEYTYPE.REG);
                    break;
                case "A5":
                    if (ActivePrevChoice == "1")
                    {
                        MainPlayer.PickupKey(Player.KEYTYPE.BOSS);
                        RoomActionsTakenText = "\n\nBoss Key++".Pastel(infoDarkYellow);
                    }
                    else if (ActivePrevChoice == "2")
                    {
                        RoomActionsTakenText = "\n\nMissed Key".Pastel(infoDarkRed);
                    }
                    break;
                case "A6":
                    MainPlayer.TakeDamage(10);
                    break;
                case "A7":
                    if (!MainPlayer.HasBossKey)
                    {
                        RoomOptions[0] = "1. Unlock Cell Doors (Locked)".Pastel("#2e2c2c");
                        ConnectedRoom[0] = ConnectedRoom[1];
                    }
                    break;
                case "A8":
                    int moral2 = Rando.Next(3, 6);
                    MainPlayer.UpdateMorality(moral2, "sub");
                    break;
                case "A12":
                    if (ActivePrevRoom.RoomTitle == "A8")
                    {
                        if (MainPlayer.Morality > 6)
                        {
                            ConnectedRoom[1].RenderRoom();
                        }
                        else
                        {
                            ConnectedRoom[0].RenderRoom();
                        }
                    }
                    else if (ActivePrevRoom.RoomTitle == "A10")
                    {
                        if (MainPlayer.POWRescued > 5 || MainPlayer.Morality > 5)
                        {
                            ConnectedRoom[1].RenderRoom();
                        }
                        else
                        {
                            ConnectedRoom[0].RenderRoom();
                        }
                    }
                    break;
                case "A9":
                    if (ActivePrevRoom.RoomTitle == "A12")
                    {
                        MainPlayer.TakeDamage(10);
                    }
                    break;
                case "A10":
                    MainPlayer.RescuePOW(5);
                    int moral3 = Rando.Next(3, 6);
                    MainPlayer.UpdateMorality(moral3, "sub");
                    break;
                case "A11":
                    break;

                // B SERIES
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
                        int moral4 = Rando.Next(1, 5);
                        MainPlayer.UpdateMorality(moral4,"add");
                        if (MainPlayer.PlayerHealth <= 4)
                        {
                            MainPlayer.RestoreHealth(5);
                        }
                        else
                        {
                            MainPlayer.RestoreHealth(moral4);
                        }
                        RoomDescription += $"\n\nHP++. Morality++. 3 Americans Rescued. ".Pastel(infoDarkYellow);
                    } 
                    else if (ActivePrevRoom != null && ActivePrevRoom.RoomTitle == "B3")
                    {
                        MainPlayer.RescuePOW(1);
                        MainPlayer.UpdateMorality(3, "add");
                        RoomActionsTakenText = "\n\nOnly 1 Inmate left with you.".Pastel(infoDarkYellow);
                    }
                    break;
                case "B6":

                    break;

                default:
                    break;
            }
        }
    }
}
