using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTest
{
    public class NextGenGridMakerTest
    {
        [Fact]
        public void NewGenerationGridShouldBeSizeOfOldGeneration()
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new RowGetter(new []{"22", "*.", ".."}));
            var filter  = new CellFilter(currentGen.CurrentGrid);
            var nextGen = new NextGenGridMaker(currentGen.CurrentGrid, filter);
            Assert.Equal(currentGen.CurrentGrid.Col,nextGen.NewGrid.Col);
            Assert.Equal(currentGen.CurrentGrid.Row,nextGen.NewGrid.Row);
        }

        [Theory]
        [MemberData(nameof(ListData))]
        public void SurroundingValidCellsFoundCorrectly(List<(int,int)> expectedListOfValidCells, int currentRow, int currentCol)
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new RowGetter(new []{"33", "*..", ".*.", "..."}));
            var filter  = new CellFilter(currentGen.CurrentGrid);
            Assert.Equal(expectedListOfValidCells, filter.FindNeighbouringCells(currentRow, currentCol) );
        }

        public static IEnumerable<object[]> ListData()
        {
            var test1 = new List<(int,int)> {(0,0), (0,2), (1,0), (1,1), (1,2)};
            var test2 = new List<(int,int)> {(0,1), (1,0), (1,1)};
            var test3 = new List<(int, int)> {(0,0), (0,1), (0,2), (1,0), ( 1,2), (2,0), (2,1), (2,2)};
            yield return new object[] { test1, 0, 1 }; 
            yield return new object[] { test2, 0, 0}; 
            yield return new object[] { test3, 1, 1}; 
        }

        [Fact]
        public void ShouldGetNumberOfLiveSurroundingCellGivenCurrentCell()
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new RowGetter(new []{"22", "*.", ".."}));
            var filter  = new CellFilter(currentGen.CurrentGrid);
            var neighbouringCells = filter.FindNeighbouringCells(0, 1);
            var liveCells = filter.GetSurroundingLiveCells(currentGen.CurrentGrid, neighbouringCells);
            Assert.Equal(1,liveCells);
            
            currentGen.MakeGrid(new RowGetter(new []{"44", "*...", "...*", "**..", "****"}));
            filter  = new CellFilter(currentGen.CurrentGrid);
            neighbouringCells = filter.FindNeighbouringCells(2, 1);
            liveCells = filter.GetSurroundingLiveCells(currentGen.CurrentGrid, neighbouringCells);
            Assert.Equal(4,liveCells);
        }

        [Theory]
        [MemberData(nameof(LiveCellData))]
        public void ShouldReturnIfAliveFromSurroundingLiveCells(string [] input, bool isAlive)
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new RowGetter(input));
            var filter  = new CellFilter(currentGen.CurrentGrid);
            var nextGen = new NextGenGridMaker(currentGen.CurrentGrid, filter);
            var neighbouringCells = filter.FindNeighbouringCells(1, 1);
            var liveCells = filter.GetSurroundingLiveCells(currentGen.CurrentGrid, neighbouringCells);
            Assert.Equal( isAlive,nextGen.TurnAlive(nextGen.NewGrid.GetCell(1,1).WillBeAlive,liveCells));
        }
        
        public static IEnumerable<object[]> LiveCellData()
        {
            var test1 = new[] {"33", "...", ".*.", "..*"};
            var test2 = new[] {"33", "...", "**.", ".**"};
            var test3 = new[] {"33", "***", "***", "***"};
            var test4 = new[] {"33", "...", "*..", ".**"};
            yield return new object[] { test1, false }; 
            yield return new object[] { test2, true}; 
            yield return new object[] { test3, false}; 
            yield return new object[] {test4, true};
        }

        [Fact]
        public void NewGenerationIsAsExpected()
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new RowGetter(new []{"33", "...", "***", "..."}));
            var filter  = new CellFilter(currentGen.CurrentGrid);
            var nextGen = new NextGenGridMaker(currentGen.CurrentGrid, filter);
            nextGen.GetNewGeneration(currentGen.CurrentGrid);
            var deadCells = 0;
            for (var r = 0; r < nextGen.NewGrid.Row; r++)
            {
                for (var c = 0; c < nextGen.NewGrid.Col; c++)
                {
                    if (!nextGen.NewGrid.GetCell(r, c).IsAlive)
                    {
                        deadCells++;
                    }
                }
            }
            
            Assert.Equal(6, deadCells);
            Assert.True(nextGen.NewGrid.GetCell(0,1).IsAlive);
            Assert.True(nextGen.NewGrid.GetCell(1,1).IsAlive);
            Assert.True(nextGen.NewGrid.GetCell(2,1).IsAlive);
        }
        
    }
}