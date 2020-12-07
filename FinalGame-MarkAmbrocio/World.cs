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
        //public List<Room> GameRooms = new List<Room>();
        public IDictionary<string, Room> GRooms = new Dictionary<string, Room>();

        public World()
        {
            MainPlayer = new Player();

            // create rooms, using dictionary :)
            #region ADDING ROOMS TO DICT
            GRooms.Add(
                    "A1",
                    new Room(MainPlayer,"A1",
                        "A single soldier watches over 10 cells. You dont know how many other POW are there with you.",
                        new[] { "1. Search Cell", "2. Contact Cell Neighbors" }
                    )
            );
            GRooms.Add(
                    "A2",
                    new Room(MainPlayer, "A2",
                        "You manage to find something to pick the lock, it looks promising. You also notice the cell door is in poor condition.",
                        new[] { "1. Unlock Cell and take out guard.", "2. Slam into door" }
                    )
            );
            GRooms.Add(
                    "A3",
                    new Room(
                        MainPlayer, "A3",
                        "You don't hear anyone next door on either side but you did find a way to open the door.",
                        new[] { "1. Pick Lock and sneak out" }
                    )
            ); 
            GRooms.Add(
                     "A4",
                     new Room(
                         MainPlayer, "A4",
                        "You make your way inside and notice a large glowing frame. A large key is held in there, must be important.\n\nYou hear footsteps nearby...",
                        new[] { "1. Hurry and break the glass to take key", "2. ignore the key" }
                 )
             );
            GRooms.Add(
                     "A5",
                     new Room(
                         MainPlayer, "A5",
                         "The key has the words \"Master Cell Door Control\". Hmmm...\n\n You start to walk around and manage to find two guards on break. You hide and try to listen to what they are saying... \nyou don't speak their language.",
                     new[] { "1. Ignore them, enter control room", "2. Charge them head on" }
                 )
             );
            GRooms.Add(
                     "A6",
                     new Room(
                         MainPlayer, "A6",
                         "You failed to see the third guard who quickly filled you with lead.",
                     new[] { "1. Continue..." }
                 )
             );
            GRooms.Add(
                     "A7",
                     new Room(
                         MainPlayer, "A7",
                         "There is a large primitive computer in the room with some numbers on a notepad.\n\nGuards: 103 || Prisoners: 456\n\nYou see an option for a large key to open cell doors, and an option to take a key for an escape vehicle. ",
                     new[] { "1. Unlock Cell Doors", "2. Take Key for escape vehicle" }
                 )
             );
            GRooms.Add(
                     "A8",
                     new Room(
                         MainPlayer, "A8",
                         "You sneak your way to the docks. There is a medium sized boat and no one around.",
                     new[] { "1. Take the boat and run!" }
                 )
             );
            
            GRooms.Add(
                     "A10",
                     new Room(
                         MainPlayer, "A10", 
                     "You start to hear sirens go off as the doors to cells start to open. Prisoners begin to riot and attack Atropian Guards. The guards are overwhelmed, but they are starting to use guns on your fellow POWs.\n\nYou start to hear large amounts of footsteps coming towards you.",
                     new[] { "1. Continue..." }
                 )
             );
            GRooms.Add(
                     "A12",
                     new Room(
                         MainPlayer, "A12",
                     "",
                     new[] { "" }
                 )
             );
            GRooms.Add(
                     "A9",
                     new Room(
                         MainPlayer, "A9",
                         "After leaving the dock you immediatley start to get shot at by Atropian Guards.",
                     new[] { "1. Continue..." }
                 )
             );
            GRooms.Add(
                     "A11",
                     new Room(
                         MainPlayer, "A11", 
                     "You make your way outside only to see total chaos. All the building are on fire and there are prisoner running all around facility.\n\nThe group of prisoners from your holding block point you to a small plane to escape. They can hold off the Atropian troops until the morning.",
                     new[] { "1. Continue." }
                 )
             );
            
            GRooms.Add(
                     "S1",
                     new Room(
                         MainPlayer, "S1", 
                     "You escaped! And you freed the remaining inmates, but they still need your help.",
                     new[] { "1. Credits." }
                 )
             );
            GRooms.Add(
                     "B1",
                     new Room(
                         MainPlayer, "B1",
                         "You sneak to the guard and take them out. You start hearing chatter on the guard's radio, routine check-ins. You now have keys to unlock these cells or escape.",
                     new[] { "1. Open Cells", "2. Escape Detention Block" }
                 )
             );
            GRooms.Add(
                     "B2",
                     new Room(
                         MainPlayer, "B2", 
                     "You were told to not make any noise when you were brought in. The Guard calls for back up and they begin to torture you.",
                     new[] { "1. Continue..." }
                 )
             );
            GRooms.Add(
                     "B3",
                     new Room(
                         MainPlayer, "B3", 
                     "You open the heavy door and peer outside... nothing. No one is outside.",
                     new[] { "1. Return to open cells and escape.", "2. Run..." }
                 )
             );
            GRooms.Add(
                     "B4",
                     new Room(
                         MainPlayer, "B4", 
                     "You spend a couple of minutes opening the cells. Out of the ten cells there where only three other with you. When you get done you notice radio silence...",
                     new[] { "1. Leave with inmates.." }
                 )
             );
            GRooms.Add(
                     "B5",
                     new Room(
                         MainPlayer, "B5", 
                     "You open the heavy door and peer outside... guards. You notice heavily armored guards in the distance walking your way.",
                     new[] { "1. RUN!" }
                 )
             );
            GRooms.Add(
                     "B6",
                     new Room(
                         MainPlayer, "B6",
                         "You run away from the detention center and make you way to the tallest building. Maybe they have something that can help you escape. But the door is locked...\n\nOut of the corner of your eye you see a guard walking to you..",
                     new[] { "1. hide in guard shack and take keys from guard." , "2. Break door open with rock." }
                 )
             );
            GRooms.Add(
                     "B7",
                     new Room(
                         MainPlayer, "B7",
                         "You attempted to break the door open but were caught by the guard.\n\nMaybe next time, wait it out... ",
                     new[] { "1. Continue.." }
                 )
             );
            GRooms.Add(
                     "X1",
                     new Room(MainPlayer, "X1",
                         "You were captured and passed out after being brutality beaten.\n\nPOWs need you, try again ?",
                     new[] { "1. Yes, this time we will escape!", "2. No, I like my cell." }
                 )
             );
            GRooms.Add(
                     "Credits",
                     new Room(MainPlayer, "Credits", "Thank you for playing!",
                     new[] { "1. Exit Game" }
                 )
             );
            #endregion

            //GRooms["A4"].SetPrevRoom(GRooms["B5"], "b");

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
                GRooms["A6"],
                GRooms["A7"]
            });
            GRooms["A6"].AddConnectedRooms(new[] {
                GRooms["X1"]
            });
            GRooms["A7"].AddConnectedRooms(new[] {
                GRooms["A10"],
                GRooms["A8"]
            });
            GRooms["A8"].AddConnectedRooms(new[] {
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
