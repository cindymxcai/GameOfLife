using System.Collections.Generic;

namespace GameOfLife
{
    public class CellFilter
    {
        private static Grid _currentGenGrid;

        public CellFilter(Grid currentGenGrid)
        {
            _currentGenGrid = currentGenGrid;
        }
        public static IEnumerable<(int, int)> FindNeighbouringCells(int currentRow, int currentCol)
        {
            var inBoundCells = new List<(int, int)>();
            for (var i = currentRow - 1; i <= currentRow + 1; i++)
            {
                for (var j = currentCol - 1; j <= currentCol + 1; j++)
                {
                    if (i < 0 || i >= _currentGenGrid.Row || j < 0 || j >= _currentGenGrid.Col)
                    {
                    }
                    else if ((i, j) != (currentRow, currentCol))
                    {
                        inBoundCells.Add((i, j));
                    }
                }
            }
            return inBoundCells;
        }
         
        
        public static int GetSurroundingLiveCells(Grid currentGenGrid,IEnumerable<(int, int)> inBoundCells)
        {
            var counter = 0;
            foreach (var (x, y) in inBoundCells)
            {
                if (currentGenGrid.GetCell(x,y).IsAlive)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}