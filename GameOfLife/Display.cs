using System;

namespace GameOfLife
{
    internal static class Display
    {
        public static void CurrentGen(Grid generation)
        {
            Console.Write("Generation 0:");
            Console.WriteLine();
            for (int r = 0; r < generation.Row; r++)
            {
                for (int c = 0; c < generation.Col; c++)
                { 
                    Console.Write(generation.GetCell(r,c).ToString());
                }  
                Console.WriteLine();
            } 
        }
        
        public static void NewGeneration(Grid generation)
        {
            Console.Clear();
            Console.SetCursorPosition(0,5);
            for (int r = 0; r < generation.Row; r++)
            {
                for (int c = 0; c < generation.Col; c++)
                { 
                    Console.Write(generation.GetCell(r,c).ToString());
                }  
                Console.WriteLine();
            } 
        }
    }
}