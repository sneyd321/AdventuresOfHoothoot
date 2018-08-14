using ProjectProposal;
using System;
using System.Collections.Generic;
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
using System.Windows;
using LogicTier;
using Windows.UI.Xaml.Shapes;
using System.Threading;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectProposal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoGamePage : Page
    {
        //Field Variables
        private int _spacer = 200;

        DispatcherTimer _timer;

        private Random _randomizer;

        private Rectangle _map;

        private Rectangle _map2;

        private HootHoot _hoothoot;

        private List<Rectangle> _obstacleList;

        private DateTime startTime;

        private DateTime endTime;

        /// <summary>
        /// Constructor for game page
        /// </summary>
        public DemoGamePage()
        {
            //Initialize Page
            this.InitializeComponent();
            //define list to hold all the obsticles 
            _obstacleList = new List<Rectangle>();
            //Define hoothoot object
            _hoothoot = new HootHoot(_hootHootEllipse);
            //Randomizer to make the height random
            _randomizer = new Random();

            

        }

       /// <summary>
       /// Creates map, places obstacles and set height of each obstacle
       /// </summary>
       /// <param name="left">Sets the position of the map</param>
       /// <returns>Returns a rectangle with all obstacles on it</returns>
        public Rectangle createMap(double left)
        {
            //Create new map object 
            Map m = new Map();
            //set size of the map
            Rectangle map = m.createMap(_canvas.Width, _canvas.ActualHeight);
            //set the colour of the map to colour selcted by the user
            map.Fill = MainPage.s_colour;
            //add the map to the canvis
            _canvas.Children.Add(map);
            //set the left position of the map 
            Canvas.SetLeft(map, left);
            //set the top position of the map
            Canvas.SetTop(map, 0);
            //set the initial space between the edge of the map the first obstacle
            double initSpacer = 100 + left;
            //set the distance between each obsticles
            double range = map.ActualWidth / 250;
            
            for (int i = 0; i < range; i++)
            {
                //get a random height
                double random = _randomizer.Next(Difficulty.s_obstacleHeight);
                //Create top pipes
                createTopPipe(m, initSpacer, random);
                //Create bottom pipes
                createBottomPipe(m, initSpacer, random);
                //Set increase the left position of the spacer
                initSpacer += _spacer;
            }
            //return map
            return map;          
        }

       
        /// <summary>
        /// Create the pipes on the top of the map
        /// </summary>
        /// <param name="map">The map that the obstacles are being placed</param>
        /// <param name="spacer">the space in between the obstacles</param>
        /// <param name="height">hieght for each obstacles</param>
        private void createTopPipe(Map map, double spacer, double height)
        {
            //get obstacle from map and set height and width
            Rectangle basePipe = map.getObstacle(75, height);
            //add to the canvas
            _canvas.Children.Add(basePipe);
            //set the z index to 1
            Canvas.SetZIndex(basePipe, 1);
            //Set the left position of the base pipe
            Canvas.SetLeft(basePipe, spacer);
            //Set the top position of the base pipe
            Canvas.SetTop(basePipe, 0);
            //add the obstacle to the list
            _obstacleList.Add(basePipe);
            //get another from the map
            Rectangle topPipe = map.getObstacle(125, 50);
            //add to the canvas
            _canvas.Children.Add(topPipe);
            //Set the z index to 1
            Canvas.SetZIndex(topPipe, 1);
            //set the left position of the top pipe
            Canvas.SetLeft(topPipe, (spacer - topPipe.Height / 2));
            //set the top position of the top pipe
            Canvas.SetTop(topPipe, height);
            //add pipe to list
            _obstacleList.Add(topPipe);
           
            
            
        }
        /// <summary>
        /// Create the pipes on the bottom of the map
        /// </summary>
        /// <param name="map">The map that the obstacles are being placed</param>
        /// <param name="spacer">the space in between the obstacles</param>
        /// <param name="height">hieght for each obstacles</param>
        private void createBottomPipe(Map map, double spacer, double height)
        {
            //get obstacle from map and set height and width
            Rectangle basePipe = map.getObstacle(75, height);
            //add to the canvas
            _canvas.Children.Add(basePipe);
            //set the z index to 1
            Canvas.SetZIndex(basePipe, 1);
            //Set the left position of the base pipe
            Canvas.SetLeft(basePipe, spacer);
            //Set the top position of the base pipe
            Canvas.SetTop(basePipe, _canvas.Height - basePipe.Height);
            //add to the list
            _obstacleList.Add(basePipe);
            //get obstacle from map and set height and width    
            Rectangle topPipe = map.getObstacle(125, 50);
            //add to the canva
            _canvas.Children.Add(topPipe);
            //set the z index to 1
            Canvas.SetZIndex(topPipe, 1);
            //Set the left position of the base pipe
            Canvas.SetLeft(topPipe, (spacer - topPipe.Height / 2));
            //Set the top position of the base pipe
            Canvas.SetTop(topPipe, _canvas.Height - basePipe.Height - topPipe.Height);
            //add to the list
            _obstacleList.Add(topPipe);
        }

        /// <summary>
        /// Starts dispatch timer and onTimerTick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartTimer(object sender, RoutedEventArgs e)
        {         
            //create timer object 
            _timer = new DispatcherTimer();
            
            //Set the timer interval
            _timer.Interval = TimeSpan.FromMilliseconds(50);            
            //start timer
            _timer.Start();
            //start score timer
            startTime = DateTime.Now;
            //Call onTimerTick
            _timer.Tick += OnTimerTick;

        }
        /// <summary>
        /// Moves the map left based on the difficulty
        /// </summary>
        /// <param name="map">map object that is being moved</param>
        private void moveMapLeft(Rectangle map)
        {
            //Get current position of the map
            double mapLeft = Canvas.GetLeft(map);
            //decrease left position
            mapLeft -= Difficulty.s_mapSpeed;
            //reset to new position
            Canvas.SetLeft(map, mapLeft);
        }
        
        /// <summary>
        /// Event that gets triggered for each dispatch timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerTick(object sender, object e)
        {
            //declare rect
            Rect topHitbox;
            Rect bottomHitbox;
            //Create hit box around hoothoot
            Rect hoot = new Rect(Canvas.GetLeft(_hootHootEllipse), Canvas.GetTop(_hootHootEllipse), _hootHootEllipse.Width, _hootHootEllipse.Height);
            //Move map1 left 
            moveMapLeft(_map);
            //move map2 left
            moveMapLeft(_map2);
            //move all obstacles left
            for (int i = 0; i < _obstacleList.Count; i++)
            {
                try
                {
                    //get current position of obstacle
                    double obstacleLeft = Canvas.GetLeft(_obstacleList[i]);
                    //decrease left position
                    obstacleLeft -= Difficulty.s_mapSpeed;
                    //reset left position
                    Canvas.SetLeft(_obstacleList[i], obstacleLeft);
                    //create a hitbox around all top obsticles
                    topHitbox = new Rect(0, 0, _obstacleList[i].Width + _spacer, _obstacleList[i].Height);
                    //create hitbox around all bottom obstacles
                    bottomHitbox = new Rect(0, _canvas.Height - (_obstacleList[i].Height), _obstacleList[i].Width + _spacer, _obstacleList[i].Height);
                    //chech if hoothoot intersects with any obstacle
                    topHitbox.Intersect(hoot);
                    bottomHitbox.Intersect(hoot);
                }
                catch (ArgumentException ex)
                {
                    //if an object returns null remove object from left
                    _obstacleList.RemoveAt(i);
                    //continue
                    continue;
                }                             
            }
            //if the hitbox is not empty
            if (!bottomHitbox.IsEmpty || !topHitbox.IsEmpty)
            {
                //call gameover
                gameOver();
            }
            //remove unsed obstacles
            garbageCollector();

            //hoothoot fall
            _hoothoot.fall();        
           
        }
        /// <summary>
        /// ends the game when hoothoot runs into an obstacle
        /// </summary>
        private async void gameOver()
        {
            //stop the timer
            _timer.Stop();
            //get current time
            endTime = DateTime.Now;
            //get number of seconds player was alive
            TimeSpan time = endTime - startTime;
            int score = time.Seconds;
            //Create gameover dialog
            MessageDialog gameOver = new MessageDialog("Game Over");
            gameOver.Commands.Add(new UICommand("Yes") { Id = 0 });
            gameOver.DefaultCommandIndex = 0;
            //show dialog
            var result = await gameOver.ShowAsync();
            //if player hits yes
            if ((int)result.Id == 0)
            {
                //got to score page
                this.Frame.Navigate(typeof(ScorePage), score);

            }
        }

        /// <summary>
        /// Removes maps and obstacles that are left of the canvas
        /// </summary>
        private void garbageCollector()
        {
            //if map1 is left of the canvas
            if (Canvas.GetLeft(_map) < -(_map.ActualWidth))
            {
                //remove all obstacles
                for (int i = 0; i < 24; i++)
                {
                    _obstacleList[i] = null;
                }
                //remove map1
                _map = null;
                //create new map
                _map = createMap(_canvas.ActualWidth);
            }
            //if map2 is left of the canvas
            if (Canvas.GetLeft(_map2) < -(_map2.ActualWidth))
            {
                //remove all obstacles
                for (int i = 0; i < 24; i++)
                {
                    _obstacleList[i] = null;
                }
                //remove map2
                _map2 = null;
                //create new map
                _map2 = createMap(_canvas.ActualWidth);
            }
        }
     

        /// <summary>
        /// Runs code while loading gamepage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            //starts the timer
            StartTimer(sender, e);
            //set the canvas background
            _canvas.Background = MainPage.s_colour;
            //define map1
            _map = createMap(0);
            //define map2
            _map2 = createMap(_canvas.ActualWidth);

            
        }
        /// <summary>
        /// on click event for making hoothoot flap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClick(object sender, RoutedEventArgs e)
        {          
            //hoothoot flap
            _hoothoot.Flap();                   
        }      
    }

}


