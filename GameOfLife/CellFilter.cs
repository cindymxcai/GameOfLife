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
        public static IEnumerable<(int, int)> FindNeighbouringCells(int currentRow, int currentCol, int maxRow, int maxCol)
        {
            var neighbouringCells = new List<(int, int)>();
            for (var row = currentRow -1; row <= currentRow + 1; row++)
            {
                for (var col = currentCol - 1; col <= currentCol + 1; col++)
                {
                    var tempRow = row;
                    var tempCol = col;
                    if (row < 0 || row >= maxRow)
                    {
                        if (row < 0)
                        {
                            tempRow = maxRow - 1;
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

                    if ((row, col) != (currentRow, currentCol))
                    {
                        neighbouringCells.Add((tempRow, tempCol));
                    }
                }
            }
            return neighbouringCells;
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