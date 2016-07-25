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

namespace ProjectProposal
{
    public class Map
    {
        private LinearGradientBrush _colour;

        private double _mapSize;

        private Rectangle _mapBackground;

        public Map(double mapSize, Rectangle mapBackground)
        {
            
            _mapSize = mapSize;

            _mapBackground = mapBackground;

            


            

        }

        public LinearGradientBrush Colour
        {
            get
            {
                return _colour;
            }
        }

        public double mapSize
        {
            get
            {
                _mapSize = _mapBackground.ActualWidth;
                return _mapSize;
            }
        }

        
       

    }
}
