using System;

namespace GameOfLife
{
    public class Simulator
    {
        public static void GetConfiguration()
        {
            Console.WriteLine("1. Blinker");
            Console.WriteLine("2. Pulsar");
            Console.WriteLine("3. Toad");
            Console.WriteLine("4. Glider");

           var configuration =  Console.ReadLine();
           switch (configuration)
           {
               case "1":
                   SimulateGame(new[] {"3,3", "...", "***", "..."});
                   break;
               case "2":
                   SimulateGame(new[]
                   {
                       "17,17",
                       ".................",
                       "..................",
                       "....***...***....",
                       ".................",
                       "..*....*.*....*..",
                       "..*....*.*....*..",
                       "..*....*.*....*..",
                       "....***....***.....",
                       ".................",
                       "....***....***.....",
                       "..*....*.*....*..",
                       "..*....*.*....*..",
                       "..*....*.*....*..",
                       ".................",
                       "....***...***....",
                       ".................",
                       ".................."
                   });
                   break;
               case "3":
                   SimulateGame(new[] {"6,6", "......", "......", "..***,", ".***..", "......", "......"});
                   break;
           }

           if (configuration == "4")
           {
               SimulateGame(new[] {"5,5", ".....", ".*...", "..**.", ".**..", "....."});
           }
           else 
           {
               Console.Write("Invalid Configuration");
               Console.ReadLine();
           }
        }

        private static void SimulateGame(string [] configuration)
        {
            var lineReader = new LineReader(configuration);
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(lineReader);
            Display.Grid(currentGen.CurrentGrid);
            
            while (Console.ReadLine() == "m")
            {
                var filter = new CellFilter(currentGen.CurrentGrid);
                var nextGen = new NextGenGridMaker(currentGen.CurrentGrid, filter);
                nextGen.GetNewGeneration(currentGen.CurrentGrid);
                Display.Grid(nextGen.NextGenGrid);
                currentGen.CurrentGrid = nextGen.NextGenGrid;
            }
        }
    }
}