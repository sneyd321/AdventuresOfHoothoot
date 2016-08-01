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
            LinearGradientBrush obstColour = new LinearGradientBrush();
            obstColour.StartPoint = new Point(0, 0.5);
            obstColour.EndPoint = new Point(1, 0.5);



            Color value1 = Colors.Green;
            Color value2 = Colors.LimeGreen;


            GradientStop colour1 = new GradientStop();
            colour1.Color = value1;
            colour1.Offset = 0.0;


            GradientStop colour2 = new GradientStop();
            colour2.Color = value2;
            colour2.Offset = 0.5;

            GradientStop colour3 = new GradientStop();
            colour3.Color = value1;
            colour3.Offset = 1.0;


            obstColour.GradientStops.Add(colour1);
            obstColour.GradientStops.Add(colour2);
            obstColour.GradientStops.Add(colour3);


            

            _obsticle.Fill = obstColour;
            

            _obsticle.HorizontalAlignment = HorizontalAlignment.Left;
            _obsticle.VerticalAlignment = VerticalAlignment.Center;


            createSize(0, 0);





            _canvas.Children.Add(_obsticle);


            Canvas.SetLeft(_obsticle, 200);
            Canvas.SetTop(_obsticle, 0);
            

        }

       

        public void createSize(double width, double height)
        {
            _obsticle.Width = width;
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
