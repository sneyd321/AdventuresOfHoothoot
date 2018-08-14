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
using Windows.Storage;
using Windows.UI.Popups;
using ProjectProposal;
using System.Runtime.Serialization.Json;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectProposal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ScorePage : Page
    {        
        /// <summary>
        /// Score the player got
        /// </summary>
        private int _score;

        /// <summary>
        /// Constructor for page
        /// </summary>
        public ScorePage()
        {
            this.InitializeComponent();       
        }

        /// <summary>
        /// On navigated to event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //get score from demoGamePage
            _score = (int)e.Parameter;          
        }
        /// <summary>
        /// When player hits the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExit(object sender, RoutedEventArgs e)
        {
            //exit application
            Application.Current.Exit();
        }
        
        private void OnLoad(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// When player presses play again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNextLevel(object sender, RoutedEventArgs e)
        {
            //go to demoGamePage
            this.Frame.Navigate(typeof(DemoGamePage));
        }
        /// <summary>
        /// Event that handles user name input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            //Set visability 
            _btnSubmitString.Visibility = Visibility.Collapsed;           
            _txtBlock2.Visibility = Visibility.Collapsed;
            _userName.Visibility = Visibility.Collapsed;
            //Set Text
            _txtBLock1.Text = "Your Score";
            //Show score
            _highScores.Text = $"{_userName.Text}'s score is {_score} seconds";
        }      
    }
}
