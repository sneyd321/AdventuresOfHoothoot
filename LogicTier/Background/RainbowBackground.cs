using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace LogicTier
{
    class RainbowBackground : GradientBackground
    {

        public RainbowBackground() : base()
        {
            GradientStop yellow = new GradientStop();
            yellow.Color = Colors.Yellow;
            yellow.Offset = 0.0;
            addGradientStop(yellow);
            GradientStop red = new GradientStop();
            red.Color = Colors.Red;
            red.Offset = 0.25;
            addGradientStop(red);
            GradientStop blue = new GradientStop();
            blue.Color = Colors.Blue;
            blue.Offset = 0.75;
            addGradientStop(blue);
            GradientStop limeGreen = new GradientStop();
            limeGreen.Color = Colors.LimeGreen;
            limeGreen.Offset = 1.0;
            addGradientStop(limeGreen);
            setStartPoint(0, 0);
            setEndPoint(1, 1);
        }


    }
}
