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
            currentGen.MakeGrid(new LineReader(new []{"2,2", "*.", ".."}));
            var nextGen = new NextGenGridMaker(currentGen.CurrentGrid);
            Assert.Equal(currentGen.CurrentGrid.Col,nextGen.NextGenGrid.Col);
            Assert.Equal(currentGen.CurrentGrid.Row,nextGen.NextGenGrid.Row);
        }

        [Theory]
        [MemberData(nameof(ListData))]
        public void SurroundingValidCellsFoundCorrectly(List<(int,int)> expectedListOfValidCells, int currentRow, int currentCol)
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new LineReader(new []{"3,3", "*..", ".*.", "..."}));
            Assert.Equal(expectedListOfValidCells, CellFilter.FindNeighbouringCells(currentRow, currentCol, 3, 3) );
        }

        public static IEnumerable<object[]> ListData()
        {
            var test1 = new List<(int,int)> {(2,0), (2,1), (2,2), (0,0), (0,2), (1,0), (1,1), (1,2) }; 
            var test2 = new List<(int,int)> {(2,2), (2,0), (2,1) , (0,2), (0,1), (1,2),(1,0),(1,1)};
            var test3 = new List<(int, int)> {(0,0), (0,1), (0,2), (1,0), ( 1,2), (2,0), (2,1), (2,2)};
            yield return new object[] { test1, 0, 1 }; 
            yield return new object[] { test2, 0, 0}; 
            yield return new object[] { test3, 1, 1};

        }

        [Fact]
        public void ShouldGetNumberOfLiveSurroundingCellGivenCurrentCell()
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new LineReader(new []{"2,2", "*.", ".."}));
            var neighbouringCells = CellFilter.FindNeighbouringCells(0, 1, 2, 2);
            var liveCells = CellFilter.GetSurroundingLiveCells(currentGen.CurrentGrid, neighbouringCells);
            Assert.Equal(2,liveCells);
            
            currentGen.MakeGrid(new LineReader(new []{"4,4", "*...", "...*", "**..", "****"}));
            neighbouringCells = CellFilter.FindNeighbouringCells(2, 1, 4, 4);
            liveCells = CellFilter.GetSurroundingLiveCells(currentGen.CurrentGrid, neighbouringCells);
            Assert.Equal(4,liveCells);
        }

        [Theory]
        [MemberData(nameof(LiveCellData))]
        public void ShouldReturnIfAliveFromSurroundingLiveCells(string [] input, bool isAlive)
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new LineReader(input));
            var nextGen = new NextGenGridMaker(currentGen.CurrentGrid);
            var neighbouringCells = CellFilter.FindNeighbouringCells(1, 1, 3, 3);
            var liveCells = CellFilter.GetSurroundingLiveCells(currentGen.CurrentGrid, neighbouringCells);
            Assert.Equal( isAlive,NextGenGridMaker.WillBeAlive(nextGen.NextGenGrid.GetCell(1,1).IsAlive,liveCells));
        }
        
        public static IEnumerable<object[]> LiveCellData()
        {
            var test1 = new[] {"3,3", "...", ".*.", "..*"};
            var test2 = new[] {"3,3", "...", "**.", ".**"};
            var test3 = new[] {"3,3", "***", "***", "***"};
            var test4 = new[] {"3,3", "...", "*..", ".**"};
            yield return new object[] { test1, false }; 
            yield return new object[] { test2, true}; 
            yield return new object[] { test3, false}; 
            yield return new object[] {test4, true};
        }

        [Fact]
        public void NewGenerationIsAsExpected()
        {
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(new LineReader(new []{"3,3", "...", "***", "..."}));
            var nextGen = new NextGenGridMaker(currentGen.CurrentGrid);
            nextGen.GetNewGeneration(currentGen.CurrentGrid);
            Assert.True(nextGen.NextGenGrid.GetCell(0,1).IsAlive);
            Assert.True(nextGen.NextGenGrid.GetCell(1,1).IsAlive);
            Assert.True(nextGen.NextGenGrid.GetCell(2,1).IsAlive);
        }
        
    }
}