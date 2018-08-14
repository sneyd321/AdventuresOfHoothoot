using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicTier;
using ProjectProposal;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.Foundation;

namespace LogicTier
{
    public class HootHoot
    {
        //field variables
        private double _xlocation;

        private double _ylocation;

        private Ellipse _hootHoot;
        

        //Constants
        private const float FALLINGSPEED = 12.5f;
        private const double FLAPSPEED = 45.50f;

        
        /// <summary>
        /// Constructor for the hoot hoot class     
        /// </summary>
        /// <param name="hoothoot">Ellispe generated in the canvas</param>       
        public HootHoot(Ellipse hoothoot)
        {
            //initalize hoothoot
            _hootHoot = hoothoot;
            //get current location
            _xlocation = Canvas.GetLeft(hoothoot);
            _ylocation = Canvas.GetTop(hoothoot);
            //Set z index to 1
            Canvas.SetZIndex(_hootHoot, 1);
      
        }
 
        /// <summary>
        /// Method for moving the character upwards on user input
        /// </summary>
        public void Flap()
        {
            _ylocation -= FLAPSPEED;
            Canvas.SetTop(_hootHoot, _ylocation);          
        }
    
        /// <summary>
        /// Method that simulates gravity of hoothoot, updates canvas
        /// </summary>
        public void fall()
        {
            _ylocation += FALLINGSPEED;
            Canvas.SetTop(_hootHoot, _ylocation);
        }

       

    }
}
