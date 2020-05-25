using GameOfLife;
using Xunit;

namespace GameOfLifeTest
{
    public class GenGridTest
    {
        [Fact]
        public void ShouldMakeGridWithInputData()
        {
            var rowGetter = new RowGetter(new[] {"15", "...*."});
            var grid = CurrentGenGridMaker.MakeGrid(rowGetter);
            Assert.Equal(CellStatus.Alive, grid.GetRow(0)[3]);
        }
        
        [Fact]
        public void ShouldShouldThrowExceptionIfZeroInput()
        {
            var rowGetter = new RowGetter(new[] {"00"});
            Assert.Throws<InvalidInputException>(() => CurrentGenGridMaker.MakeGrid(rowGetter));
        }
    }
}