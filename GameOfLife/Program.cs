using System;

namespace GameOfLife
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Game Of Life!");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Choose a configuration number to start");
            Console.WriteLine("then press n to generate next generation, or any key to choose a new configuration");
            Console.ResetColor();
            Simulator.ConfigureSimulation();
        }
    }
}