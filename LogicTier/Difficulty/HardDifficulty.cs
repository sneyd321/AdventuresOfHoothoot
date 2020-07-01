using ProjectProposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier
{
    class HardDifficulty : Difficulty
    {

        public HardDifficulty()
        {
            mapSpeed = 50;
            obstacleHeight = 200;
        }
    }
}
