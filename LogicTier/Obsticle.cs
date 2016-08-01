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

namespace LogicTier
{
    public class Obsticle
    {
        

        private Rectangle _obsticle;

        private Canvas _canvas;

        public Obsticle(Canvas canvas, Rectangle hoothoot)
        {

            _canvas = canvas;
            _obsticle = new Rectangle();
            createRectangle();

            Collision(hoothoot, _obsticle);

        }

        public Rectangle getObsticle
        {
            get
            {
                return _obsticle;
            }
        }

        public void createRectangle()
        {


            SolidColorBrush obstColour = new SolidColorBrush();
            SolidColorBrush obstStroke = new SolidColorBrush();

            obstStroke.Color = Colors.Black;
            obstColour.Color = Colors.LimeGreen;


            _obsticle.Fill = obstColour;
            _obsticle.Stroke = obstStroke;

            _obsticle.HorizontalAlignment = HorizontalAlignment.Left;
            _obsticle.VerticalAlignment = VerticalAlignment.Center;


            createSize(0);





            _canvas.Children.Add(_obsticle);


            Canvas.SetLeft(_obsticle, 200);
            Canvas.SetTop(_obsticle, 0);
            

        }

       

        public void createSize(double height)
        {
            _obsticle.Width = 50;
            _obsticle.Height = height;
        }

        public void setLocation(double left, double top)
        {
            
            Canvas.SetLeft(_obsticle, left);
            Canvas.SetTop(_obsticle, top);
            
        }

        public void Collision(Rectangle testHoothoot, Rectangle Pipe)
        {
            double hhLeft = Canvas.GetLeft(testHoothoot);
            double hhTop = Canvas.GetTop(testHoothoot);
            Rect rect1 = new Rect(hhLeft, hhTop, testHoothoot.ActualWidth, testHoothoot.ActualHeight);

            double pipeLeft = Canvas.GetLeft(Pipe);
            double pipeTop = Canvas.GetTop(Pipe);
            Rect rect2 = new Rect(pipeLeft, pipeTop, Pipe.ActualWidth, Pipe.ActualHeight);

            rect1.Intersect(rect2);

            if (rect1.IsEmpty)
            {
                
            }
            else
            {
                throw new NullReferenceException();
            }
        }

       

    }
}
