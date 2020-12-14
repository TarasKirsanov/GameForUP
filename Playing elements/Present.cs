using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    class Present : AbstractPresent
    {
        public Present(Grid grid, Position rabbitPosition, Position wolfPosition) : base(grid, rabbitPosition, wolfPosition)
        {

        }
        public Present(int startX, int startY) : base(startX, startY)
        {

        }
        public Present(int startX, int startY, string imagePath, string imagePathBOOM) : base(startX, startY, imagePath, imagePathBOOM)
        {

        }
    }
}
