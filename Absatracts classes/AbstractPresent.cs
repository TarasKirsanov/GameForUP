using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    abstract class AbstractPresent : AbstarctObject
    {
        public string ImagePathBOOM { get; set; }
        public AbstractPresent(Grid grid, Position rabbitPosition, Position wolfPosition)
        {
            Random rand = new Random();
            int startX = rand.Next(grid.countOfColumns), startY = rand.Next(grid.countOfRows);
            while (!grid.IsFree(startX, startY) || rabbitPosition.X == startX || wolfPosition.X == startX || rabbitPosition.Y == startY || wolfPosition.Y == startY)
            {
                startX = rand.Next(grid.countOfColumns);
                startY = rand.Next(grid.countOfRows);
            }
            position = new Position(startX, startY);
        }
        public AbstractPresent(int startX, int startY) : base(startX, startY)
        {

        }
        public AbstractPresent(int startX, int startY, string imagePath, string imagePathBOOM) : base(startX, startY, imagePath)
        {
            ImagePathBOOM = imagePathBOOM;
        }
    }
}
