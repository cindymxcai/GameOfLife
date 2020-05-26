
using System;

namespace GameOfLife
{
    public class Cell
    {
        public bool IsAlive { get; }
        public bool WillBeAlive { get; set; }
        
        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }
        
        
        public  override string ToString()
        {
            return !IsAlive ? "-" : "*";
        }
    }
}