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


            Clear();
            Outro();
            WriteLine("\n\nPress any key to exit to desktop.");
            ReadKey(true);
        }
        
        static void Outro()
        {
            WriteLine("\nThank you for playing!");
            WriteLine("\nReferences Used:");
            WriteLine("Columbia ITP Canvas & YouTube videos - Instructed by: Michael Hadley");
            WriteLine("MS Docs for C#");
            WriteLine("Hanoi Hilton was a Vietnam War Prison Camp read more: https://en.wikipedia.org/wiki/H%E1%BB%8Fa_L%C3%B2_Prison#Vietnam_War");
        }
    }
}
