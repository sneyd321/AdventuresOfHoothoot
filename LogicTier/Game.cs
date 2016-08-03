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
using Windows.UI.Xaml.Shapes;
using ProjectProposal;
using LogicTier;



namespace ProjectProposal
{
    public class Game
    {
        private DispatcherTimer _tmRaceTimer;

        private ProgressBar _progressBar;

        private Map _map;

        private int _difficulty;

        

        public Game(ProgressBar progressbar, Canvas canvas, Rectangle hoothoot )
        {
            _progressBar = progressbar;

            

            _difficulty = Difficulty.s_mapSpeed;



            _map = new Map(canvas, hoothoot, 4000);

            

        }

        public Map map
        {
            get
            {
                return _map;
            }
        }

        


        private void OnProgressBarIncrease(object sender, object e)
        {
            
            int difficulty = _difficulty;
            double stopPoint = (map.mapBackground.ActualWidth * -1);

            double divider = (stopPoint * -1) / difficulty;

            


            _progressBar.Value += (_progressBar.Maximum / divider);



            double currentPosistion = Canvas.GetLeft(map.mapBackground);


            if (currentPosistion <= stopPoint)
            {

                _tmRaceTimer.Stop();

            }

            else
            {
                _map.MoveEverythingLeft(difficulty);
            }





        }
        

        public void StartTimer(object sender, RoutedEventArgs e)
        {
            
            
            
            _tmRaceTimer = new DispatcherTimer();
            _tmRaceTimer.Tick += OnProgressBarIncrease;
            _tmRaceTimer.Interval = TimeSpan.FromMilliseconds(100);
            _tmRaceTimer.Start();           

        }

        

            

        

        















    }
}
