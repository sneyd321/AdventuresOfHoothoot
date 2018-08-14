using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using ProjectProposal;
using LogicTier;
using Windows.Foundation;

namespace ProjectProposal
{
    public class Map
    {
        //field variable
        private Rectangle _map;

        /// <summary>
        /// Constructor for the map class
        /// </summary>
        public Map()
        {
            //intialize rectangle object
            _map = new Rectangle();
        }

        /// <summary>
        /// Method that defines size of the map
        /// </summary>
        /// <param name="width">width of map</param>
        /// <param name="height">height of map</param>
        /// <returns>XAML Rectangle</returns>
        public Rectangle createMap(double width, double height)
        {
            //set alignment
            _map.HorizontalAlignment = HorizontalAlignment.Left;
            _map.VerticalAlignment = VerticalAlignment.Center;
            //set width and height
            _map.Width = width;
            _map.Height = height;
            //return map
            return _map;

        }

        /// <summary>
        /// gets obstacle 
        /// </summary>
        /// <param name="width">set width of obstacle</param>
        /// <param name="height">set height of obstacle</param>
        /// <returns>XAML Rectangle</returns>
        public Rectangle getObstacle(double width, double height)
        {
            //Create new obstacle
            Obstacle obstacle = new Obstacle();
            //set size
            obstacle.createSize(width, height);
            //create pipe
            Rectangle pipe = obstacle.createRectangle();
            //return pipe
            return pipe;
        }
    }
}