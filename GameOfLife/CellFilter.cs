using System.Collections.Generic;

namespace GameOfLife
{
    public static class CellFilter
    {
        public static IEnumerable<(int, int)> FindNeighbouringCells(int currentRow, int currentCol, int maxRow, int maxCol)
        {
            var neighbouringCells = new List<(int, int)>();
            for (var row = currentRow -1; row <= currentRow + 1; row++)
            {
                for (var col = currentCol - 1; col <= currentCol + 1; col++)
                {
                    var (tempRow, tempCol) = HandleWrapGrid(row, col, maxRow, maxCol);
                    
                    if ((row, col) != (currentRow, currentCol))
                    {
                        neighbouringCells.Add((tempRow, tempCol));
                    }
                }
            }
            return neighbouringCells;
        }

        
        private static (int, int) HandleWrapGrid(int row, int col, int maxRow, int maxCol)
        {
            var tempRow = row;
            var tempCol = col;
            
            if (row < 0 || row >= maxRow)
            {
                if (row < 0)
                {
                    tempRow = maxRow-1;
                }
                else if (row >= maxRow)
                {
                    tempRow = 0;
                }
            }

            if (col < 0 || col >= maxCol)
            {
                if (col < 0)
                {
                    tempCol = maxCol - 1;
                }
                else if (col >= maxCol)
                {
                    tempCol = 0;
                }
            }

            return (tempRow, tempCol);
        }


        public static int GetSurroundingLiveCells(Grid currentGenGrid, IEnumerable<(int, int)> inBoundCells)
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