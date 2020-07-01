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
        private Rectangle _map;

        public Map(double width, double height)
        {
            _map = new Rectangle();
            _map.HorizontalAlignment = HorizontalAlignment.Left;
            _map.VerticalAlignment = VerticalAlignment.Center;
            _map.Width = width;
            _map.Height = height;
        }


        public Rectangle getRectangle() { return this._map;  }
       
      

       
    }
}