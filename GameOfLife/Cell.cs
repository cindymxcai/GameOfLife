namespace GameOfLife
{
    public class Cell
    {
        public bool IsAlive { get;}

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public  override string ToString()
        {
            return !IsAlive ? "--" : "██";
        }
    }
}