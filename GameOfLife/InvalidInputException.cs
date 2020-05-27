using System;

namespace GameOfLife
{
    public class InvalidInputException : Exception
    {
        public override string Message { get; }

        public InvalidInputException(string message)
        {
            Message = message;
        }
    }
}