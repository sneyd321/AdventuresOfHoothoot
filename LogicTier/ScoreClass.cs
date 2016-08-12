using ProjectProposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicTier;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;


namespace ProjectProposal
{
    public class ScoreClass
    {

        private Game _game;

        private Ellipse _hoothoot;
        public ScoreClass(Game game, Ellipse hoothoot)
        {
            _game = game;

            _hoothoot = hoothoot;
        }   


            //Create method onHoothootCompletesLevel
        public int onHootHootComplete()
        {
            //stop the timer 
            Game.timer.Stop();

            //get the value of map width
            double mapWidth = _game.map.mapBackground.ActualWidth;
            //get the difficulty
            double mapDifficulty = Difficulty.s_mapSpeed;
            //multiply the difficulty by the map width
            double Score = mapDifficulty * mapWidth;
            int finalScore = (int)Score;
            // return score
            return finalScore;
        }



        //Create method onHootHootHitObsticle
        public int onHootHootHitObsticle()
        {
            //stop  the timer
            Game.timer.Stop();
            //get the left value of hoothoot
            double mapLeftWidth = Canvas.GetLeft(_hoothoot);
            //get the difficulty
            double mapDifficulty = Difficulty.s_mapSpeed;
            //multiply that value by the difficulty
            double FailScore = mapLeftWidth * mapDifficulty;
            int finalFailScore = (int)FailScore;
            //return score
            return finalFailScore;
        }







    }
}

