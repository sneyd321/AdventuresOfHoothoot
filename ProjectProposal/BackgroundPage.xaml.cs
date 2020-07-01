using LogicTier;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectProposal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BackgroundPage : Page
    {

        private BackgroundFactory _backgroundFactory;
        private GradientBackground _background1;
        private GradientBackground _background2;
        private GradientBackground _background3;

        private NavigationContainer container;

        public BackgroundPage()
        {
            this.InitializeComponent();
            container = new NavigationContainer();
            _backgroundFactory = (BackgroundFactory)AbstractFactory.getFactory(FactoryType.Background);
            _background1 = _backgroundFactory.GetBackground(BackgroundType.Rainbow);
            _background2 = _backgroundFactory.GetBackground(BackgroundType.BlackAndWhite);
            _background3 = _backgroundFactory.GetBackground(BackgroundType.Sunset);
            _btnBackground1.Background = _background1.getColour();
            _btnBackground2.Background = _background2.getColour();
            _btnBackground3.Background = _background3.getColour();



        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is NavigationContainer)
            {
                container = (NavigationContainer)e.Parameter;
                BackgroundFactory backgroundFactory = (BackgroundFactory)AbstractFactory.getFactory(FactoryType.Background);
                GradientBackground background = backgroundFactory.GetBackground(container.BackgroundType);
                _grid.Background = background.getColour();          
            }
            base.OnNavigatedTo(e);
        }

      


        private void OnBackground1(object sender, RoutedEventArgs e)
        {
            _grid.Background = _background1.getColour();
            container.BackgroundType = BackgroundType.Rainbow;
        }

        private void OnBackground2(object sender, RoutedEventArgs e)
        {
            _grid.Background = _background2.getColour();
            container.BackgroundType = BackgroundType.BlackAndWhite;
        }

        private void OnBackground3(object sender, RoutedEventArgs e)
        {
            _grid.Background = _background3.getColour();
            container.BackgroundType = BackgroundType.Sunset;
        }

        private void onBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), container);
        }
    }
}