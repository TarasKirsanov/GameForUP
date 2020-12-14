using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    public class Configarithion
    {
        public string ImagePathPlayer { get; set; }
        public string ImagePathWolf { get; set; }
        public string ImagePathPresent { get; set; }
        public string ImagePathBomb { get; set; }
        public string MapForFirstLevel { get; set; }
        public string MapForSecondLevel { get; set; }
        public string MapForThirdLevel { get; set; }
        public string LevelOfHardOnFirstLevel { get; set; }
        public string LevelOfHardOnSecondLevel { get; set; }
        public string LevelOfHardOnThirdLevel { get; set; }
        public int CountOfLives { get; set; }
        public int WolfInterval { get; set; }
        public int DamageOfWolf { get; set; }
        public int DamageOfBomb { get; set; }
        public int HandicapTime { get; set; }
        
    }
}
