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
            var currentGen = new CurrentGenGridMaker();
            currentGen.MakeGrid(rowGetter);
            Assert.True(currentGen.CurrentGrid.GetCell(0, 3).IsAlive);
        }
        
        [Fact]
        public void ShouldShouldThrowExceptionIfZeroInput()
        {
            var rowGetter = new RowGetter(new[] {"00"});
            var currentGen = new CurrentGenGridMaker();
            Assert.Throws<InvalidInputException>(() => currentGen.MakeGrid(rowGetter));
        }
    }
}