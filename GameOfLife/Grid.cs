
namespace GameOfLife
{
    public class Grid
    {
        public readonly int Col;
        public readonly int Row;
        
        private Cell[,] GameGrid { get; }

        public Grid(int row, int col)
        {
            Row = row;
            Col = col;
            
            GameGrid = new Cell[row, col];
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < col; c++)
                {
                    GameGrid[r, c] = new Cell(false);
                }
            }
        }

        public void SetCell(int currentRow, int currentCol, Cell cell)
        {
            GameGrid[currentRow, currentCol] = cell;
        }
        
        public Cell GetCell(int rowNumberToGet, int colNumberToGet)
        { 
            return GameGrid[rowNumberToGet, colNumberToGet];
        }
    }
}