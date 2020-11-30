using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FinalGame_MarkAmbrocio
{
    class Game
    {
        private World NewWorld;

        public Game()
        {
            NewWorld = new World();
        }

        public void Run()
        {
            Intro();

            // Start Game
            NewWorld.GameRooms[0].RenderRoom();
        }

        private void Intro()
        {
            WriteLine("Wake up, there's no time to sleep.");
            WriteLine("\n\nPress any key to continue...");
            ReadKey();
        }
    }
}
