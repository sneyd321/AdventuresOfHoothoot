using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace LogicTier
{
    class BlackWhiteBackground : GradientBackground
    {
        public BlackWhiteBackground() : base()
        {
            GradientStop black = new GradientStop();
            black.Color = Colors.Black;
            black.Offset = 0.0;
            addGradientStop(black);
            GradientStop white = new GradientStop();
            white.Color = Colors.White;
            white.Offset = 1.0;
            addGradientStop(white);
 
            setStartPoint(0.5, 0);
            setEndPoint(0.5, 1);
        }

    }
}
