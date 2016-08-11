using ProjectProposal;
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
using System.Windows;
using LogicTier;
using Windows.UI.Xaml.Shapes;
using Windows.UI;






// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectProposal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoGamePage : Page
    {

        /// <summary>
        /// Field that initializes the game object
        /// </summary>
        private Game _game;


        

        public DemoGamePage()
        {
            this.InitializeComponent();

            //create game object
            _game = new Game(_progressBar, _canvas, testHoothoot);

           


        }



        /// <summary>
        /// Runs code while loading gamepage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            //sets the colour of map background
            _game.map.mapBackground.Fill = MainPage.s_colour;

            _canvas.Background = MainPage.s_colour;

            //starts the timer
            _game.StartTimer(sender, e);

            

        }
        

        

        private void onClick(object sender, RoutedEventArgs e)
        {


            Ellipse test = new Ellipse();

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
            test.Fill = obstColour;

            //set the horizontal allignment of the obsticle
            test.HorizontalAlignment = HorizontalAlignment.Left;
            //set the verticle allignment of the obsticle
            test.VerticalAlignment = VerticalAlignment.Center;

            //sets default size of the obsticle
            test.Height = 50;
            test.Width = 50;

            //adds obsticle to the canvas
            _canvas.Children.Add(test);

            //sets the default location of obsticle
            Canvas.SetLeft(test, 50);
            Canvas.SetTop(test, 50);


            /*
            double move = Canvas.GetTop(testHoothoot);
            move += 10;
            Canvas.SetTop(testHoothoot, move);

            HootHoot hoothoot = new HootHoot(testHoothoot, _game);
            hoothoot.OnHoothootDies();
            */
        }

        

    }

}


