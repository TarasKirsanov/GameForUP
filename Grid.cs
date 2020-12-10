using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    public class Grid
    {
        private int height;
        private int width;
        public int WidthOfCell { get; private set; }
        public int HeightOfCell { get; private set; }
        public int countOfRows { get; private set; }
        public int countOfColumns { get; private set; }
        private bool[,] Map;
        public Grid(int height, int width, int countOfRows, int countOfColumns)
        {
            this.height = height;
            this.width = width;
            this.countOfRows = countOfRows;
            this.countOfColumns = countOfColumns;
            WidthOfCell = width / countOfColumns;
            HeightOfCell = height / countOfRows;
        }
        public Grid(int height, int width, int countOfRows, int countOfColumns, bool[,] map) : this(height, width, countOfRows, countOfColumns)
        {
            Map = map;
        }
        public Grid(int height, int width, int countOfRows, int countOfColumns, string path) : this(height, width, countOfRows, countOfColumns)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                Map = new bool[countOfRows, countOfColumns];
                for (int i = 0; !reader.EndOfStream; ++i)
                {
                    string s = reader.ReadLine();
                    for (int j = 0; j < s.Length; j++)
                    {
                        Map[i, j] = s[j] == '1';
                    }
                }
            }

        }
        public bool IsFree(int rowCount, int colCount)
        {
            if (rowCount >= 0 && rowCount < countOfRows && colCount >= 0 && colCount < countOfColumns && Map[colCount, rowCount])
            {
                return true;
            }
            return false;
        }
        public Position GetPositionOfCell(int rowCount, int colCount)
        {
            return new Position(WidthOfCell * colCount, HeightOfCell * rowCount);
        }
        public void Inverse(int rowCount, int colCount)
        {
            Map[rowCount, colCount] = !Map[rowCount, colCount];
        }
    }
}
