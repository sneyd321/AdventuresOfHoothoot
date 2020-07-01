using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace LogicTier.Background
{
    public class PipeBackground : GradientBackground
    {
        public PipeBackground() : base()
        {
      
            setStartPoint(0, 0.5);
            setEndPoint(1, 0.5);

            GradientStop green1 = new GradientStop();
            green1.Color = Colors.Green;
            green1.Offset = 0.0;
            addGradientStop(green1);
            //create gradient stop 2
            GradientStop limeGreen = new GradientStop();
            limeGreen.Color = Colors.LimeGreen;
            limeGreen.Offset = 0.5;
            addGradientStop(limeGreen);
            //create gradient stop 3
            GradientStop green2 = new GradientStop();
            green2.Color = Colors.Green;
            green2.Offset = 1.0;
            addGradientStop(green2);
            

        }

    }
}
