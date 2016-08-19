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
        private DataContractJsonSerializer ser;
        private MemoryStream stream1;
        private Score _score;

        public ScorePage()
        {
            this.InitializeComponent();

            _score = new Score(Score.score);

            stream1 = new MemoryStream();

            ser = new DataContractJsonSerializer(typeof(Score));
        }

        

       

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

       

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            _highScores.Visibility = Visibility.Collapsed;
        }

        

        private void OnNextLevel(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DemoGamePage));
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            _score.name = _userName.Text;
            _btnSubmitString.Visibility = Visibility.Collapsed;
            _txtBLock1.Text = "Your Score";
            _txtBlock2.Visibility = Visibility.Collapsed;
            _userName.Visibility = Visibility.Collapsed;

            _highScores.Visibility = Visibility.Visible;


            

            _highScores.Text = $"{_userName.Text}'s score is {Score.score}";

            _score.readData();

           
            save();


        }
        private void save()
        {
            //serialize



            ser.WriteObject(stream1, _score);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            

        }



    }
}
