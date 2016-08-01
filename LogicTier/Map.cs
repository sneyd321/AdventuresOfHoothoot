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

namespace ProjectProposal
{
    public class Map
    {


        private double _mapSize;

        private Rectangle _mapBackground;

        private Canvas _canvas;

        private Random _randomizer;

        private int _obstHeight;


        public Map(double mapSize, Rectangle mapBackground, Canvas canvas)
        {
            
            _mapSize = mapSize;

            _mapBackground = mapBackground;

            _canvas = canvas;

            _randomizer = new Random();

            

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
        public void placePipeTops(Obsticle obsticle)
        {
            obsticle.createSize(75, 20);

            

            obsticle.setLocation(0, 0);
        }


        }
}
