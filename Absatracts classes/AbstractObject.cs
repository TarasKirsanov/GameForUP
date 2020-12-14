using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    abstract class AbstarctObject
    {
        public Position position { get; protected set; }
        public string ImagePath { get; set; }

        protected AbstarctObject()
        {

        }
        protected AbstarctObject(int startX, int startY) => position = new Position(startX, startY);
        protected AbstarctObject(int startX, int startY, string imagePath) : this(startX, startY) => ImagePath = imagePath;
        public Position GetPosition() => position;
        public void NewPosition(int newX, int newY) => position.Update(newX, newY);
        public void UpdatePosition(int newX, int newY) => position.Update(position.X + newX, position.Y + newY);
    }
}
