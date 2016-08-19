using ProjectProposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicTier;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using System.Runtime.Serialization;
using Windows.Storage;
using System.IO;

namespace ProjectProposal
{
    [DataContract]
    public class Score
    {
        [DataMember]
        internal string _line;


        private static double s_score;

        private StorageFile _scoreFile;

        private string _name;

        

        public Score(double score)
        {
            
            s_score = score;
            _name = "";

            
            
        }

        

        public static double score
        {
            get
            {
                return s_score;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = name;
            }
        }

        public string line
        {
            get
            {
                return _line;
            }
        }
         


        //Create method onHoothootCompletesLevel
        public void onHootHootComplete()
        {
            //stop the timer 
            Game.timer.Stop();



            //get the difficulty
            double mapDifficulty = Difficulty.s_mapSpeed;
            //multiply the difficulty by the map width
            double finalScore = mapDifficulty * s_score;

            
            //Set value of s_score
            s_score = finalScore;
            

        }
        public async void readData()
        {
            StorageFolder storeFold = ApplicationData.Current.LocalFolder;

            try
            {
                _scoreFile = await storeFold.GetFileAsync("scores.txt");

            }
            catch (FileNotFoundException)
            {
                _scoreFile = await storeFold.CreateFileAsync("scores.txt", CreationCollisionOption.ReplaceExisting);

            }


            string scoreAsString = s_score.ToString();

            await FileIO.WriteTextAsync(_scoreFile, $"{_name}, {scoreAsString}");




            string text = await FileIO.ReadTextAsync(_scoreFile);

            MemoryStream mStrm = new MemoryStream(Encoding.UTF8.GetBytes(text));

            StreamReader reader = new StreamReader(mStrm);


            _line = reader.ReadLine();


            
        }

        public void hoothootDeadScore(double deapSpot)
        {
            double finalScore = (deapSpot * Difficulty.s_mapSpeed) * -1;
            s_score = finalScore;
            
        }

        

        













    }
}

