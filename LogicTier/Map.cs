using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using ProjectProposal;
using LogicTier;
using Windows.Foundation;

namespace ProjectProposal
{
    public class Map
    {


        private double _mapSize;

        private Rectangle _mapBackground;

        private Canvas _canvas;

        private Random _randomizer;

        //do not remove
        private int _obstHeight;

        public List<Obsticle> _obsticleOnTopList;

        public List<Obsticle> _obsticleOnBottomList;

        public List<Obsticle> _topPipeTopsList;

        public List<Obsticle> _bottomPipeTopsList;

        private Rectangle _testHoothoot;

        private Obsticle _topPipeTops;

        private Obsticle _bottomPipeTops;

        public Map(double mapSize, Rectangle mapBackground, Canvas canvas, Rectangle testHoothoot)
        {

            _mapSize = mapSize;

            _mapBackground = mapBackground;

            _canvas = canvas;

            _testHoothoot = testHoothoot;

            _randomizer = new Random();

            _topPipeTopsList = new List<Obsticle>();

            _bottomPipeTopsList = new List<Obsticle>();


        }
        public Rectangle mapBackground
        {
            get
            {
                return mapBackground;
            }
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

        public List<Obsticle> topPipeTop
        {
            get
            {
                return _topPipeTopsList;
            }
        }

        public List<Obsticle> bottomPipeTop
        {
            get
            {
                return _bottomPipeTopsList;
            }
        }





        public double mapSize
        {
            get
            {
                _mapSize = _mapBackground.ActualWidth;
                return _mapSize;
            }
        }

        public int placeObsticles(Obsticle obsticle)
        {
            

            //if easy
            if (Difficulty.s_mapSpeed == 10)
            {
                double modifier = _mapBackground.ActualHeight / 4;
                int easy = (int)modifier;

                int _obstHeight = _randomizer.Next(easy);
                obsticle.createSize(50, _obstHeight);

                obsticle.setLocation(0, 0);

                return _obstHeight;

            }
            else if (Difficulty.s_mapSpeed == 25)
            {
                double modifier = _mapBackground.ActualHeight / 3;
                int medium = (int)modifier;

                int _obstHeight = _randomizer.Next(medium);
                obsticle.createSize(50, _obstHeight);

                obsticle.setLocation(0, 0);

                return _obstHeight;


            }
            else if (Difficulty.s_mapSpeed == 50)
            {
                double modifier = (_mapBackground.ActualHeight / 2) - 25;
                int hard = (int)modifier;

                int _obstHeight = _randomizer.Next(hard);
                obsticle.createSize(50, _obstHeight);

                obsticle.setLocation(0, 0);

                return _obstHeight;

            }

            return _obstHeight;


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
                double height = placeObsticles(obsticle);




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


                double height = placeObsticles(obsticle);

                obsticle.getObsticle.RenderTransformOrigin = new Point(1, 1);
                ScaleTransform flipObsticle = new ScaleTransform();
                flipObsticle.ScaleY = -1;

                int left = Difficulty.s_obsticleDistance * i;
                obsticle.setLocation(left, _mapBackground.ActualHeight - (obsticle.getObsticle.ActualHeight));
                i++;

                _bottomPipeTops = new Obsticle(_canvas, _testHoothoot);

                _bottomPipeTops.createSize(75, 30);
                _bottomPipeTops.setLocation(left - 12.5, _mapBackground.ActualHeight - height);

                _bottomPipeTops.getObsticle.RenderTransformOrigin = new Point(1, 1);
                ScaleTransform flipPipeTop = new ScaleTransform();
                flipPipeTop.ScaleY = -1;

                _bottomPipeTopsList.Add(_bottomPipeTops);
            }
        }

        public void MoveEverythingLeft(int difficulty)
        {
            double rectPosistion = Canvas.GetLeft(_mapBackground);
            rectPosistion -= difficulty;
            Canvas.SetLeft(_mapBackground, rectPosistion);

            foreach (Obsticle obsticle in obsticleListOnTop)
            {
                double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                obstPosistion -= difficulty;
                Canvas.SetLeft(obsticle.getObsticle, obstPosistion);

            }

            foreach (Obsticle obsticle in obsticleListOnBottom)
            {
                double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                obstPosistion -= difficulty;
                Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
            }

            foreach (Obsticle obsticle in topPipeTop)
            {
                double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                obstPosistion -= difficulty;
                Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
            }

            foreach (Obsticle obsticle in bottomPipeTop)
            {
                double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                obstPosistion -= difficulty;
                Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
            }
        }

    }
}
