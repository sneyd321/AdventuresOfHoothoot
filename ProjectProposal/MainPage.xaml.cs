using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;
using ProjectProposal;
using LogicTier;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectProposal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private NavigationContainer container;
  

        public MainPage()
        {
            this.InitializeComponent();
            BackgroundFactory backgroundFactory = (BackgroundFactory)AbstractFactory.getFactory(FactoryType.Background);
            GradientBackground background = backgroundFactory.GetBackground(BackgroundType.Rainbow);
            _grid.Background = background.getColour();
            container = new NavigationContainer();
            container.BackgroundType = BackgroundType.Rainbow;
            container.DifficultyType = DifficultyType.medium;
        }
 
        private void OnExitGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
      
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {         
            //navigate to the next page
            this.Frame.Navigate(typeof(DemoGamePage), container);
        }

        private void OnChangeBackground(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BackgroundPage), container);
        }

        private void OnSelectDifficulty(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DifficultyPage), container);
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
