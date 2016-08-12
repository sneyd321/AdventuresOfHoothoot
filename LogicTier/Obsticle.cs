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

namespace LogicTier
{
    public class Obsticle
    {
        

        private Rectangle _obsticle;

        private Canvas _canvas;

        

        public Obsticle(Canvas canvas, Ellipse hoothoot)
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
        /// <summary>
        /// Creates obsticle
        /// </summary>
        public void createRectangle()
        {
            //sets the graddient colour object
            LinearGradientBrush obstColour = new LinearGradientBrush();
            obstColour.StartPoint = new Point(0, 0.5);
            obstColour.EndPoint = new Point(1, 0.5);


            //set colours
            Color value1 = Colors.Green;
            Color value2 = Colors.LimeGreen;

            //create gradient stop 1
            GradientStop colour1 = new GradientStop();
            colour1.Color = value1;
            colour1.Offset = 0.0;

            //create gradient stop 2
            GradientStop colour2 = new GradientStop();
            colour2.Color = value2;
            colour2.Offset = 0.5;

            //create gradient stop 3
            GradientStop colour3 = new GradientStop();
            colour3.Color = value1;
            colour3.Offset = 1.0;

            //add gradientStops to obstColour
            obstColour.GradientStops.Add(colour1);
            obstColour.GradientStops.Add(colour2);
            obstColour.GradientStops.Add(colour3);
            
            //set the colour of the obsticles
            _obsticle.Fill = obstColour;
            
            //set the horizontal allignment of the obsticle
            _obsticle.HorizontalAlignment = HorizontalAlignment.Left;
            //set the verticle allignment of the obsticle
            _obsticle.VerticalAlignment = VerticalAlignment.Center;

            //sets default size of the obsticle
            createSize(0, 0);
            
            //adds obsticle to the canvas
            _canvas.Children.Add(_obsticle);

            //sets the default location of obsticle
            Canvas.SetLeft(_obsticle, 200);
            Canvas.SetTop(_obsticle, 0);
            

        }

       
        /// <summary>
        /// Creates the size of the obsticle
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void createSize(double width, double height)
        {
            //sets obsticle width
            _obsticle.Width = width;
            //sets obsticle height
            _obsticle.Height = height;
        }
        /// <summary>
        /// sets the location of the obsticle
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void setLocation(double left, double top)
        {
            
            Canvas.SetLeft(_obsticle, left);
            Canvas.SetTop(_obsticle, top);
            
        }

        /// <summary>
        /// Determines if hoot has intersected with an obsticle
        /// </summary>
        /// <param name="testHoothoot"></param>
        /// <param name="Pipe"></param>
        public async void Collision(Ellipse testHoothoot, Rectangle Pipe)
        {
            //create a rectangle around hoothoot
            double hhLeft = Canvas.GetLeft(testHoothoot);
            double hhTop = Canvas.GetTop(testHoothoot);
            Rect rect1 = new Rect(hhLeft, hhTop, testHoothoot.ActualWidth, testHoothoot.ActualHeight);

            //create a rectangle around each obsticle
            double pipeLeft = Canvas.GetLeft(Pipe);
            double pipeTop = Canvas.GetTop(Pipe);
            Rect rect2 = new Rect(pipeLeft, pipeTop, Pipe.ActualWidth, Pipe.ActualHeight);

            rect1.Intersect(rect2);
            // if rects dont intersect
            if (rect1.IsEmpty)
            {
                
            }
            //else end game
            else
            {
                MessageDialog msg = new MessageDialog("Game Over");
                Game.timer.Stop();
                await msg.ShowAsync();
                Application.Current.Exit();
                
            }
        }

       

    }
}
