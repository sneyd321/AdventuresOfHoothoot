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

        private string _dChoice;

        

        public Difficulty() 
        {
            _dChoice = "normal";

        }

        public int mapSpeed 
        {
            get
            {
                return s_mapSpeed;
            }
            
        }

        public string difficultyChoice
        {
            get
            {
                return _dChoice;
            }

            set
            {
                _dChoice = value;
            }
        }
        /// <summary>
        /// sets values based on the selected difficulties
        /// </summary>
        public void OnDifficultySelected()
        {
            //if choice is easy
            if (_dChoice == "easy")
            {
                
                s_mapSpeed = 10;
                s_obsticleDistance = 400;
                
            }
            //if choice is normal
            else if (_dChoice == "normal")
            {
                s_mapSpeed = 25;
                s_obsticleDistance = 200;

            }
            //if choice is hard
            else if (_dChoice == "hard")
            {
                s_mapSpeed = 50;
                s_obsticleDistance = 100;

            }
        }
    }

    

    

}
