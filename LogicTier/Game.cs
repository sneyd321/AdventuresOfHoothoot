﻿using System;
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
        /// <summary>
        /// Field that initializes the timer
        /// </summary>
        private DispatcherTimer _tmRaceTimer;

        /// <summary>
        /// Field that initializes the progressbar
        /// </summary>
        private ProgressBar _progressBar;

        /// <summary>
        /// Field that initializes the map 
        /// </summary>
        private Map _map;

        /// <summary>
        /// Field that initializes the difficulty
        /// </summary>
        private int _difficulty;

        

        public Game(ProgressBar progressbar, Canvas canvas, Rectangle hoothoot )
        {
            _progressBar = progressbar;

            
            
            _difficulty = Difficulty.s_mapSpeed;


            //creates map object
            _map = new Map(canvas, hoothoot, 4000);

            

        }
        /// <summary>
        /// Returns the map object
        /// </summary>
        public Map map
        {
            get
            {
                return _map;
            }
        }

        

        /// <summary>
        /// Method that show the current location of hoothoot relative to the map and moves the map for every timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnProgressBarIncrease(object sender, object e)
        {
            
            int difficulty = _difficulty;
            //create the point that will stop the map from moving
            double stopPoint = (map.mapBackground.ActualWidth * -1);
            //set the value of how much the progress bar will increment per timer tick
            double divider = (stopPoint * -1) / difficulty;

            

            //return the value of _progressBar
            _progressBar.Value += (_progressBar.Maximum / divider);


            //get the current posistion of the map
            double currentPosistion = Canvas.GetLeft(map.mapBackground);

            //checks if the current posistion of the map has reached the stop point
            if (currentPosistion <= stopPoint)
            {
                //stop the timer
                _tmRaceTimer.Stop();

            }

            else
            {
                //call the that moves everthing to the left every timer tick
                _map.MoveEverythingLeft(difficulty);
            }





        }
        
        /// <summary>
        /// Initializes and starts the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartTimer(object sender, RoutedEventArgs e)
        {
            
            
            //create timer object 
            _tmRaceTimer = new DispatcherTimer();           
            _tmRaceTimer.Tick += OnProgressBarIncrease;
            _tmRaceTimer.Interval = TimeSpan.FromMilliseconds(100);
            //start timer
            _tmRaceTimer.Start();           

        }

        

            

        

        















    }
}
