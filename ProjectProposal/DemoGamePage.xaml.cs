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






// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectProposal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoGamePage : Page
    {
        

        private Game _game;

        


        public DemoGamePage()
        {
            this.InitializeComponent();

            _game = new Game(_progressBar, _canvas, testHoothoot);


            
           
        }

        
        

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            
            _game.map.mapBackground.Fill = MainPage.s_colour;




            _game.StartTimer(sender, e);

            

        }
        

        

        private void onClick(object sender, RoutedEventArgs e)
        {
            

            double move = Canvas.GetTop(testHoothoot);
            move += 10;
            Canvas.SetTop(testHoothoot, move);

            HootHoot hoothoot = new HootHoot(testHoothoot, _game.map);
            hoothoot.OnHoothootDies();

           
        }

        

    }

}


