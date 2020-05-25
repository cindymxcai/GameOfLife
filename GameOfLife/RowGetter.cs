using System;

namespace GameOfLife
{
    public class RowGetter : IRowGetter
    {
        private readonly string[] _input;
        private int _index;

        public RowGetter(string[] input)
        {
            _input = input ?? throw new ArgumentException("Null argument passed to line retriever constructor!", nameof(input));
        }

        public string GetNextLine()
        {

            var line = _input[_index];
            _index++;
            return line;
        }
        
    }
}