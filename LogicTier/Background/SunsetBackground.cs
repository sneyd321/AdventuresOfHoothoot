using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace LogicTier
{
    class SunsetBackground : GradientBackground
    {

        public SunsetBackground() : base()
        {
            
            
            GradientStop orange = new GradientStop();
            orange.Color = Colors.Orange;
            orange.Offset = 0.0;

            GradientStop blue = new GradientStop();
            blue.Color = Colors.Blue;
            blue.Offset = 1.0;

            addGradientStop(orange);
            addGradientStop(blue);

            setStartPoint(0.5, 0);
            setEndPoint(0.5, 1);

        }
    }
}
