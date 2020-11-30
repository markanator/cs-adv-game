/*
 * Escape Hanoi Hilton
 * By: Mark Ambrocio
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FinalGame_MarkAmbrocio
{
    class World
    {
        protected Player MainPlayer;
        public List<Room> GameRooms = new List<Room>();

        public World()
        {
            MainPlayer = new Player();
            // create rooms
            GameRooms.Add(new Room("You have been captured and are being held captive.", new[] { "1. Continue." }));
            GameRooms.Add(new Room("this is the 1st description", new[] { "1. next" }));
            GameRooms.Add(new Room("this is the 2nd description", new[] { "1. fin" }));

            // now connect rooms
            GameRooms[0].AddConnectedRooms(new[] { GameRooms[1] });
            GameRooms[1].AddConnectedRooms(new[] { GameRooms[2] });
            GameRooms[2].AddConnectedRooms(new[] { GameRooms[0] });
        }
    }
}
