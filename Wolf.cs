using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    class Wolf
    {
        Position position;
        public string ImagePath { get; set; }

        public Wolf(int startX, int startY, string path)
        {
            position = new Position(startX, startY);
            ImagePath = path;
        }

        public Position GetPosition()
        {
            return position;
        }

        public void UpdatePosition(int addX, int addY)
        {
            position.Update(position.X + addX, position.Y + addY);
        }


    }
}
