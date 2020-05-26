namespace GameOfLife
{
    public class CurrentGenGridMaker
    {
        public Grid CurrentGrid { get; set; }
        public void MakeGrid( IRowGetter rowGetter)
        {
            var (row, col) = LineParser.GetSize(rowGetter.GetNextLine());
            
            if (row == 0 || col == 0)
            {
                throw new InvalidInputException("Cannot make a 0x0 grid!");
            }
            CurrentGrid = new Grid(row, col);
            
            for (var currentRow = 0; currentRow < row; currentRow++)
            {
                var line = rowGetter.GetNextLine();
                var parsedLine= LineParser.GetGridRow(line);
                for (var currentCol = 0; currentCol < col; currentCol++)
                {
                    var cell = parsedLine[currentCol];
                    CurrentGrid.SetCell(currentRow, currentCol, cell);
                }
            }
        }
    }
}