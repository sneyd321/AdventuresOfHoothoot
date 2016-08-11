using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicTier;

namespace ProjectProposal
{
    public class Difficulty

    {
        public static int s_mapSpeed;

        public static int s_obsticleDistance;        

        public static int s_difficultyChoice;

        

        public Difficulty() 
        {
            s_difficultyChoice = 2;

        }

        public int mapSpeed 
        {
            get
            {
                return s_mapSpeed;
            }
            
        }

        public int difficultyChoice
        {
            get
            {
                return s_difficultyChoice;
            }

            set
            {
                s_difficultyChoice = value;
            }
        }
        /// <summary>
        /// sets values based on the selected difficulties
        /// </summary>
        public void OnDifficultySelected()
        {
            //if choice is easy
            if (s_difficultyChoice == 1)
            {
                
                s_mapSpeed = 10;
                s_obsticleDistance = 400;
                
            }
            //if choice is normal
            else if (s_difficultyChoice == 2)
            {
                s_mapSpeed = 25;
                s_obsticleDistance = 200;


            }
            //if choice is hard
            else if (s_difficultyChoice == 3)
            {
                s_mapSpeed = 50;
                s_obsticleDistance = 100;

            }
        }
    }

    

    

}
