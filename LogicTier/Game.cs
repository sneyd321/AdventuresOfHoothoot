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

        private Rectangle _mapBackground;

        public Game(ProgressBar progressbar, Rectangle mapBackGround, Canvas canvas, Rectangle hoothoot)
        {
            _progressBar = progressbar;

            _mapBackground = mapBackGround;

            _difficulty = Difficulty.s_mapSpeed;

            _map = new Map(-3000, mapBackGround, canvas, hoothoot);

            

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
            double stopPoint = (_mapBackground.ActualWidth * -1);

            double divider = (stopPoint * -1) / difficulty;



            _progressBar.Value += (_progressBar.Maximum / divider);



            double currentPosistion = Canvas.GetLeft(_mapBackground);


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
            
            Canvas.SetLeft(_mapBackground, 0);
            
            _tmRaceTimer = new DispatcherTimer();
            _tmRaceTimer.Tick += OnProgressBarIncrease;
            _tmRaceTimer.Interval = TimeSpan.FromMilliseconds(100);
            _tmRaceTimer.Start();           

        }

        public void LoadGame(object sender, RoutedEventArgs e)
        {
            _map.createObsticles();
        
            _map.createBottomObsticles();
            _map.createTopObsticles();

            StartTimer(sender, e);

        }

        















    }
}
