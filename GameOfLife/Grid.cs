using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid
    {
        private readonly int _col;
        
        private CellStatus[,] GameGrid { get; }


        public Grid(int row, int col)
        {
            _col = col;
            
            GameGrid = new CellStatus[row, col];
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    GameGrid[r, c] = CellStatus.Dead;
                }
            }
        }

        public void SetRow(int currentRow, IEnumerable<CellStatus> gridRow)
        {
            var index = 0;
            foreach (var cell in gridRow)
            {
                GameGrid[currentRow, index] = cell;
                index++;
            }        
        }
        
        public List<CellStatus> GetRow(int rowNumberToGet)
        {
            var row = new List<CellStatus>();
            for (var currentCol = 0; currentCol < _col; currentCol++)
            {
                row.Add(GameGrid[rowNumberToGet, currentCol]);
            }

            return row;
        }
    }
}