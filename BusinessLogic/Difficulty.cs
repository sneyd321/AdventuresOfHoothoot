using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProposal
{
    public class Difficulty
    {
        public static int s_mapSpeed;

        private string _dChoice = "normal";

        public Difficulty() //obstacleDistance)
        {
            
           
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

        public void OnDifficultySelected()
        {
            if (_dChoice == "easy")
            {
                s_mapSpeed = 10;
                
            }
            else if (_dChoice == "normal")
            {
                s_mapSpeed = 25;

            }
            else if (_dChoice == "hard")
            {
                s_mapSpeed = 50;

            }
        }
    }

    

    

}
