/*
 * Escape Hanoi Hilton
 * By: Mark Ambrocio
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;

namespace FinalGame_MarkAmbrocio
{
    class World
    {
        protected Player MainPlayer;
        private string GameRoomFile = "FinalGameRooms.txt";
        public IDictionary<string, Room> GRooms = new Dictionary<string, Room>();

        public World(Game aGame)
        {
            MainPlayer = new Player();

            string[] contents = File.ReadAllLines(GameRoomFile);

            for (int i=0; i< contents.Length; i += 3)
            {
                string[] topLines = contents[i].Split(",");
                string[] botLines = contents[i+1].Split(",");
                string RoomTitle = topLines[0];
                string RoomDesc = topLines[1];
                string option1 = botLines[0];
                string option2 = "";
                if (botLines.Length > 1)
                {
                    option2 = botLines[1];
                }
                // all content read => time to insert
                GRooms.Add(RoomTitle, new Room(MainPlayer, aGame, RoomTitle, RoomDesc, new[] { option1, option2 }));
            }

            // create connections
            #region CREATING CONNECTIONS
            GRooms["A1"].AddConnectedRooms(new[] { 
                GRooms["A2"],
                GRooms["A3"]
            });
            GRooms["A2"].AddConnectedRooms(new[] {
                GRooms["B1"],
                GRooms["B2"]
            });
            GRooms["A3"].AddConnectedRooms(new[] {
                GRooms["A4"]
            });
            GRooms["A4"].AddConnectedRooms(new[] {
                GRooms["A5"],
                GRooms["A5"]
            });
            GRooms["A5"].AddConnectedRooms(new[] {
                GRooms["A7"],
                GRooms["A6"]
            });
            GRooms["A6"].AddConnectedRooms(new[] {
                GRooms["X1"]
            });
            GRooms["A7"].AddConnectedRooms(new[] {
                GRooms["A10"],
                GRooms["A8"]
            });
            GRooms["A8"].AddConnectedRooms(new[] {
                GRooms["A12"],
                GRooms["A12"]
            });
            GRooms["A9"].AddConnectedRooms(new[] {
                GRooms["X1"]
            });
            GRooms["A10"].AddConnectedRooms(new[] {
                GRooms["A12"]
            });
            GRooms["A11"].AddConnectedRooms(new[] {
                GRooms["S1"]
            });
            GRooms["S1"].AddConnectedRooms(new[] {
                GRooms["Credits"]
            });
            GRooms["A12"].AddConnectedRooms(new[] {
                GRooms["A9"],
                GRooms["A11"]
            });

            // B SERIES
            GRooms["B1"].AddConnectedRooms(new[] {
                GRooms["B4"],
                GRooms["B3"]
            });
            GRooms["B2"].AddConnectedRooms(new[] {
                GRooms["X1"]
            });
            GRooms["B3"].AddConnectedRooms(new[] {
                GRooms["B5"],
                GRooms["B6"]
            });
            GRooms["B4"].AddConnectedRooms(new[] {
                GRooms["B5"]
            });
            GRooms["B5"].AddConnectedRooms(new[] {
                GRooms["B6"]
            });
            GRooms["B6"].AddConnectedRooms(new[] {
                GRooms["A4"],
                GRooms["B7"]
            });
            GRooms["B7"].AddConnectedRooms(new[] {
                GRooms["X1"]
            });
            GRooms["X1"].AddConnectedRooms(new[] {
                GRooms["A1"],
                GRooms["Credits"]
            });


            #endregion
        }
    }
}
