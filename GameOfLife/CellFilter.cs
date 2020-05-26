using System.Collections.Generic;

namespace GameOfLife
{
    public class CellFilter
    {
        private static Grid _oldGrid;

        public CellFilter(Grid oldGrid)
        {
            _oldGrid = oldGrid;
        }
        public IEnumerable<(int, int)> FindNeighbouringCells(int currentRow, int currentCol)
        {
            var inBoundCells = new List<(int, int)>();
            for (var i = currentRow - 1; i <= currentRow + 1; i++)
            {
                for (var j = currentCol - 1; j <= currentCol + 1; j++)
                {
                    if (i < 0 || i >= _oldGrid.Row || j < 0 || j >= _oldGrid.Col)
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
         
        
        public int GetSurroundingLiveCells(Grid oldGeneration,IEnumerable<(int, int)> inBoundCells)
        {
            var counter = 0;
            foreach (var (x, y) in inBoundCells)
            {
                if (oldGeneration.GetCell(x,y).IsAlive)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}