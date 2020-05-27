using System;
using GameOfLife;
using Xunit;

namespace GameOfLifeTest
{
    public class RowGetterTests
    {
        [Fact]
        public void ShouldReturnLinesInOrder()
        {
            var rowGetter = new LineReader(new []{"2,2", "**", ".."} );
            Assert.Equal("2,2", rowGetter.GetNextLine());
            Assert.Equal("**", rowGetter.GetNextLine());
            Assert.Equal("..", rowGetter.GetNextLine());

        }

        [Fact]
        public void ShouldThrowExceptionIfOutOfLines()
        {
            var rowGetter = new LineReader(new []{"0,0"} );
            var line = rowGetter.GetNextLine();
            Assert.Equal("0,0", line);
            Assert.Throws<IndexOutOfRangeException>(() => rowGetter.GetNextLine());
        }

        [Fact]
        public void ShouldThrowArgumentExceptionIfPassedNull()
        {
            Assert.Throws<ArgumentException>(()=> new LineReader( null));
        }
    }
}