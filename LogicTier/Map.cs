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
        

        private Canvas _canvas;

        private Random _randomizer;

        private Rectangle _map;

        //do not remove
        private int _obstHeight;

        private List<Obsticle> _obsticleOnTopList;

        private List<Obsticle> _obsticleOnBottomList;

        private List<Obsticle> _topPipeTopsList;

        private List<Obsticle> _bottomPipeTopsList;

        private Ellipse _hoothoot;

        private Obsticle _topPipeTops;

        private Obsticle _bottomPipeTops;

        private ScoreClass _score;

        

        public Map(Canvas canvas, Ellipse hoothoot, int width)
        {
 

            _canvas = canvas;

            _hoothoot = hoothoot;

            _randomizer = new Random();

            _topPipeTopsList = new List<Obsticle>();

            _bottomPipeTopsList = new List<Obsticle>();
         
            _map = new Rectangle();

            
            
                   
            createMap(width);

            

            createObsticles();

            createBottomObsticles();

            createTopObsticles();

        }

        public Rectangle mapBackground
        {
            get
            {
                return _map;
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

        

        private void createMap(int width)
        {
            _map.HorizontalAlignment = HorizontalAlignment.Left;
            _map.VerticalAlignment = VerticalAlignment.Center;

            
            
            _map.Width = width;
            _map.Height = _canvas.ActualHeight;

            _canvas.Children.Add(_map);

            Canvas.SetLeft(_map, 0);
            Canvas.SetTop(_map, _canvas.ActualHeight);

        }

        

        





        /// <summary>
        /// Place obsticles on the map based on the difficulty
        /// </summary>
        /// <param name="obsticle"></param>
        /// <returns></returns>
        public int placeObsticles(Obsticle obsticle)
        {
            

            //if easy
            if (Difficulty.s_difficultyChoice == 1)
            {
                //set the max length equal to 1/4 of height of map
                double modifier = _map.ActualHeight / 4;
                int easy = (int)modifier;
                //set the obsticle height to a random value
                int _obstHeight = _randomizer.Next(easy);
                obsticle.createSize(50, _obstHeight);
                //set the start location of the obsticles
                obsticle.setLocation(0, 0);
                //return obsticle height
                return _obstHeight;

            }
            //if medium
            else if (Difficulty.s_difficultyChoice == 2)
            {
                //set the max length equal to 1/3 of height of map
                double modifier = _map.ActualHeight / 3;
                int medium = (int)modifier;
                //set the obsticle height to a random value
                int _obstHeight = _randomizer.Next(medium);
                obsticle.createSize(50, _obstHeight);
                //set the start location of the obsticles
                obsticle.setLocation(0, 0);
                //return obsticle height
                return _obstHeight;


            }
            //if hard
            else if (Difficulty.s_difficultyChoice == 3)
            {
                //set the max length equal to 1/2 of height of map +/- height of hoothoot

                double modifier = (_map.ActualHeight / 2) - 40;
                int hard = (int)modifier;
                //set the obsticle height to a random value

                int _obstHeight = _randomizer.Next(hard);
                obsticle.createSize(50, _obstHeight);
                //set the start location of the obsticles

                obsticle.setLocation(0, 0);
                //return obsticle height
                return _obstHeight;

            }

            return _obstHeight;


        }
        
        
        /// <summary>
        /// creates obsticle objects and add them to a list 
        /// </summary>
        public void createObsticles()
        {
            //determine the number of obsticle needed based on the difficulty and map size
            double numOfObst = _map.ActualWidth / Difficulty.s_obsticleDistance;
            int obsticleNumber = (int)numOfObst;
            //create list of obsticles
            _obsticleOnTopList = new List<Obsticle>();
            //create obsticle objects and append them to then list
            for (int i = 0; i < obsticleNumber; i++)
            {
                _obsticleOnTopList.Add(new Obsticle(_canvas, _hoothoot));
            }


            //create list of obsticles
            _obsticleOnBottomList = new List<Obsticle>();
            //create obsticle objects and append them to then list
            for (int i = 0; i < obsticleNumber; i++)
            {
                _obsticleOnBottomList.Add(new Obsticle(_canvas, _hoothoot));
            }


        }
        /// <summary>
        /// Place the obsticle that appear on top onto the map
        /// </summary>
        public void createTopObsticles()
        {
            //value defaulted to zero
            int value = 0;
            //place all the obsticles in obsticleList
            foreach (Obsticle obsticle in _obsticleOnTopList)
            {
                //get the height of obsticles to place pipe tops
                double height = placeObsticles(obsticle);
                //set the location of the obsticle
                int left = Difficulty.s_obsticleDistance * value + 500;
                obsticle.setLocation(left, 0);
                value++;
                //create pipe tops
                _topPipeTops = new Obsticle(_canvas, _hoothoot);
                _topPipeTops.createSize(75, 30);
                _topPipeTops.setLocation(left - 12.5, height);
                //add pipe tops to pipeTopList
                _topPipeTopsList.Add(_topPipeTops);
            }
        }
        /// <summary>
        /// Places the obsticles that appear on the bottom onto the map
        /// </summary>
        public void createBottomObsticles()
        {
            //value defaulted to zero
            int value = 0;
            //place all the obsticles in obsticleList
            foreach (Obsticle obsticle in _obsticleOnBottomList)
            {

                //get the height of obsticles to place pipe tops
                double height = placeObsticles(obsticle);
                //flip obstilce
                obsticle.getObsticle.RenderTransformOrigin = new Point(1, 1);
                ScaleTransform flipObsticle = new ScaleTransform();
                flipObsticle.ScaleY = -1;
                //set the location of the obsticle
                int left = Difficulty.s_obsticleDistance * value + 500;
                obsticle.setLocation(left, _map.ActualHeight - (obsticle.getObsticle.ActualHeight));
                value++;
                //create pipe tops
                _bottomPipeTops = new Obsticle(_canvas, _hoothoot);
                _bottomPipeTops.createSize(75, 30);
                _bottomPipeTops.setLocation(left - 12.5, _map.ActualHeight - height);
                //flip pipe tops
                _bottomPipeTops.getObsticle.RenderTransformOrigin = new Point(1, 1);
                ScaleTransform flipPipeTop = new ScaleTransform();
                flipPipeTop.ScaleY = -1;
                //add pipe tops to pipeTopList
                _bottomPipeTopsList.Add(_bottomPipeTops);
            }
        }
        /// <summary>
        /// Moves all obsticle objects and map to the left
        /// </summary>
        /// <param name="difficulty"></param>
        public void MoveEverythingLeft(int difficulty)
        {
            //gets posistion of map
            double rectPosistion = Canvas.GetLeft(_map);
            //move the posisiton based on the set difficulty
            rectPosistion -= difficulty;
            //set position
            Canvas.SetLeft(_map, rectPosistion);

            foreach (Obsticle obsticle in obsticleListOnTop)
            {
                //gets posistion of obsticle
                double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                //move the posisiton based on the set difficulty
                obstPosistion -= difficulty;
                //set position
                Canvas.SetLeft(obsticle.getObsticle, obstPosistion);

            }

            foreach (Obsticle obsticle in obsticleListOnBottom)
            {
                //gets posistion of obsticle
                double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                //move the posisiton based on the set difficulty
                obstPosistion -= difficulty;
                //set position
                Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
            }

            foreach (Obsticle obsticle in topPipeTop)
            {
                //gets posistion of obsticle
                double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                //move the posisiton based on the set difficulty
                obstPosistion -= difficulty;
                //set position
                Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
            }

            foreach (Obsticle obsticle in bottomPipeTop)
            {
                //gets posistion of obsticle
                double obstPosistion = Canvas.GetLeft(obsticle.getObsticle);
                //move the posisiton based on the set difficulty
                obstPosistion -= difficulty;
                //set position
                Canvas.SetLeft(obsticle.getObsticle, obstPosistion);
            }
        }

    }
}
