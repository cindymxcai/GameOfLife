using System;

namespace GameOfLife
{
    internal static class Display
    { 
        public static void Grid(Grid grid)
        {
            Console.Clear();
            Console.SetCursorPosition(0,5);
            for (int r = 0; r < grid.Row; r++)
            {
                for (int c = 0; c < grid.Col; c++)
                {
                    if (grid.GetCell(r, c).ToString() == "██")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(grid.GetCell(r,c).ToString());
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(grid.GetCell(r,c).ToString());
                    }
                }  
                Console.WriteLine();
            } 
        }
    }
}