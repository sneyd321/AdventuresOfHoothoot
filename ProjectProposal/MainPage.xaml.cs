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
using ProjectProposal;
using LogicTier;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectProposal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Static field that defines the background colour in the Game Page
        /// </summary>
        public static LinearGradientBrush s_colour;

        /// <summary>
        /// Field for the difficulty object
        /// </summary>
        private Difficulty _difficulty;


        
        


        public MainPage()
        {
            this.InitializeComponent();

            //Create Difficulty Object
            _difficulty = new Difficulty();

            //Method that creates a default difficulty if the user does not select a difficulty
            _difficulty.OnDifficultySelected();
        
            //Method that creates a default background if the user did not select a background
            DefaultBackground();

            
            

            
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            
            _btnEasy.Visibility = Visibility.Collapsed;
            _btnNormal.Visibility = Visibility.Collapsed;
            _btnHard.Visibility = Visibility.Collapsed;
            _btnBackground1.Visibility = Visibility.Collapsed;
            _btnBackground2.Visibility = Visibility.Collapsed;
            _btnBackground3.Visibility = Visibility.Collapsed;
            _btnBackground4.Visibility = Visibility.Collapsed;
            _btnBackground5.Visibility = Visibility.Collapsed;

            
        }


        private void OnSelectDifficulty(object sender, RoutedEventArgs e)
        {
            _btnSelectDifficulty.Visibility = Visibility.Collapsed;
            _btnEasy.Visibility = Visibility.Visible;
            _btnNormal.Visibility = Visibility.Visible;
            _btnHard.Visibility = Visibility.Visible;

        }

        private void OnEasy(object sender, RoutedEventArgs e)
        {
            _btnSelectDifficulty.Visibility = Visibility.Visible;
            _btnEasy.Visibility = Visibility.Collapsed;
            _btnNormal.Visibility = Visibility.Collapsed;
            _btnHard.Visibility = Visibility.Collapsed;

            //Sets the difficulty choice to easy
            _difficulty.difficultyChoice = 1;
            _difficulty.OnDifficultySelected();
        }

        private void OnNormal(object sender, RoutedEventArgs e)
        {
            _btnSelectDifficulty.Visibility = Visibility.Visible;
            _btnEasy.Visibility = Visibility.Collapsed;
            _btnNormal.Visibility = Visibility.Collapsed;
            _btnHard.Visibility = Visibility.Collapsed;

            //Setss difficulty choice to normal
            _difficulty.difficultyChoice = 2;
            _difficulty.OnDifficultySelected();
        }

        private void OnHard(object sender, RoutedEventArgs e)
        {
            _btnSelectDifficulty.Visibility = Visibility.Visible;
            _btnEasy.Visibility = Visibility.Collapsed;
            _btnNormal.Visibility = Visibility.Collapsed;
            _btnHard.Visibility = Visibility.Collapsed;

            //sets the difficulty choice to hard
            _difficulty.difficultyChoice = 3;
            _difficulty.OnDifficultySelected();
        }

        private void OnBackground1(object sender, RoutedEventArgs e)
        {
            _btnChangeBackground.Visibility = Visibility.Visible;
            _btnBackground1.Visibility = Visibility.Collapsed;
            _btnBackground2.Visibility = Visibility.Collapsed;
            _btnBackground3.Visibility = Visibility.Collapsed;
            _btnBackground4.Visibility = Visibility.Collapsed;
            _btnBackground5.Visibility = Visibility.Collapsed;

            //sets the graddient colour object
            s_colour = new LinearGradientBrush();
            s_colour.StartPoint = new Point(0.5, 0);
            s_colour.EndPoint = new Point(0.5, 1);


            //set colours
            Color value1 = Colors.Black;
            Color value2 = Colors.DarkGreen;

            //create gradient stop 1
            GradientStop colour1 = new GradientStop();
            colour1.Color = value1;
            colour1.Offset = 0.0;

            //create gradient stop 2
            GradientStop colour2 = new GradientStop();
            colour2.Color = value2;
            colour2.Offset = 1.0;

            //add gradientStops to obstColour
            s_colour.GradientStops.Add(colour1);
            s_colour.GradientStops.Add(colour2);

            //set the colour of the obsticles
            _grid.Background = s_colour;

        }


        private void OnBackground2(object sender, RoutedEventArgs e)
        {
            _btnChangeBackground.Visibility = Visibility.Visible;
            _btnBackground1.Visibility = Visibility.Collapsed;
            _btnBackground2.Visibility = Visibility.Collapsed;
            _btnBackground3.Visibility = Visibility.Collapsed;
            _btnBackground4.Visibility = Visibility.Collapsed;
            _btnBackground5.Visibility = Visibility.Collapsed;

            //sets the graddient colour object
            s_colour = new LinearGradientBrush();
            s_colour.StartPoint = new Point(0.5, 0);
            s_colour.EndPoint = new Point(0.5, 1);


            //set colours
            Color value1 = Colors.Black;
            Color value2 = Colors.White;

            //create gradient stop 1
            GradientStop colour1 = new GradientStop();
            colour1.Color = value1;
            colour1.Offset = 0.0;

            //create gradient stop 2
            GradientStop colour2 = new GradientStop();
            colour2.Color = value2;
            colour2.Offset = 1.0;

            //add gradientStops to obstColour
            s_colour.GradientStops.Add(colour1);
            s_colour.GradientStops.Add(colour2);

            //set the colour of the obsticles
            _grid.Background = s_colour;

        }

        private void OnBackground3(object sender, RoutedEventArgs e)
        {
            _btnChangeBackground.Visibility = Visibility.Visible;
            _btnBackground1.Visibility = Visibility.Collapsed;
            _btnBackground2.Visibility = Visibility.Collapsed;
            _btnBackground3.Visibility = Visibility.Collapsed;
            _btnBackground4.Visibility = Visibility.Collapsed;
            _btnBackground5.Visibility = Visibility.Collapsed;

            //sets the graddient colour object
            s_colour = new LinearGradientBrush();
            s_colour.StartPoint = new Point(0.5, 0);
            s_colour.EndPoint = new Point(0.5, 1);


            //set colours
            Color value1 = Colors.Blue;
            Color value2 = Colors.Orange;

            //create gradient stop 1
            GradientStop colour1 = new GradientStop();
            colour1.Color = value1;
            colour1.Offset = 0.0;

            //create gradient stop 2
            GradientStop colour2 = new GradientStop();
            colour2.Color = value2;
            colour2.Offset = 1.0;

            //add gradientStops to obstColour
            s_colour.GradientStops.Add(colour1);
            s_colour.GradientStops.Add(colour2);

            //set the colour of the obsticles
            _grid.Background = s_colour;
        }

        private void OnBackground4(object sender, RoutedEventArgs e)
        {
            _btnChangeBackground.Visibility = Visibility.Visible;
            _btnBackground1.Visibility = Visibility.Collapsed;
            _btnBackground2.Visibility = Visibility.Collapsed;
            _btnBackground3.Visibility = Visibility.Collapsed;
            _btnBackground4.Visibility = Visibility.Collapsed;
            _btnBackground5.Visibility = Visibility.Collapsed;

            //sets the graddient colour object
            s_colour = new LinearGradientBrush();
            s_colour.StartPoint = new Point(0.5, 0);
            s_colour.EndPoint = new Point(0.5, 1);


            //set colours
            Color value1 = Colors.BlanchedAlmond;
            Color value2 = Colors.Blue;

            //create gradient stop 1
            GradientStop colour1 = new GradientStop();
            colour1.Color = value1;
            colour1.Offset = 0.0;

            //create gradient stop 2
            GradientStop colour2 = new GradientStop();
            colour2.Color = value2;
            colour2.Offset = 1.0;

            //add gradientStops to obstColour
            s_colour.GradientStops.Add(colour1);
            s_colour.GradientStops.Add(colour2);

            //set the colour of the obsticles
            _grid.Background = s_colour;

        }

        private void OnBackground5(object sender, RoutedEventArgs e)
        {
            _btnChangeBackground.Visibility = Visibility.Visible;
            _btnBackground1.Visibility = Visibility.Collapsed;
            _btnBackground2.Visibility = Visibility.Collapsed;
            _btnBackground3.Visibility = Visibility.Collapsed;
            _btnBackground4.Visibility = Visibility.Collapsed;
            _btnBackground5.Visibility = Visibility.Collapsed;

            //sets the graddient colour object
            s_colour = new LinearGradientBrush();
            s_colour.StartPoint = new Point(0, 0);
            s_colour.EndPoint = new Point(1, 1);


            //set colours
            Color value1 = Colors.Yellow;
            Color value2 = Colors.Red;
            Color value3 = Colors.Blue;
            Color value4 = Colors.LimeGreen;

            //create gradient stop 1
            GradientStop colour1 = new GradientStop();
            colour1.Color = value1;
            colour1.Offset = 0.0;

            //create gradient stop 2
            GradientStop colour2 = new GradientStop();
            colour2.Color = value2;
            colour2.Offset = 0.25;
            //create gradient stop 3
            GradientStop colour3 = new GradientStop();
            colour3.Color = value3;
            colour3.Offset = 0.75;
            //create gradient stop 4
            GradientStop colour4 = new GradientStop();
            colour4.Color = value4;
            colour4.Offset = 1.0;

            //add gradientStops to obstColour
            s_colour.GradientStops.Add(colour1);
            s_colour.GradientStops.Add(colour2);
            s_colour.GradientStops.Add(colour3);
            s_colour.GradientStops.Add(colour4);

            //set the colour of the obsticles
            _grid.Background = s_colour;
        }

        
        

        private void OnChangeBackground(object sender, RoutedEventArgs e)
        {
            _btnChangeBackground.Visibility = Visibility.Collapsed;
            _btnBackground1.Visibility = Visibility.Visible;
            _btnBackground2.Visibility = Visibility.Visible;
            _btnBackground3.Visibility = Visibility.Visible;
            _btnBackground4.Visibility = Visibility.Visible;
            _btnBackground5.Visibility = Visibility.Visible;

            
        }

        private void OnExitGame(object sender, RoutedEventArgs e)
        {
            //exit game
            
            Application.Current.Exit();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            //navigate to the next page
            this.Frame.Navigate(typeof(DemoGamePage));
        }

        private void DefaultBackground()
        {

            //sets the graddient colour object
            s_colour = new LinearGradientBrush();
            s_colour.StartPoint = new Point(0.5, 0);
            s_colour.EndPoint = new Point(0.5, 1);


            //set colours
            Color value1 = Colors.Black;
            Color value2 = Colors.DarkGreen;

            //create gradient stop 1
            GradientStop colour1 = new GradientStop();
            colour1.Color = value1;
            colour1.Offset = 0.0;

            //create gradient stop 2
            GradientStop colour2 = new GradientStop();
            colour2.Color = value2;
            colour2.Offset = 1.0;

            //add gradientStops to obstColour
            s_colour.GradientStops.Add(colour1);
            s_colour.GradientStops.Add(colour2);

            //set the colour of the obsticles
            _grid.Background = s_colour;
        }

        
    }
}
