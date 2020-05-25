using System.Collections.Generic;

namespace GameOfLife
{
    public static class LineParser
    {
        public static (int, int) GetSize(string input )
        {
            try
            {
                var x = int.Parse(input.Substring(0, 1));
                var y = int.Parse(input.Substring(1, 1));
                return (x, y);
            }
            catch
            {
                throw new InvalidInputException("Invalid input for Size!");
            }
        }

        public static List<CellStatus> GetGridRow(string input)
        {
            var cellList = new List<CellStatus>();
            
            foreach (var cell in input)
            {
                switch (cell)
                {
                    case '*':
                        cellList.Add(CellStatus.Alive);
                        break;
                    case '.':
                        cellList.Add(CellStatus.Dead);
                        break;
                }
            }
            return cellList;
        }
    }
}