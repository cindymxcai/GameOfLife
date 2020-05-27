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
            var rowGetter = new LineReader(new []{"22", "**", ".."} );
            Assert.Equal("22", rowGetter.GetNextLine());
            Assert.Equal("**", rowGetter.GetNextLine());
            Assert.Equal("..", rowGetter.GetNextLine());

        }

        [Fact]
        public void ShouldThrowExceptionIfOutOfLines()
        {
            var rowGetter = new LineReader(new []{"00"} );
            var line = rowGetter.GetNextLine();
            Assert.Equal("00", line);
            Assert.Throws<IndexOutOfRangeException>(() => rowGetter.GetNextLine());
        }

        [Fact]
        public void ShouldThrowArgumentExceptionIfPassedNull()
        {
            Assert.Throws<ArgumentException>(()=> new LineReader( null));
        }
    }
}