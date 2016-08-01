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
        public Obsticle _obsticle;

        private double _mapSize;

        private Rectangle _mapBackground;

        private Canvas _canvas;

        private Random _randomizer;

        public int _obstHeight;


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

        public void placeObsticles(Obsticle obsticle)
        {
            


            //if easy
            if (Difficulty.s_mapSpeed == 10)
            {
                double modifier = _mapBackground.ActualHeight / 4;
                int easy = (int)modifier;

                int _obstHeight = _randomizer.Next(easy);
                obsticle.createSize(_obstHeight);

                obsticle.setLocation(0, 0);
                
                

            }
            else if (Difficulty.s_mapSpeed == 25)
            {
                double modifier = _mapBackground.ActualHeight / 3;
                int medium = (int)modifier;

                int _obstHeight = _randomizer.Next(medium);
                obsticle.createSize(_obstHeight);

                obsticle.setLocation(0, 0);


                

            }
            else if (Difficulty.s_mapSpeed == 50)
            {
                double modifier = _mapBackground.ActualHeight / 2;
                int hard = (int)modifier;

                int _obstHeight = _randomizer.Next(hard);
                obsticle.createSize(_obstHeight);

                obsticle.setLocation(0, 0);



            }
           

        }


    }
}
