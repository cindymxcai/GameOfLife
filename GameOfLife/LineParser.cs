using System.Collections.Generic;

namespace GameOfLife
{
    public static class LineParser
    {
        public static (int, int) GetSize(string input )
        {
            try
            {
                var size = input.Split(',');
                var x = int.Parse(size[0]);
                var y = int.Parse(size[1]);
                return (x, y);
            }
            catch
            {
                throw new InvalidInputException("Invalid input for Size!");
            }
        }

        public static List<Cell> GetGridRow(string input)
        {
            var cellList = new List<Cell>();
            
            foreach (var cell in input)
            {
                switch (cell)
                {
                    case '*':
                        cellList.Add(new Cell(true));
                        break;
                    case '.':
                        cellList.Add(new Cell(false));
                        break;
                }
            }
            return cellList;
        }
    }
}