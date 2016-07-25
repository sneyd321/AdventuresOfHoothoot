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



namespace ProjectProposal
{
    public class Game
    {
        private DispatcherTimer _tmRaceTimer;

        private ProgressBar _progressBar;

        private Rectangle _mapBackground;

        private int _difficulty;

        private Map _map;

        public Game(ProgressBar progressbar, Rectangle mapBackground)
        {
            _progressBar = progressbar;
            _mapBackground = mapBackground;

            _difficulty = Difficulty.s_mapSpeed;

            _map = new Map(-3000);
        }


        private void OnProgressBarIncrease(object sender, object e)
        {
            //Future Parameters
            int difficulty = _difficulty;
            int mapLength = _map.mapSize;

            double divider = (mapLength * -1) / difficulty;



            _progressBar.Value += (_progressBar.Maximum / divider);



            double currentPosistion = Canvas.GetLeft(_mapBackground);


            if (currentPosistion <= mapLength)
            {

                _tmRaceTimer.Stop();

            }

            else
            {
                var rectPosistion = Canvas.GetLeft(_mapBackground);
                rectPosistion -= difficulty;
                Canvas.SetLeft(_mapBackground, rectPosistion);
            }          

        }
        

        public void StartTimer(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(_mapBackground, 0);
            _tmRaceTimer = new DispatcherTimer();
            _tmRaceTimer.Tick += OnProgressBarIncrease;
            _tmRaceTimer.Interval = TimeSpan.FromMilliseconds(100);
            _tmRaceTimer.Start();           

        }
    }
}
