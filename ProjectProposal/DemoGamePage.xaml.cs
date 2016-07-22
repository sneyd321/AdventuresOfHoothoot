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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectProposal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoGamePage : Page
    {
        

        private Game _game;

        private Map _map;

        public DemoGamePage()
        {
            this.InitializeComponent();

            _game = new Game(_progressBar, _mapBackground);

            _map = new Map(0, null);
        }

        
        

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            //_progressBar.Visibility = Visibility.Collapsed;
            _mapBackground.Fill = _map.Colour;
            _game.StartTimer(sender, e);

        }

        




        



    }

}


