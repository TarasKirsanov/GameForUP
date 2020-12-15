using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    class Bomb : AbstractPresent
    {

        public Bomb(Grid grid, Position rabbitPosition, Position wolfPosition, string imagePath, string imagePathBOOM) : base(grid, rabbitPosition, wolfPosition, imagePath, imagePathBOOM)
        {

        }
        public Bomb(int startX, int startY) : base(startX, startY)
        {

        }
        public Bomb(int startX, int startY, string imagePath, string imagePathBOOM) : base(startX, startY, imagePath, imagePathBOOM)
        {

        }
    }
}
