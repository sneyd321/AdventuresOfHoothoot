using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Media;


namespace LogicTier
{
    public abstract class GradientBackground
    {
        LinearGradientBrush _colour;


        public GradientBackground()
        {
            _colour = new LinearGradientBrush();
            _colour.StartPoint = new Point(0, 0);
            _colour.EndPoint = new Point(1, 1);
        }

 

        public void setStartPoint(double x, double y)
        {
            _colour.StartPoint = new Point(x, y);
        }

        public void setEndPoint(double x, double y)
        {
            _colour.EndPoint = new Point(x, y);
        }


        public void addGradientStop(GradientStop gradientStop)
        {
            _colour.GradientStops.Add(gradientStop);
        }
        

        public LinearGradientBrush getColour()
        {
            return _colour;
        }
           



    }
}
