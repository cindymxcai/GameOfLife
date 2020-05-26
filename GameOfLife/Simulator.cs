using System;

namespace GameOfLife
{
    public class Simulator
    {
        public void SimulateGame()
        {
            var rowGetter = new RowGetter(new[] {"66", "......","......", "..***.", ".***..","......","......"});
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(rowGetter);
            Display.CurrentGen(currentGen.CurrentGrid);
            
            while (Console.ReadLine() == "m")
            {
                var filter = new CellFilter(currentGen.CurrentGrid);
                var nextGen = new NextGenGridMaker(currentGen.CurrentGrid, filter);
                nextGen.GetNewGeneration(currentGen.CurrentGrid);
                Display.NewGeneration(nextGen.NewGrid);
                currentGen.CurrentGrid = nextGen.NewGrid;
            }
            
        }
    }
}