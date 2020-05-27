using GameOfLife;
using Xunit;
namespace GameOfLifeTest
{
    public class Tests
    {
        [Theory]
            [InlineData("3,3", 3, 3)]
            [InlineData("3,5", 3, 5)]
            [InlineData("1,8", 1, 8)]
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
            [InlineData("*..")]
            public void GetFieldFromString(string input)
            {
                var row = LineParser.GetGridRow(input);
                Assert.True(row[0].IsAlive);
                Assert.False(row[1].IsAlive);
                Assert.False(row[2].IsAlive);
            }
    }
}