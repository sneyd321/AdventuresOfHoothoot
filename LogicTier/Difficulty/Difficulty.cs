using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicTier;

namespace ProjectProposal
{
    public abstract class Difficulty

    {
        protected int mapSpeed;
        protected int obstacleHeight;

        public int getMapSpeed() 
        {
            return mapSpeed;
        }

        public int getObsticleHeight()
        {
            return obstacleHeight;
        }
       
    }

    

    

}
