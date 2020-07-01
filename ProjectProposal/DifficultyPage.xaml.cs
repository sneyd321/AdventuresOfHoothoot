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
    public sealed partial class DifficultyPage : Page
    {


        private NavigationContainer container;

        public DifficultyPage()
        {
            
            this.InitializeComponent();
        }

        private void OnEasy(object sender, RoutedEventArgs e)
        {
            container.DifficultyType = DifficultyType.easy;
            this.Frame.Navigate(typeof(MainPage), container);
        }

        private void OnMedium(object sender, RoutedEventArgs e)
        {
            container.DifficultyType = DifficultyType.medium;
            this.Frame.Navigate(typeof(MainPage), container);
        }

        private void OnHard(object sender, RoutedEventArgs e)
        {
            container.DifficultyType = DifficultyType.hard;
            this.Frame.Navigate(typeof(MainPage), container);
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
    }
}
