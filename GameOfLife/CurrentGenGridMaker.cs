
namespace GameOfLife
{
    public class CurrentGenGridMaker
    {
        public static Grid MakeGrid( IRowGetter rowGetter)
        {
            var (row, col) = LineParser.GetSize(rowGetter.GetNextLine());
            
            if (row == 0 || col == 0)
            {
                throw new InvalidInputException("Cannot make a 0x0 grid!");
            }
            var createdGrid = new Grid(row, col);
            
            for (var currentRow = 0; currentRow < row; currentRow++)
            {
                createdGrid.SetRow(currentRow, LineParser.GetGridRow(rowGetter.GetNextLine()));
            }
            return createdGrid;
        }
    }
}