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

        private Rectangle _mapBackground;

        private int _difficulty;

        public Map _map;

        private Canvas _canvas;

        public static List<Obsticle> _obsticleOnTopList;

        public static List<Obsticle> _obsticleOnBottomList;

        public  List<Obsticle> _topPipeTopsList;

        public  List<Obsticle> _bottomPipeTopsList;

        private Rectangle _testHoothoot;

        private Obsticle _topPipeTops;

        private Obsticle _bottomPipeTops;

        public Game(ProgressBar progressbar, Rectangle mapBackground, Canvas canvas, Rectangle testHoothoot)
        {
            _progressBar = progressbar;

            _mapBackground = mapBackground;

            _canvas = canvas;

            _testHoothoot = testHoothoot;

            _difficulty = Difficulty.s_mapSpeed;

            _map = new Map(-3000, _mapBackground, _canvas);

            _topPipeTopsList = new List<Obsticle>();

            _bottomPipeTopsList = new List<Obsticle>();


        }

        public List<Obsticle> obsticleListOnTop
        {
            get
            {
                return _obsticleOnTopList;
            }
        }

        public List<Obsticle> obsticleListOnBottom
        {
            get
            {
                return _obsticleOnBottomList;
            }
        }


        private void OnProgressBarIncrease(object sender, object e)
        {
            //Future Parameters
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
                double rectPosistion = Canvas.GetLeft(_mapBackground);
                rectPosistion -= difficulty;
                Canvas.SetLeft(_mapBackground, rectPosistion);

                foreach (Obsticle obsticle in _obsticleOnTopList)
                {
                    double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                    obstPosistion -= difficulty;
                    Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
                    Canvas.SetLeft(_topPipeTops.getObsticle, obstPosistion);

                }

                foreach (Obsticle obsticle in _obsticleOnBottomList)
                {
                    double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                    obstPosistion -= difficulty;
                    Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
                }

                foreach (Obsticle obsticle in _topPipeTopsList)
                {
                    double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                    obstPosistion -= difficulty;
                    Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
                }

                foreach (Obsticle obsticle in _bottomPipeTopsList)
                {
                    double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                    obstPosistion -= difficulty;
                    Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
                }
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

        public void createObsticles()
        {
            double numOfObst = _mapBackground.ActualWidth / Difficulty.s_obsticleDistance;
            int obsticleNumber = (int)numOfObst;

            _obsticleOnTopList = new List<Obsticle>();

            for (int i = 0; i < obsticleNumber; i++)
            {
                _obsticleOnTopList.Add(new Obsticle(_canvas, _testHoothoot));
            }



            _obsticleOnBottomList = new List<Obsticle>();

            for (int i = 0; i < obsticleNumber; i++)
            {
                _obsticleOnBottomList.Add(new Obsticle(_canvas, _testHoothoot));
            }

           


        }

        public void createTopObsticles()
        {
            int i = 0;

            foreach (Obsticle obsticle in _obsticleOnTopList)
            {
                double height = _map.placeObsticles(obsticle);




                int left = Difficulty.s_obsticleDistance * i;
                obsticle.setLocation(left, 0);
                i++;

                _topPipeTops = new Obsticle(_canvas, _testHoothoot);

                _topPipeTops.createSize(75, 30);
                _topPipeTops.setLocation(left - 12.5, height);
                _topPipeTopsList.Add(_topPipeTops);
            }
        }
       


        public void createBottomObsticles()
        {
            int i = 0;

            foreach (Obsticle obsticle in _obsticleOnBottomList)
            {


                double height = _map.placeObsticles(obsticle);

                obsticle.getObsticle.RenderTransformOrigin = new Point(1, 1);
                ScaleTransform flipObsticle = new ScaleTransform();
                flipObsticle.ScaleY = -1;

                int left = Difficulty.s_obsticleDistance * i;
                obsticle.setLocation(left, _mapBackground.ActualHeight - (obsticle.getObsticle.ActualHeight));
                i++;

                _bottomPipeTops = new Obsticle(_canvas, _testHoothoot);

                _bottomPipeTops.createSize(75, 30);
                _bottomPipeTops.setLocation(left - 12.5, _mapBackground.ActualHeight  - height);

                _bottomPipeTops.getObsticle.RenderTransformOrigin = new Point(1, 1);
                ScaleTransform flipPipeTop = new ScaleTransform();
                flipPipeTop.ScaleY = -1;

                _bottomPipeTopsList.Add(_bottomPipeTops);
            }
        }

        






    }
}
