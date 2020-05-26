namespace GameOfLife
{
    public class NextGenGridMaker
    {
        private readonly CellFilter _cellFilter;
        public  Grid NewGrid { get; }

        public NextGenGridMaker(Grid oldGeneration, CellFilter cellFilter)
        {
            _cellFilter = cellFilter;
            NewGrid = new Grid(oldGeneration.Row, oldGeneration.Col);
        }

        public void GetNewGeneration(Grid oldGeneration)
        {
            
            for (var r = 0; r < NewGrid.Row; r++)
            {
                for (var c = 0; c < NewGrid.Col; c++)
                {
                    var validCells = _cellFilter.FindNeighbouringCells(r, c);
                    var surroundingLiveCells = _cellFilter.GetSurroundingLiveCells(oldGeneration, validCells);
                    var isAlive = TurnAlive(oldGeneration.GetCell(r, c).IsAlive, surroundingLiveCells);
                    NewGrid.GetCell(r, c).WillBeAlive = isAlive;
                }
            }
            UpdateGrid();
        }

        public bool TurnAlive(bool wasAlive, int surroundingLiveCells)
        {
            if (wasAlive && surroundingLiveCells<2) return false;               
            if (wasAlive && surroundingLiveCells==2) return true;
            if (wasAlive && surroundingLiveCells == 3) return true;
            if (wasAlive && surroundingLiveCells>3) return false;            
            if (!wasAlive && surroundingLiveCells == 3) return true;
            return false;
        }        

        private void UpdateGrid()
        {
            for (var r = 0; r < NewGrid.Row; r++)
            {
                for (var c = 0; c < NewGrid.Col; c++)
                {
                    NewGrid.SetCell(r, c, new Cell( NewGrid.GetCell(r,c).WillBeAlive));
                }
            }
        }
        
    }
}