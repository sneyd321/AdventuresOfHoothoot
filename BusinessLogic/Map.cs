using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace ProjectProposal
{
    public class Map
    {
        private LinearGradientBrush _colour;

        private int _mapSize;

        

        public Map(int mapSize)
        {
            
            _mapSize = mapSize;
            

            _colour = MainPage.s_colour;
        }

        public LinearGradientBrush Colour
        {
            get
            {
                return _colour;
            }
        }

        public int mapSize
        {
            get
            {
                return _mapSize;
            }
        }
       

    }
}
