namespace GameOfLife
{
    public class NextGenGridMaker
    {
        public  Grid NextGenGrid { get; }

        public NextGenGridMaker(Grid currentGenGrid)
        {
            NextGenGrid = new Grid(currentGenGrid.Row, currentGenGrid.Col);
        }

        public void GetNewGeneration(Grid currentGenGrid)
        {
            for (var r = 0; r < NextGenGrid.Row; r++)
            {
                for (var c = 0; c < NextGenGrid.Col; c++)
                {
                    var neighbouringCells = CellFilter.FindNeighbouringCells(r, c, currentGenGrid.Row, currentGenGrid.Col);
                    var surroundingLiveCells = CellFilter.GetSurroundingLiveCells(currentGenGrid, neighbouringCells);
                    
                    var willBeAlive = WillBeAlive(currentGenGrid.GetCell(r, c).IsAlive, surroundingLiveCells);
                    
                    NextGenGrid.SetCell(r,c, new Cell(willBeAlive));
                }
            }
        }

        public static bool WillBeAlive(bool wasAlive, int surroundingLiveCells)
        {
            if (wasAlive && surroundingLiveCells<2 || wasAlive && surroundingLiveCells > 3) return false;               
            if (wasAlive && surroundingLiveCells==2 || wasAlive && surroundingLiveCells == 3) return true;
            return !wasAlive && surroundingLiveCells == 3;
        }
    }
}