using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicTier;
using ProjectProposal;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.Foundation;

namespace LogicTier
{
    public class HootHoot
    {

        private Game _game;

        private Canvas _canvas;

        private Ellipse _Elhoothoot;

        private Image _imghoothoot;

        private double _xlocation;

        private double _ylocation;

        //Constants
        private const float FALLINGSPEED = 12.5f;
        private const double FLAPSPEED = -45.50f;

        


        
        /// <summary>
        /// Constructor for the hoot hoot class
        /// Takes the hitbox shape, game and canvas objects
        /// </summary>
        /// <param name="hoothoot"></param>
        /// <param name="game"></param>
        /// <param name="canvas"></param>
        public HootHoot(Ellipse hoothoot, Game game, Canvas canvas)
        {
            _game = game;
            _canvas = canvas;
            _xlocation = 150;
            _ylocation = 150;
            _Elhoothoot = new Ellipse();

            createHootHoot();            
        }

        /// <summary>
        /// Draws Hoothoot at the specified location when called.
        /// </summary>
        public void DrawHootHoot()
        {
            Canvas.SetLeft(_Elhoothoot, _xlocation);
            Canvas.SetTop(_Elhoothoot, _ylocation);
            Canvas.SetLeft(_imghoothoot, _xlocation);
            Canvas.SetTop(_imghoothoot, _ylocation);
            //_canvas.Children.Add(imghoothoot);
        }

        /// <summary>
        /// Method for moving the character upwards on user input
        /// </summary>
        public void Flap()
        {
            _ylocation += FLAPSPEED/2;
            DrawHootHoot();
            _ylocation += FLAPSPEED/2;
            DrawHootHoot();
        }
    
        /// <summary>
        /// Method that simulates gravity of hoothoot, updates canvas
        /// </summary>
        public void fall()
        {
            _ylocation += FALLINGSPEED;
            DrawHootHoot();
            
        }

        /// <summary>
        /// Method to create a new HootHoot and put it on the canvas
        /// </summary>
        private void createHootHoot()
        {
            //create new ellipse and image for hoothoot collisions and appearance
            _Elhoothoot  = new Ellipse();
            _imghoothoot = new Image();

            _Elhoothoot.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            _Elhoothoot.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;

            _Elhoothoot.Width = 45;
            _Elhoothoot.Height = 50;
            
            //Store source of image
            _imghoothoot.Source = new BitmapImage(new Uri("ms-appx:///Assets/hoothoot.png"));

            //Set the image of hoot hoot from the uri above
            ImageBrush _hoothootBitmapImage = new ImageBrush();
            _hoothootBitmapImage.ImageSource = _imghoothoot.Source;


            //Add the Items onto the canvas
            _canvas.Children.Add(_imghoothoot);
            _canvas.Children.Add(_Elhoothoot);

            //Set their initial locations
            Canvas.SetLeft(_Elhoothoot, 200);
            Canvas.SetTop(_Elhoothoot, 600);

        }
 

        

        /// <summary>
        /// Checks if hoothoot has collided with an obsticle
        /// </summary>
        public void OnHoothootDies()
        {

            for (int i = 0; i < _game.map.obsticleListOnTop.Count; i++)
            {
                _game.map.obsticleListOnTop[i].Collision(_Elhoothoot, _game.map.obsticleListOnTop[i].getObsticle);
                
            }

            for (int i = 0; i < _game.map.topPipeTop.Count; i++)
            {
                _game.map.topPipeTop[i].Collision(_Elhoothoot, _game.map.topPipeTop[i].getObsticle);
                
            }


            for (int i = 0; i < _game.map.obsticleListOnBottom.Count; i++)
            {
                _game.map.obsticleListOnBottom[i].Collision(_Elhoothoot, _game.map.obsticleListOnBottom[i].getObsticle);
                
            }

            for (int i = 0; i < _game.map.bottomPipeTop.Count; i++)
            {
                _game.map.bottomPipeTop[i].Collision(_Elhoothoot, _game.map.bottomPipeTop[i].getObsticle);
                
            }
        }



        

    }
}
