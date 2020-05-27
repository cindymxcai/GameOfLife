using System;

namespace GameOfLife
{
    public static class Simulator
    {
        public static void ConfigureSimulation()
        {
            while (true)
            {
                Console.WriteLine("1. Blinker");
                Console.WriteLine("2. Pulsar");
                Console.WriteLine("3. Toad");
                Console.WriteLine("4. Glider");
                Console.WriteLine("5. Random");
                var random = new Random();
                const string chars = ".*";
                var configuration = Console.ReadLine();
                switch (configuration)
                {
                    case "1":
                        SimulateGame(new[] {"5,5", ".....", ".....", ".***.", ".....", "....."});
                        break;
                    case "2":
                        SimulateGame(new[]
                        {
                            "17,17", "..................", "..................", "....***...***....",
                            ".................", "..*....*.*....*..", "..*....*.*....*..", "..*....*.*....*..",
                            "....***...***....", ".................", "....***...***....", "..*....*.*....*..",
                            "..*....*.*....*..", "..*....*.*....*..", ".................", "....***...***....",
                            ".................", ".................."
                        });
                        break;
                    case "3":
                        SimulateGame(new[] {"6,6", "......", "......", "..***.", ".***..", "......", "......"});
                        break;
                    case "4":
                        SimulateGame(new[]
                        {
                            "10,10", "..........", ".*........", "..**......", ".**.......", "..........",
                            "..........", "..........", "..........", "..........", ".........."
                        });
                        break;
                    case "5":
                        SimulateGame(new[]
                        {
                            "6,6",
                            $"{chars[random.Next(0, chars.Length)]}, {chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]}",
                            $"{chars[random.Next(0, chars.Length)]}, {chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]}",
                            $"{chars[random.Next(0, chars.Length)]}, {chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]}",
                            $"{chars[random.Next(0, chars.Length)]}, {chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]}",
                            $"{chars[random.Next(0, chars.Length)]}, {chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]}",
                            $"{chars[random.Next(0, chars.Length)]}, {chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]},{chars[random.Next(0, chars.Length)]}",
                        });
                        break;
                    default: continue;
                }
            }
        }

        private static void SimulateGame(string[] configuration)
        {
            var lineReader = new LineReader(configuration);
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(lineReader);
            Display.Grid(currentGen.CurrentGrid);
            do
            {
                while (!Console.KeyAvailable)
                {
                    var nextGen = new NextGenGridMaker(currentGen.CurrentGrid);
                    nextGen.GetNewGeneration(currentGen.CurrentGrid);
                    Display.Grid(nextGen.NextGenGrid);
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                    currentGen.CurrentGrid = nextGen.NextGenGrid;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.N);
        }
    }
}