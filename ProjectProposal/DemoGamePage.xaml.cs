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
using System.Threading;







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

        //private HootHoot _hoothoot;

        private Ellipse hoothootShape = new Ellipse();


        public DemoGamePage()
        {
            this.InitializeComponent();

            //create game object
            _game = new Game(_progressBar, _canvas, hoothootShape);

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
            _game.onJump();

            if (_progressBar.Value >= _progressBar.Maximum)
            {
                _game.score.onHootHootComplete();
                this.Frame.Navigate(typeof(ScorePage));
            }
        }
    }

}


