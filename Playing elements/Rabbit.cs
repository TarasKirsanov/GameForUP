using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    class Rabbit
    {
        //public Position position;
        private Position position;
        public bool IsGoing { get; set; }
        public int CurrentRow;
        public int CurrentCol;
        public int QuantityOfLife { get; set; }
        public string ImagePath { get; set; }
        public Rabbit(int startX, int startY, int quantityOfLife)
        {
            position = new Position(startX, startY);
            IsGoing = false;
            CurrentRow = 0;
            CurrentCol = 0;
            QuantityOfLife = quantityOfLife;
        }
        public Rabbit(int startX, int startY, int quantityOfLife, string imagePath) : this(startX, startY, quantityOfLife)
        {
            ImagePath = imagePath;
        }
        public Position GetPosition()
        {
            return position;
        }
        public void NewPosition(int newX, int newY)
        {
            position.Update(newX, newY);
        }
        public void UpdatePosition(int addX, int addY)
        {
            position.Update(position.X + addX, position.Y + addY);
        }
    }
}
