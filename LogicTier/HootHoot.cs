﻿using System;
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

        private Ellipse _hoothoot;

        private Image _imghoothoot;
        

        private const float FALLINGSPEED = 10.5f;
        private const double FLAPSPEED = -35.50f;

        private double _xlocation;

        private double _ylocation;

        
        



        

        public HootHoot(Ellipse hoothoot, Game game, Canvas canvas)
        {
            _game = game;
            _canvas = canvas;
            _xlocation = 150;
            _ylocation = 159;
            _hoothoot = new Ellipse();


            createHootHoot();
            
        }
        public void DrawHootHoot()
        {


            Canvas.SetLeft(_hoothoot, _xlocation);
            Canvas.SetTop(_hoothoot, _ylocation);
            Canvas.SetLeft(_imghoothoot, _xlocation);
            Canvas.SetTop(_imghoothoot, _ylocation);
            //_canvas.Children.Add(imghoothoot);
        }

        public void Flap()
        {

            _ylocation += FLAPSPEED;
            DrawHootHoot();
        }
    

        public void fall()
        {
            _ylocation += FALLINGSPEED;
            DrawHootHoot();
        }

        private void createHootHoot()
        {
            _hoothoot  = new Ellipse();

            _imghoothoot = new Image();

            _hoothoot.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            _hoothoot.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;

            _hoothoot.Width = 45;
            _hoothoot.Height = 50;
            

            _imghoothoot.Source = new BitmapImage(new Uri("ms-appx:///Assets/hoothoot.png"));

            ImageBrush _hoothootBitmapImage = new ImageBrush();
            _hoothootBitmapImage.ImageSource = _imghoothoot.Source;

                

            _canvas.Children.Add(_imghoothoot);

            _canvas.Children.Add(_hoothoot);

            Canvas.SetLeft(_hoothoot, 500);
            Canvas.SetTop(_hoothoot, 500);

            //DrawHootHoot();

        }
 

        

        /// <summary>
        /// Checks if hoothoot has collided with an obsticle
        /// </summary>
        public void OnHoothootDies()
        {

            for (int i = 0; i < _game.map.obsticleListOnTop.Count; i++)
            {
                _game.map.obsticleListOnTop[i].Collision(_hoothoot, _game.map.obsticleListOnTop[i].getObsticle);
                
            }

            for (int i = 0; i < _game.map.topPipeTop.Count; i++)
            {
                _game.map.topPipeTop[i].Collision(_hoothoot, _game.map.topPipeTop[i].getObsticle);
                
            }


            for (int i = 0; i < _game.map.obsticleListOnBottom.Count; i++)
            {
                _game.map.obsticleListOnBottom[i].Collision(_hoothoot, _game.map.obsticleListOnBottom[i].getObsticle);
                
            }

            for (int i = 0; i < _game.map.bottomPipeTop.Count; i++)
            {
                _game.map.bottomPipeTop[i].Collision(_hoothoot, _game.map.bottomPipeTop[i].getObsticle);
                
            }
        }

        

    }
}
