using GameOfLife;
using Xunit;
namespace GameOfLifeTest
{
    public class Tests
    {
        [Theory]
            [InlineData("33", 3, 3)]
            [InlineData("35", 3, 5)]
            [InlineData("18", 1, 8)]
            public void GivenStringInputShouldGetXAndY(string input, int expectedX, int expectedY)
            {
                var (x, y) = LineParser.GetSize(input);
                Assert.Equal(expectedX, x);
                Assert.Equal(expectedY, y);
            }

            [Theory]
            [InlineData("")]
            [InlineData("!")]
            [InlineData("-1")]
            [InlineData("w")]
            [InlineData("L")]
            [InlineData("  ")]
            [InlineData(" ")]
            [InlineData("5")]
            public void GivenWrongInputShouldThrowException(string input)
            {
                Assert.Throws<InvalidInputException>(() => LineParser.GetSize(input));
            }

            [Theory]
            [InlineData("*..", CellStatus.Alive, CellStatus.Dead)]
            public void GetFieldFromString(string input, CellStatus live, CellStatus dead)
            {
                var row = LineParser.GetGridRow(input);
                Assert.Equal(live, row[0]);
                Assert.Equal(dead, row[1]);
                Assert.Equal(dead, row[2]);
            }
    }
}