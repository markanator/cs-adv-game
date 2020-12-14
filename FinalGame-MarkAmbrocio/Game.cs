/*
 * Escape Hanoi Hilton
 * By: Mark Ambrocio
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Figgle;
using Pastel;

namespace FinalGame_MarkAmbrocio
{
    class Game
    {
        private World NewWorld;
        public bool EndGame;

        public Game()
        {
            EndGame = false;
            NewWorld = new World(this);
        }

        public void Run()
        {
            Intro();

            // Start Game
            while(true)
            {
                NewWorld.GRooms["A1"].RenderRoom();

                if (EndGame) break;
            }
        }

        public void EndGameFn()
        {
            EndGame = true;
        }

        private void Intro()
        {
            ConsoleColor prev = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine(FiggleFonts.Wavy.Render("Escape Hanoi Hilton"));

            WriteLine("\n\nYour plane was shot down during a skirmish with some North Atropian Planes");
            WriteLine("You crash land near the coast only to find North Atropian Soldiers waiting for you.");
            WriteLine("They place you under arrest and blindfold you. Your fate is unknown....");
            WriteLine("\n\nA Game By: Mark Ambrocio.");
            ForegroundColor = prev;
            WriteLine("\n\nPress any key to continue...");
            ReadKey();
        }

        
    }
}
