/*
 * Escape Hanoi Hilton
 * By: Mark Ambrocio
 * 
 */

using System;
using static System.Console;

namespace FinalGame_MarkAmbrocio
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Escape Hanoi Hilton By: Mark Ambrocio";
            Game newGame = new Game();
            newGame.Run();

            WriteLine("MAIN:: Press any key to exit.");
            ReadKey(true);
        }
    }
}
