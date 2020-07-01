using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.Media;
using Windows.UI.Xaml.Shapes;
using ProjectProposal;
using LogicTier;
using Windows.UI.Popups;
using LogicTier.Background;

namespace LogicTier
{
    public class Obstacle
    {
        private Rectangle topPipe;
        private Rectangle bottomPipe;
      


        public Obstacle(double height)
        {        
            //initalize field
            topPipe = new Rectangle();
            topPipe.HorizontalAlignment = HorizontalAlignment.Left;
            topPipe.VerticalAlignment = VerticalAlignment.Center;
            topPipe.Fill = colourPipe();
            topPipe.Width = 125;
            topPipe.Height = 50;
            bottomPipe = new Rectangle();
            bottomPipe.HorizontalAlignment = HorizontalAlignment.Left;
            bottomPipe.VerticalAlignment = VerticalAlignment.Center;
            bottomPipe.Fill = colourPipe();
            bottomPipe.Width = 75;
            bottomPipe.Height = height;
        }
     
       
        public LinearGradientBrush colourPipe()
        {
            BackgroundFactory backgroundFactory = (BackgroundFactory)AbstractFactory.getFactory(FactoryType.Background);
            GradientBackground background = new PipeBackground();          
            return background.getColour();
        }


        public Rectangle getTop() { return topPipe; }
        public Rectangle getBottom() { return bottomPipe; }
    }
}
